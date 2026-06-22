using SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.ValueObject;
using SistemaGestaoOcorrencias.Domain.Utils.Enums;
using SistemaGestaoOcorrencias.Domain.Interfaces;
using SistemaGestaoOcorrencias.Domain.Utils.Validations;

namespace SistemaGestaoOcorrencias.Domain.Entities;

public abstract class Ocorrencia
{
    public string Descricao { get; }
    public string Protocolo { get; }
    public Bairro Bairro { get; }
    public DateTime DataAbertura { get; }
    public NivelPrioridadeEnum NivelPrioridade { get; protected set; }
    public Situacao Situacao { get; protected set; }
    public bool ExigeVistoria { get; protected set; }
    public Vistoria? Vistoria { get; protected set; }
    public string? Justificativa { get; protected set; }
    public Setor SetorResponsavel { get; protected set; }
    public string? ProtocoloRelacionado { get; }
    public bool EhTerminal => Situacao is Situacao.Encerrada or Situacao.Recusada or Situacao.Duplicada;

    private readonly List<Movimentacao> _historicoMovimentacoes = new();
    private readonly List<Impedimento> _impedimentos = new();

    public IReadOnlyCollection<Movimentacao> HistoricoMovimentacoes => _historicoMovimentacoes.AsReadOnly();
    public IReadOnlyCollection<Impedimento> Impedimentos => _impedimentos.AsReadOnly();

    protected Ocorrencia(
        string descricao, 
        string protocolo, 
        Bairro bairro, 
        DateTime dataAbertura, 
        Setor setorResponsavel, 
        string? protocoloRelacionado,
        ICalcularPrioridade estrategiaPrioridade,
        IEstrategiaTriagem estrategiaTriagem)
    {
        Descricao = ValidarTexto.Validar(descricao, "Descrição é obrigatória. ");
        Protocolo = ValidarTexto.Validar(protocolo, "Protocolo é obrigatório. ");
        Bairro = ValidarObjeto.Validar(bairro, "Bairro é obrigatório. ");
        DataAbertura = ValidarData.Validar(dataAbertura, DateTime.MinValue, DateTime.Now, "Data de abertura é inválida.");
        SetorResponsavel = ValidarObjeto.Validar(setorResponsavel, "Setor responsável é obrigatório. ");
        ProtocoloRelacionado = protocoloRelacionado;
        ExigeVistoria = DeterminarExigeVistoria();
        Situacao = Situacao.AguardandoTriagem;

        CalcularPrioridade(estrategiaPrioridade);
    }

    protected virtual bool DeterminarExigeVistoria() => false;

    private void RegistrarMovimentacao(TipoMovimentacao tipo, Situacao situacaoAnterior,
                                       Situacao situacaoNova, string? descricao = null)
    {
        var movimentacao = new Movimentacao(tipo, situacaoAnterior, situacaoNova, DateTime.Now, descricao);

        _historicoMovimentacoes.Add(movimentacao);
    }

    public void RegistrarImpedimento(Impedimento impedimento)
    {
        VerificarSeTerminal();

        if (_impedimentos.Contains(impedimento))
        {
            throw new InvalidOperationException("Este impedimento já foi registrado.");
        }

        _impedimentos.Add(impedimento);
    }

    public void RegistrarVistoria(Vistoria vistoria)
    {
        VerificarSeTerminal();

        if (Situacao != Situacao.EncaminhadaParaVistoria)
            throw new InvalidOperationException("A ocorrência precisa estar encaminhada para vistoria.");

        var anterior = Situacao;
        Vistoria = vistoria;

        if (vistoria.Aprovada)
            Situacao = Situacao.EncaminhadaParaExecucao;

        RegistrarMovimentacao(TipoMovimentacao.Vistoria, anterior, Situacao);
    }

    public void Executar()
    {
        VerificarSeTerminal();

        if (ExigeVistoria && Vistoria == null)
            throw new InvalidOperationException("A vistoria ainda está pendente.");

        if (_impedimentos.Any(i => !i.Resolvido))
            throw new InvalidOperationException("Existem impedimentos pendentes.");
        
        if (Situacao != Situacao.EncaminhadaParaExecucao)
            throw new InvalidOperationException("A ocorrência precisa estar encaminhada para execução.");

        var anterior = Situacao;
        Situacao = Situacao.EmExecucao;

        RegistrarMovimentacao(TipoMovimentacao.Execucao, anterior, Situacao);
    }

    public bool Encerrar(IValidadorEncerramento validadorEncerramento, string justificativa)
    {
        VerificarSeTerminal();
        Justificativa = ValidarTexto.Validar(justificativa, "Justificativa de encerramento é obrigatória.");

        if (!validadorEncerramento.Validar(this))
        {
            return false;
        }
        var anterior = Situacao;
        this.Situacao = Situacao.Encerrada;
        
        RegistrarMovimentacao(TipoMovimentacao.Encerramento, anterior, Situacao, justificativa);

        return true;
    }

    public void Triar(IEstrategiaTriagem estrategia)
    {
        if (Situacao != Situacao.AguardandoTriagem)
            throw new InvalidOperationException("A ocorrência já foi triada.");

        var anterior = Situacao;
        var resultado = estrategia.Executar(this);

        AplicarResultadoTriagem(resultado, anterior);
    }

    private void AplicarResultadoTriagem(ResultadoTriagem resultado, Situacao anterior)
    {
        switch (resultado)
        {
            case ResultadoTriagem.Aceita:
                Situacao = Situacao.EncaminhadaParaExecucao;
                RegistrarMovimentacao(TipoMovimentacao.Triagem, anterior, Situacao);
                break;

            case ResultadoTriagem.Vistoria:
                Situacao = Situacao.EncaminhadaParaVistoria;
                RegistrarMovimentacao(TipoMovimentacao.Triagem, anterior, Situacao);
                break;

            case ResultadoTriagem.Recusada:
                if (string.IsNullOrWhiteSpace(Descricao))
                    throw new InvalidOperationException("Ocorrência recusada não pode ser vazia.");
                Situacao = Situacao.Recusada;
                RegistrarMovimentacao(TipoMovimentacao.Triagem, anterior, Situacao);
                break;

            case ResultadoTriagem.Duplicada:
                if (string.IsNullOrWhiteSpace(ProtocoloRelacionado))
                    throw new InvalidOperationException("Duplicada exige protocolo relacionado.");
                if (ProtocoloRelacionado == Protocolo)
                    throw new InvalidOperationException("Não pode duplicar com o mesmo protocolo.");
                Situacao = Situacao.Duplicada;
                RegistrarMovimentacao(TipoMovimentacao.Triagem, anterior, Situacao);
                break;

            default:
                throw new InvalidOperationException("Resultado de triagem inválido.");
        }
    }

    private void VerificarSeTerminal()
    {
        if (EhTerminal)
            throw new InvalidOperationException("Ocorrência está em estado terminal.");
    }

    public void CalcularPrioridade(ICalcularPrioridade calcularPrioridade)
    {
        this.NivelPrioridade = calcularPrioridade.Calcular(this);
    }

    public string GerarResumo(IGeradorResumos<Ocorrencia> geradorResumos)
    {
        return geradorResumos.Gerar(this);
    }
}
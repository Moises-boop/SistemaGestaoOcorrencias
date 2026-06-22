using SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.ValueObject;
using SistemaGestaoOcorrencias.Domain.Utils.Enums;
using SistemaGestaoOcorrencias.Domain.Interfaces;
using SistemaGestaoOcorrencias.Domain.Utils;

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
        IEstrategiaTriagem<Ocorrencia> estrategiaTriagem)
    {
        Descricao = ValidarTexto.ValidarTexto(descricao, "Descrição é obrigatória. ");
        Protocolo = ValidarTexto.ValidarTexto(protocolo, "Protocolo é obrigatório. ");
        Bairro = ValidarObjeto.ValidarObjeto(bairro, "Bairro é obrigatório. ");
        DataAbertura = ValidarData.ValidarData(dataAbertura, DateTime.Now, DateTime.Now, "Data de abertura é inválida.");
        SetorResponsavel = ValidarObjeto.ValidarObjeto(setorResponsavel, "Setor responsável é obrigatório. ");
        ProtocoloRelacionado = protocoloRelacionado;
        Situacao = Situacao.AguardandoTriagem;

        CalcularPrioridade(estrategiaPrioridade);
        Triar(estrategiaTriagem);
    }

    public void AdicionarMovimentacao(Movimentacao movimentacao)
    {
        if (_historicoMovimentacoes.Contains(movimentacao))
        {
            throw new InvalidOperationException("Esta movimentação já foi adicionada.");
        }

        _historicoMovimentacoes.Add(movimentacao);
    }

    public void RegistrarImpedimento(Impedimento impedimento)
    {
        VerificarSeEncerrada();

        if (_impedimentos.Contains(impedimento))
        {
            throw new InvalidOperationException("Este impedimento já foi registrado.");
        }

        _impedimentos.Add(impedimento);
    }

    public void RegistrarVistoria(Vistoria vistoria)
    {
        VerificarSeEncerrada();

        if (Situacao != Situacao.EncaminhadaParaVistoria)
            throw new InvalidOperationException("A ocorrência precisa estar encaminhada para vistoria.");

        if (vistoria.Aprovada)
            Situacao = Situacao.EncaminhadaParaExecucao;
        

        Vistoria = vistoria;
    }

    public void Executar()
    {
        VerificarSeEncerrada();

        if (ExigeVistoria && Vistoria == null)
            throw new InvalidOperationException("A vistoria ainda está pendente.");

        if (_impedimentos.Any(i => !i.Resolvido))
            throw new InvalidOperationException("Existem impedimentos pendentes.");
        
        if (Situacao != Situacao.EncaminhadaParaExecucao)
            throw new InvalidOperationException("A ocorrência precisa estar encaminhada para execução.");

        Situacao = Situacao.EmExecucao;
    }

    public bool Encerrar(IValidadorEncerramento validadorEncerramento, string justificativa)
    {
        VerificarSeEncerrada();

        Justificativa = ValidarTexto.ValidarTexto(justificativa, "Justificativa de encerramento é obrigatória.");

        if (!validadorEncerramento.Validar(this))
        {
            return false;
        }

        this.Situacao = Situacao.Encerrada;
        return true;
    }

    public void Triar(IEstrategiaTriagem estrategia)
    {
        if (Situacao != Situacao.AguardandoTriagem)
            throw new InvalidOperationException("A ocorrência já foi triada.");

        var resultado = estrategia.Executar(this);

        AplicarResultadoTriagem(resultado);
    }

    private void AplicarResultadoTriagem(ResultadoTriagem resultado)
    {
        switch (resultado)
        {
            case ResultadoTriagem.Aceita:
                Situacao = Situacao.EncaminhadaParaExecucao;
                break;

            case ResultadoTriagem.Vistoria:
                Situacao = Situacao.EncaminhadaParaVistoria;
                break;

            case ResultadoTriagem.Recusada:
                Situacao = Situacao.Recusada;
                break;

            case ResultadoTriagem.Duplicada:
                Situacao = Situacao.Duplicada;
                break;

            default:
                throw new InvalidOperationException("Resultado de triagem inválido.");
        }
    }

    private void VerificarSeEncerrada()
    {
        if (Situacao == Situacao.Encerrada)
            throw new InvalidOperationException("Uma ocorrência encerrada não pode ser alterada.");
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
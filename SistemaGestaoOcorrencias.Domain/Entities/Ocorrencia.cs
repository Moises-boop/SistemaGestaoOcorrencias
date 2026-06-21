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
    public string? Justificativa { get; protected set; }
    public Setor SetorResponsavel { get; protected set; }
    public string? ProtocoloRelacionado { get; }

    private readonly List<Movimentacao> _historicoMovimentacoes = new();
    private readonly List<Impedimento> _impedimentos = new();

    public IReadOnlyCollection<Movimentacao> HistoricoMovimentacoes => _historicoMovimentacoes.AsReadOnly();
    public IReadOnlyCollection<Impedimento> Impedimentos => _impedimentos.AsReadOnly();

    public Ocorrencia(
        string descricao, 
        string protocolo, 
        Bairro bairro, 
        DateTime dataAbertura, 
        Setor setorResponsavel, 
        string? protocoloRelacionado,
        ICalcularPrioridade estrategiaPrioridade,
        IEstrategiaTriagem<Ocorrencia> estrategiaTriagem)
    {
        Descricao = Validacao.ValidarTexto(descricao, "Descrição é obrigatória. ");
        Protocolo = Validacao.ValidarTexto(protocolo, "Protocolo é obrigatório. ");
        Bairro = ValidarObjeto.ValidarObjeto(bairro, "Bairro é obrigatório. ");
        DataAbertura = ValidarData.ValidarData(dataAbertura, DateTime.Now, DateTime.Now, "Data de abertura é inválida.");
        SetorResponsavel = ValidarObjeto.ValidarObjeto(setorResponsavel, "Setor responsável é obrigatório. ");
        ProtocoloRelacionado = protocoloRelacionado;

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
        if (_impedimentos.Contains(impedimento))
        {
            throw new InvalidOperationException("Este impedimento já foi registrado.");
        }

        _impedimentos.Add(impedimento);
    }

    public bool Encerrar(IValidadorEncerramento validadorEncerramento, string justificativa)
    {
        Justificativa = Validacao.ValidarTexto(justificativa, "Justificativa de encerramento é obrigatória.");

        if (!validadorEncerramento.Validar(this))
        {
            return false;
        }

        this.Situacao = Situacao.Encerrada;
        return true;
    }

    public void Triar(IEstrategiaTriagem<Ocorrencia> estrategiaTriagem)
    {
        this.Situacao = estrategiaTriagem.Triar(this);
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
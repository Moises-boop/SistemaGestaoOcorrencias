using SistemaGestaoOcorrencias.Domain.Interfaces;
using SistemaGestaoOcorrencias.Domain.ValueObject;

namespace SistemaGestaoOcorrencias.Domain.Entities.Ocorrencias;

public class OcorrenciaSemaforo : Ocorrencia
{
    public bool SemaforoApagado {get; }

    public OcorrenciaSemaforo(
        string descricao,
        string protocolo,
        Bairro bairro,
        DateTime dataAbertura,
        Setor setorResponsavel,
        string? protocoloRelacionado,
        bool semaforoApagado,
        ICalcularPrioridade estrategiaPrioridade,
        IEstrategiaTriagem estrategiaTriagem)
        : base(
            descricao,
            protocolo,
            bairro,
            dataAbertura,
            setorResponsavel,
            protocoloRelacionado,
            estrategiaPrioridade,
            estrategiaTriagem)
    {
        SemaforoApagado = semaforoApagado;

        ExigeVistoria = false;
    }
}
using SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.ValueObject;
using SistemaGestaoOcorrencias.Domain.Interfaces;

namespace SistemaGestaoOcorrencias.Domain.Entities.Ocorrencias;

public class OcorrenciaViaDanificada : Ocorrencia
{
    public OcorrenciaViaDanificada(
        string descricao,
        string protocolo,
        Bairro bairro,
        DateTime dataAbertura,
        Setor setorResponsavel,
        string? protocoloRelacionado,
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
        ExigeVistoria = true;
    }
}
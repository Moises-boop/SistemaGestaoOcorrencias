using SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.Interfaces;
using SistemaGestaoOcorrencias.Domain.ValueObject;

namespace SistemaGestaoOcorrencias.Domain.Entities.Ocorrencias;

public class OcorrenciaIluminacao : Ocorrencia
{
    public OcorrenciaIluminacao(
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
        ExigeVistoria = false;
    }
}
using SistemaGestaoOcorrencias.Domain.Interfaces;
using SistemaGestaoOcorrencias.Domain.ValueObject;

namespace SistemaGestaoOcorrencias.Domain.Entities.Ocorrencias;

public class OcorrenciaArvore : Ocorrencia
{
    public bool RiscoDeQuedaImediato { get; }

    public OcorrenciaArvore(
        string descricao,
        string protocolo,
        Bairro bairro,
        DateTime dataAbertura,
        Setor setorResponsavel,
        string? protocoloRelacionado,
        bool riscoDeQuedaImediato,
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
        RiscoDeQuedaImediato = riscoDeQuedaImediato;
    }

    protected override bool DeterminarExigeVistoria() => true;
}
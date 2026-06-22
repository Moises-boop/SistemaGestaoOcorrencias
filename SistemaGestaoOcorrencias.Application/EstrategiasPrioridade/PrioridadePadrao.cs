using SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.Utils.Enums;

namespace SistemaGestaoOcorrencias.Application.EstrategiasPrioridade;

public class PrioridadePadrao : ICalcularPrioridade
{
    public NivelPrioridadeEnum Calcular(Ocorrencia ocorrencia)
    {
        if (ocorrencia.ExigeVistoria && ocorrencia.Vistoria == null)
            return NivelPrioridadeEnum.Urgente;
            
        if (ocorrencia.ExigeVistoria)
            return NivelPrioridadeEnum.Alta;

        if (ocorrencia.ProtocoloRelacionado != null)
            return NivelPrioridadeEnum.Media;

        return NivelPrioridadeEnum.Baixa;
    }
}
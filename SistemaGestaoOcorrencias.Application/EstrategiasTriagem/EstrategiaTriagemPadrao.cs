using SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.Interfaces;
using SistemaGestaoOcorrencias.Domain.Utils.Enums;

namespace SistemaGestaoOcorrencias.Application.EstrategiasTriagem;

public class EstrategiaTriagemPadrao : IEstrategiaTriagem
{
    public ResultadoTriagem Executar(Ocorrencia ocorrencia)
    {
        if (!string.IsNullOrWhiteSpace(ocorrencia.ProtocoloRelacionado))
            return ResultadoTriagem.Duplicada;

        if (ocorrencia.ExigeVistoria)
            return ResultadoTriagem.Vistoria;

        return ResultadoTriagem.Aceita;
    }
}
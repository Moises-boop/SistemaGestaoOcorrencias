using SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.Interfaces;
using SistemaGestaoOcorrencias.Domain.Utils.Enums;

namespace SistemaGestaoOcorrencias.Application.EstrategiasTriagem;

public class EstrategiaTriagemRigorosa : IEstrategiaTriagem
{
    public ResultadoTriagem Executar(Ocorrencia ocorrencia)
    {
        if (ocorrencia.Descricao.Length < 20)
            return ResultadoTriagem.Recusada;

        if (!string.IsNullOrWhiteSpace(ocorrencia.ProtocoloRelacionado))
            return ResultadoTriagem.Duplicada;
            
        if (ocorrencia.ExigeVistoria)
            return ResultadoTriagem.Vistoria;

        return ResultadoTriagem.Aceita;
    }
}
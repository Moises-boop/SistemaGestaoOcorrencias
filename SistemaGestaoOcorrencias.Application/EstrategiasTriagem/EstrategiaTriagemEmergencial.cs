using SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.Interfaces;
using SistemaGestaoOcorrencias.Domain.Utils.Enums;

namespace SistemaGestaoOcorrencias.Application.EstrategiasTriagem;

public class EstrategiaTriagemEmergencial : IEstrategiaTriagem
{
    public ResultadoTriagem Executar(Ocorrencia ocorrencia)
    {
        return ResultadoTriagem.Aceita;
    }
}
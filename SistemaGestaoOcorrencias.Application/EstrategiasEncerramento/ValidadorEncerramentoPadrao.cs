using SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.Interfaces;
using SistemaGestaoOcorrencias.Domain.Utils.Enums;

namespace SistemaGestaoOcorrencias.Application.EstrategiasEncerramento;

public class ValidadorEncerramentoPadrao : IValidadorEncerramento
{
    public bool Validar(Ocorrencia ocorrencia)
    {
        if (ocorrencia.Situacao == Situacao.Encerrada)
            return false;

        if (string.IsNullOrWhiteSpace(ocorrencia.Justificativa))
            return false;

        if (ocorrencia.ExigeVistoria && ocorrencia.Vistoria == null)
            return false;

        if (ocorrencia.Situacao != Situacao.EmExecucao)
            return false;

        return true;
    }
}
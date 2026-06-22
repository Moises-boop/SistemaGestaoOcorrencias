namespace SistemaGestaoOcorrencias.Domain.Utils.Enums;

public enum Situacao
{
    AguardandoTriagem = 1,
    Recusada = 2,
    Duplicada = 3,
    EncaminhadaParaVistoria = 4,
    EncaminhadaParaExecucao = 5,
    EmExecucao = 6,
    Encerrada = 7
}

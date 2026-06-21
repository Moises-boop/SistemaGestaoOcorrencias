namespace SistemaGestaoOcorrencias.Domain.Interfaces
{
    public interface ICalcularPrioridade
    {
        NivelPrioridadeEnum Calcular(Ocorrencia ocorrencia);
    }
}
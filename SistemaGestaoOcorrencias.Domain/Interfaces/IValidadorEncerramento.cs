namespace SistemaGestaoOcorrencias.Domain.Interfaces
{
    public interface IValidadorEncerramento
    {
        bool Validar(Ocorrencia ocorrencia);
    }
}
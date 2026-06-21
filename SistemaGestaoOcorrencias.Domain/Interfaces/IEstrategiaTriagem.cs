namespace SistemaGestaoOcorrencias.Domain.Interfaces;

public interface IEstrategiaTriagem<T>
{
    void Triar(SistemaGestaoOcorrencias.Domain.Entities.Ocorrencia item);
}

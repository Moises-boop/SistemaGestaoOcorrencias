using SistemaGestaoOcorrencias.Domain.Entities;

namespace SistemaGestaoOcorrencias.Domain.Interfaces;

public interface IGeradorResumos<T>
{
    string Gerar(T entidade);
}
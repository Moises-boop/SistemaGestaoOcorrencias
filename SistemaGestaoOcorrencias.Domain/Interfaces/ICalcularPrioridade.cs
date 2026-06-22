using SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.Utils.Enums;

namespace SistemaGestaoOcorrencias.Domain.Interfaces;

public interface ICalcularPrioridade
{
    NivelPrioridadeEnum Calcular(Ocorrencia ocorrencia);
}

using SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.Utils.Enums;

namespace SistemaGestaoOcorrencias.Domain.Interfaces;

public interface IEstrategiaTriagem
{
    ResultadoTriagem Executar(Ocorrencia ocorrencia);
}

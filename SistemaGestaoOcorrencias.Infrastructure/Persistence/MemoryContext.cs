using SistemaGestaoOcorrencias.Domain.Entities;

namespace SistemaGestaoOcorrencias.Infrastructure.Persistence
{
    public class MemoryContext
    {
        public List<Ocorrencia> Ocorrencias { get; } = new List<Ocorrencia>();
    }
}

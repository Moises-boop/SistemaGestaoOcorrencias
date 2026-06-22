using SistemaGestaoOcorrencias.Infrastructure.Persistence;
using SistemaGestaoOcorrencias.Domain.Repositories;

namespace SistemaGestaoOcorrencias.Infrastructure.Repositories
{
    public class OcorrenciaMemoryRepository : IOcorrenciaRepository
    {
        private readonly MemoryContext _context;

        public OcorrenciaMemoryRepository(MemoryContext context)
        {
            _context = context;
        }

        public void Adicionar(Ocorrencia ocorrencia)
        {
            _context.Ocorrencias.Add(ocorrencia);
        }

        public List<Ocorrencia> ObterTodos()
        {
            return _context.Ocorrencias;
        }
    }
}
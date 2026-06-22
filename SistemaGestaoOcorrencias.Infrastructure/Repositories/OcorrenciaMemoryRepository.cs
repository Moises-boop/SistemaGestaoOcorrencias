using SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.MemoryInterfaces;
using SistemaGestaoOcorrencias.Infrastructure.Persistence;

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
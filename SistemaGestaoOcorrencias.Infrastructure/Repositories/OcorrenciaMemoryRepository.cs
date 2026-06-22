using SistemaGestaoOcorrencias.Infrastructure.Persistence;
using SistemaGestaoOcorrencias.Domain.MemoryInterfaces;

namespace SistemaGestaoOcorrencias.Infrastructure.Repositories
{
    public class MemoryContext : IOcorrenciaRepository
    {
        private readonly MemoryContext _context;

        public MemoryContext(MemoryContext context)
        {
            _context = context;
        }

        public void Adicionar(Ocorrencia ocorrencia)
        {
            _context.Adicionar(ocorrencia);
        }

        public List<Ocorrencia> ObterTodos()
        {
            return _context.Ocorrencias;
        }
    }
}
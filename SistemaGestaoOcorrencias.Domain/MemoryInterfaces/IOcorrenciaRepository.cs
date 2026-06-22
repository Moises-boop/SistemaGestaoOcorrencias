namespace SistemaGestaoOcorrencias.Domain.MemoryInterfaces
{
    public interface IOcorrenciaRepository
    {
        void Adicionar(Ocorrencia ocorrencia);
        List<Ocorrencia> ObterTodos();
    }
}
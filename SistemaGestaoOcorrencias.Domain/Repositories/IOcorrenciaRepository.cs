namespace SistemaGestaoOcorrencias.Domain.Repositories
{
    public interface IOcorrenciaRepository
    {
        void Adicionar(Ocorrencia ocorrencia);
        List<Ocorrencia> ObterTodos();
    }
}
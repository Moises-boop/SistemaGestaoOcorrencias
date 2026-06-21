namespace SistemaGestaoOcorrencias.Domain.Entities;

public class Setor
{
    public string IdSetor { get; }
    public string Nome { get; }
    public string Descricao { get; }

    public Setor(string idSetor, string nome, string descricao)
    {
        IdSetor = Validacao.ValidarTexto(idSetor, "ID do setor é obrigatório.");
        Nome = Validacao.ValidarTexto(nome, "Nome do setor é obrigatório.");
        Descricao = Validacao.ValidarTexto(descricao, "Descrição do setor é obrigatória.");
    }
}
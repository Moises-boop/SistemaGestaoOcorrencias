using SistemaGestaoOcorrencias.Domain.Utils.Validations;

namespace SistemaGestaoOcorrencias.Domain.Entities;

public class Setor
{
    public string IdSetor { get; }
    public string Nome { get; }
    public string Descricao { get; }

    public Setor(string idSetor, string nome, string descricao)
    {
        IdSetor = ValidarTexto.Validar(idSetor, "ID do setor é obrigatório.");
        Nome = ValidarTexto.Validar(nome, "Nome do setor é obrigatório.");
        Descricao = ValidarTexto.Validar(descricao, "Descrição do setor é obrigatória.");
    }
}
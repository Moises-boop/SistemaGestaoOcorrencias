using SistemaGestaoOcorrencias.Domain.Utils.Validations;

namespace SistemaGestaoOcorrencias.Domain.ValueObject;

public record Bairro
{
    public string Nome {get; }

    public Bairro(string nome)
    {
        Nome = ValidarTexto.Validar(nome, "Nome do bairro é obrigatório.");
    }
}
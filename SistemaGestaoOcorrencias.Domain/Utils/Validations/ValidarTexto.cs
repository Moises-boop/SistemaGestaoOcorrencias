namespace SistemaGestaoOcorrencias.Domain.Utils.Validations;

public static class ValidarTexto
{
    public static string Validar(string texto, string mensagem)
    {
        return string.IsNullOrWhiteSpace(texto) ? throw new ArgumentException(mensagem) : texto;
    }
}

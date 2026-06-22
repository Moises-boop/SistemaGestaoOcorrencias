namespace SistemaGestaoOcorrencias.Domain.Utils.Validations;

public static class ValidarObjeto
{
    public static T Validar<T>(T objeto, string mensagem) where T : class
    {
        return objeto ?? throw new ArgumentNullException(mensagem);
    }
}

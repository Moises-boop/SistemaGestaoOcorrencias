namespace SistemaGestaoOcorrencias.Domain.Utils.Validations;

public class ValidarData
{
    public static DateTime ValidarData(DateTime data,
                                       DateTime limiteInicial, 
                                       DateTime limiteFinal, 
                                       string mensagem)
    {
        if (data == default)
            throw new ArgumentException(mensagem);

        if (data < limiteInicial || data > limiteFinal)
            throw new ArgumentOutOfRangeException(mensagem);

        return data;
    }
}
using SistemaGestaoOcorrencias.Domain.Utils.Validations;

namespace SistemaGestaoOcorrencias.Domain.Entities;

public class Vistoria
{
    public DateTime Data {get; }
    public string Responsavel {get; }
    public bool Concluida {get; }

    public Vistoria(DateTime data, string responsavel)
    {
        Data = ValidarData.ValidarData(data, DateTime.MinValue, DateTime.Now, "A data da vistoria é inválida");
        Responsavel = ValidarTexto.ValidarTexto(responsavel);
        Concluida = true;
    }
}
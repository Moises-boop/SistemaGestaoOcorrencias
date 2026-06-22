using SistemaGestaoOcorrencias.Domain.Utils.Validations;

namespace SistemaGestaoOcorrencias.Domain.Entities;

public class Vistoria
{
    public DateTime Data {get; }
    public string Responsavel {get; }
    public string Relatorio {get; }
    public bool Aprovada {get; }

    public Vistoria(DateTime data, string responsavel, string relatorio, bool aprovada)
    {
        Data = ValidarData.Validar(data, DateTime.MinValue, DateTime.Now, "A data da vistoria é inválida");
        Responsavel = ValidarTexto.Validar(responsavel, "Responsável pela vistoria é obrigatório.");
        Relatorio = ValidarTexto.Validar(relatorio, "O relatório da vistoria é obrigatório.");
        Aprovada = aprovada;
    }
}
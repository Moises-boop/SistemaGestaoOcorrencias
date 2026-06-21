using SistemaGestaoOcorrencias.Domain.Enums;

namespace SistemaGestaoOcorrencias.Domain.Entities;

public class Movimentacao
{
    public TipoMovimentacao Tipo {get;}
    public DateTime Data {get;}
    public string? Descricao {get;}

    public Movimentacao (TipoMovimentacao tipo, DateTime data, string? descricao)
    {
        Tipo = tipo;
        Data = data;
        Descricao = descricao;
    }
}
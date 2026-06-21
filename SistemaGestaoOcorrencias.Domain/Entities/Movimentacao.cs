using SistemaGestaoOcorrencias.Domain.Utils.Enums;

namespace SistemaGestaoOcorrencias.Domain.Entities;

public class Movimentacao
{
    public TipoMovimentacao Tipo {get; }
    public Situacao SituacaoAnterior {get; }
    public Situacao SituacaoPosterior {get; }
    public DateTime Data {get; }
    public string? Descricao {get; }

    public Movimentacao (TipoMovimentacao tipo, Situacao situacaoAnterior, Situacao situacaoPosterior, 
                         DateTime data, string? descricao)
    {
        Tipo = tipo;
        SituacaoAnterior = situacaoAnterior;
        SituacaoPosterior = situacaoPosterior;
        Data = data;
        Descricao = descricao;
    }
}
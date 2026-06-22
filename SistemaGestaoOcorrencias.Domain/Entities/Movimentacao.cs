namespace SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.Utils.Enums;
using SistemaGestaoOcorrencias.Domain.Utils.Validations;

public class Movimentacao 
{
    public TipoMovimentacao Tipo {get; }
    public Situacao SituacaoAnterior {get; }
    public Situacao SituacaoPosterior {get; }
    public DateTime Data {get; }
    public string? Descricao {get; }

    public Movimentacao (TipoMovimentacao tipo, 
                         Situacao situacaoAnterior, 
                         Situacao situacaoPosterior, 
                         DateTime data, 
                         string? descricao)
    {
        Tipo = tipo;
        SituacaoAnterior = situacaoAnterior;
        SituacaoPosterior = situacaoPosterior;
        Data = ValidarData.Validar(data, DateTime.MinValue, DateTime.Now, "A data não é válida.");
        Descricao = string.IsNullOrWhiteSpace(descricao)
            ? null
            : ValidarTexto.Validar(descricao, "A descrição é obrigatória.");
    }
}   
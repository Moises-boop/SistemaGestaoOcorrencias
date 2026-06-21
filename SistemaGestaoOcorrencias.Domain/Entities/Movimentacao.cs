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
        Tipo = ValidarObjeto<TipoMovimentacao>(tipo, "Esse tipo de movimentação não é permitido.");
        SituacaoAnterior = ValidarObjeto<Situacao>(situacaoAnterior, "A situação anterior não é válida.");
        SituacaoPosterior = ValidarObjeto<Situacao>(situacaoPosterior, "A situação posterior não é válida.");
        Data = ValidarData(data, DateTime.Now, DateTime.Now, "A data não é válida.");
        Descricao = ValidarTexto(descricao, "A descrição é obrigatória.");
    }
}   
namespace SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.Utils.Enums;

public class Movimentacao
{
    public string Descricao { get; }
    public DateTime DataMovimentacao { get; }
    public Situacao SituacaoAnterior { get; }
    public Situacao SituacaoPosterior { get; }

    public Movimentacao(string descricao, 
                        DateTime dataMovimentacao,
                        Situacao situacaoAnterior, 
                        Situacao situacaoPosterior)
    {
        Descricao = Validacao.ValidarTexto(descricao, "Descrição da movimentação é obrigatória. ");
        DataMovimentacao = Validacao.ValidarData(dataMovimentacao, DateTime.Now, DateTime.Now, "Data da movimentação é inválida. ");
        SituacaoAnterior = ValidarObjeto.ValidarObjeto(situacaoAnterior, "Situação anterior é obrigatória. ");
        SituacaoPosterior = ValidarObjeto.ValidarObjeto(situacaoPosterior, "Situação posterior é obrigatória. ");
    }

}
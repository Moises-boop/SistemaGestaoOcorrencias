namespace SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.Utils.Enums;
using SistemaGestaoOcorrencias.Domain.Utils.Validations;
using SistemaGestaoOcorrencias.Domain.Entities.Setor;

public class TriagemDados
{
    public Situacao NovaSituacao { get; }
    public string? Justificativa { get; }
    public DateTime DataTriagem { get; }
    public Setor SetorResponsavel { get; }
    public string ProtocoloRelacionado { get; }

    public TriagemDados(Situacao novaSituacao, string? justificativa, DateTime dataTriagem, Setor setorResponsavel, string protocoloRelacionado)
    {
        NovaSituacao = novaSituacao;
        Justificativa = justificativa;
        DataTriagem = ValidarData(dataTriagem, DateTime.Now, DateTime.Now, "Data de triagem é inválida.");
        SetorResponsavel = ValidarObjeto(setorResponsavel, "Setor responsável é obrigatório.");
        ProtocoloRelacionado = ValidarTexto(protocoloRelacionado, "Protocolo relacionado é obrigatório.");
    }
}
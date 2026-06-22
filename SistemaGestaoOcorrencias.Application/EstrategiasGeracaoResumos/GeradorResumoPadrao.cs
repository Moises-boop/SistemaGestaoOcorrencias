using SistemaGestaoOcorrencias.Domain.Entities;
using System.Text;

namespace SistemaGestaoOcorrencias.Application.EstrategiasGeracaoResumos;

public class GeradorResumoPadrao : IGeradorResumos<Ocorrencia>
{
    public string Gerar(Ocorrencia ocorrencia)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Protocolo: {ocorrencia.Protocolo}");
        sb.AppendLine($"Descrição: {ocorrencia.Descricao}");
        sb.AppendLine($"Bairro: {ocorrencia.Bairro}");
        sb.AppendLine($"Prioridade: {ocorrencia.NivelPrioridade}");
        sb.AppendLine($"Situação: {ocorrencia.Situacao}");

        if (ocorrencia.ExigeVistoria)
            sb.AppendLine("Exige Vistoria");
        if (ocorrencia.Vistoria != null)
            sb.AppendLine($"Responsável pela Vistoria: {ocorrencia.Vistoria.Responsavel}");

        return sb.ToString();
    }
}
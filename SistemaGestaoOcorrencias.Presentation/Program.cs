using SistemaGestaoOcorrencias.Application.EstrategiasTriagem;
using SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.Entities.Ocorrencias;
using SistemaGestaoOcorrencias.Domain.Utils.Enums;
using SistemaGestaoOcorrencias.Domain.Utils.Validations;
using SistemaGestaoOcorrencias.Domain.Interfaces;
using SistemaGestaoOcorrencias.Application.EstrategiasEncerramento;
using SistemaGestaoOcorrencias.Application.EstrategiasGeracaoResumos;
using SistemaGestaoOcorrencias.Application.EstrategiasPrioridade;
using SistemaGestaoOcorrencias.Domain.ValueObject;

Console.WriteLine("=== SISTEMA DE GESTÃO DE OCORRÊNCIAS ===\n");


Console.WriteLine("\n--- CENÁRIO 1: FLUXO COMPLETO ---");

var setor = new Setor("1", "Obras", "Manutenção urbana");

var ocorrencia1 = new OcorrenciaViaDanificada(
    "Buraco na rua principal",
    "PR-001",
    new Bairro("Centro"),
    DateTime.Now,
    setor,
    null,
    new PrioridadePadrao(),
    new EstrategiaTriagemPadrao()
);

Console.WriteLine($"Criada: {ocorrencia1.Protocolo} | Situação: {ocorrencia1.Situacao}");

ocorrencia1.Triar(new EstrategiaTriagemPadrao());
Console.WriteLine($"Após triagem: {ocorrencia1.Situacao}");

if (ocorrencia1.Situacao == Situacao.EncaminhadaParaVistoria)
{
    ocorrencia1.RegistrarVistoria(
        new Vistoria(DateTime.Now, "Analista de Campo", "Vistoria concluída com sucesso", true)
    );
    Console.WriteLine($"Após vistoria: {ocorrencia1.Situacao}");
}

ocorrencia1.Executar();
Console.WriteLine($"Após execução: {ocorrencia1.Situacao}");

var encerrar1 = ocorrencia1.Encerrar(
    new ValidadorEncerramentoPadrao(),
    "Serviço concluído"
);

Console.WriteLine($"Encerrada: {encerrar1} | Situação final: {ocorrencia1.Situacao}");


// ======================================================================================= //

Console.WriteLine("\n--- CENÁRIO 2: COM VISTORIA ---");

var ocorrencia2 = new OcorrenciaAlagamento(
    "Alagamento na via",
    "PR-002",
    new Bairro("Industrial"),
    DateTime.Now,
    setor,
    null,
    new PrioridadePadrao(),
    new EstrategiaTriagemPadrao()
);

Console.WriteLine($"Criada: {ocorrencia2.Protocolo} | Situação: {ocorrencia2.Situacao}");

ocorrencia2.Triar(new EstrategiaTriagemPadrao());
Console.WriteLine($"Após triagem: {ocorrencia2.Situacao}");

ocorrencia2.RegistrarVistoria(
    new Vistoria(DateTime.Now, "João Silva", "Vistoria realizada, alagamento confirmado", true)
);

Console.WriteLine($"Vistoria registrada | Situação: {ocorrencia2.Situacao}");

ocorrencia2.Executar();
Console.WriteLine($"Após execução: {ocorrencia2.Situacao}");

// ======================================================================================= //
Console.WriteLine("\n--- CENÁRIO 3: RECUSADA ---");

var ocorrencia3 = new OcorrenciaPracaPublica(
    "Solicita inválida",
    "PR-003",
    new Bairro("Centro"),
    DateTime.Now,
    setor,
    null,
    new PrioridadePadrao(),
    new EstrategiaTriagemRigorosa()
);

ocorrencia3.Triar(new EstrategiaTriagemRigorosa());
Console.WriteLine($"Situação final: {ocorrencia3.Situacao}");

// ======================================================================================= //
Console.WriteLine("\n--- CENÁRIO 4: DUPLICADA ---");

var ocorrencia4 = new OcorrenciaDescarteIrregular(
    "Lixo acumulado",
    "PR-004",
    new Bairro("Bairro X"),
    DateTime.Now,
    setor,
    "PR-001",
    new PrioridadePadrao(),
    new EstrategiaTriagemPadrao()
);

ocorrencia4.Triar(new EstrategiaTriagemPadrao());
Console.WriteLine($"Situação final: {ocorrencia4.Situacao}");
Console.WriteLine($"Protocolo relacionado: {ocorrencia4.ProtocoloRelacionado}");

// ======================================================================================= //
Console.WriteLine("\n--- CENÁRIO 5: ENCERRAMENTO INVÁLIDO ---");

var ocorrencia5 = new OcorrenciaViaDanificada(
    "Asfalto ruim",
    "PR-005",
    new Bairro("Zona Sul"),
    DateTime.Now,
    setor,
    null,
    new PrioridadePadrao(),
    new EstrategiaTriagemPadrao()
);

ocorrencia5.Triar(new EstrategiaTriagemPadrao());

try
{
    var resultado = ocorrencia5.Encerrar(
        new ValidadorEncerramentoPadrao(),
        ""
    );

    Console.WriteLine($"Encerramento realizado: {resultado}");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao encerrar: {ex.Message}");
}


// ======================================================================================= //
Console.WriteLine("\n--- CENÁRIO 6: TROCA DE ESTRATÉGIA ---");

var ocorrencia6 = new OcorrenciaAlagamento(
    "Rua alagada",
    "PR-006",
    new Bairro("Nordeste"),
    DateTime.Now,
    setor,
    null,
    new PrioridadePadrao(),
    new EstrategiaTriagemEmergencial()
);

ocorrencia6.Triar(new EstrategiaTriagemEmergencial());
Console.WriteLine($"Estratégia EMERGENCIAL: {ocorrencia6.Situacao}");

var ocorrencia7 = new OcorrenciaAlagamento(
    "Rua alagada",
    "PR-007",
    new Bairro("Nordeste"),
    DateTime.Now,
    setor,
    null,
    new PrioridadePadrao(),
    new EstrategiaTriagemRigorosa()
);

ocorrencia7.Triar(new EstrategiaTriagemRigorosa());
Console.WriteLine($"Estratégia RÍGIDA: {ocorrencia7.Situacao}");


Console.WriteLine("\n=== FIM DA DEMONSTRAÇÃO ===");
# Pergunta

Dado esse enunciado:
[...]
E o código-fonte:
[...]
Me ajude a montar um Program.cs para demonstração dos cenários, com boas práticas de organização e demonstrações de polimorfismo.

# Resposta

A ideia aqui é: o Program.cs não é “lugar de regra”, é roteiro de demonstração dos casos de uso. Ele precisa ser linear, legível e com saída clara para defesa.

Vou te entregar um modelo completo, já organizado para os 6 cenários obrigatórios.

📍 Estrutura base do Program.cs
using SistemaGestaoOcorrencias.Application.EstrategiasTriagem;
using SistemaGestaoOcorrencias.Domain.Entities;
using SistemaGestaoOcorrencias.Domain.Entities.Ocorrencias;
using SistemaGestaoOcorrencias.Domain.Entities.Setor;
using SistemaGestaoOcorrencias.Domain.Utils.Enums;

Console.WriteLine("=== SISTEMA DE GESTÃO DE OCORRÊNCIAS ===\n");
📍 CENÁRIO 1 — Fluxo completo (aceita → execução → encerramento)
Console.WriteLine("\n--- CENÁRIO 1: FLUXO COMPLETO ---");

var setor = new Setor("1", "Obras", "Manutenção urbana");

var ocorrencia1 = new OcorrenciaViaDanificada(
    "Buraco na rua principal",
    "PR-001",
    new Bairro("Centro"),
    DateTime.Now,
    setor,
    null,
    new EstrategiaTriagemPadrao()
);

Console.WriteLine($"Criada: {ocorrencia1.Protocolo} | Situação: {ocorrencia1.Situacao}");

ocorrencia1.Executar();
Console.WriteLine($"Após execução: {ocorrencia1.Situacao}");

var encerrar1 = ocorrencia1.Encerrar(
    new ValidadorEncerramentoPadrao(),
    "Serviço concluído"
);

Console.WriteLine($"Encerrada: {encerrar1} | Situação final: {ocorrencia1.Situacao}");
📍 CENÁRIO 2 — Exige vistoria antes da execução
Console.WriteLine("\n--- CENÁRIO 2: COM VISTORIA ---");

var ocorrencia2 = new OcorrenciaAlagamento(
    "Alagamento na via",
    "PR-002",
    new Bairro("Industrial"),
    DateTime.Now,
    setor,
    null,
    new EstrategiaTriagemPadrao()
);

Console.WriteLine($"Criada: {ocorrencia2.Protocolo} | Situação: {ocorrencia2.Situacao}");

ocorrencia2.RegistrarVistoria(
    new Vistoria(DateTime.Now, "Engenheiro Civil")
);

Console.WriteLine($"Vistoria registrada | Situação: {ocorrencia2.Situacao}");

ocorrencia2.Executar();
Console.WriteLine($"Após execução: {ocorrencia2.Situacao}");
📍 CENÁRIO 3 — Recusada
Console.WriteLine("\n--- CENÁRIO 3: RECUSADA ---");

var ocorrencia3 = new OcorrenciaPracaPublica(
    "",
    "PR-003",
    new Bairro("Centro"),
    DateTime.Now,
    setor,
    null,
    new EstrategiaTriagemRigida()
);

Console.WriteLine($"Situação final: {ocorrencia3.Situacao}");
📍 CENÁRIO 4 — Duplicada
Console.WriteLine("\n--- CENÁRIO 4: DUPLICADA ---");

var ocorrencia4 = new OcorrenciaDescarteIrregular(
    "Lixo acumulado",
    "PR-004",
    new Bairro("Bairro X"),
    DateTime.Now,
    setor,
    "PR-001",
    new EstrategiaTriagemPadrao()
);

Console.WriteLine($"Situação final: {ocorrencia4.Situacao}");
Console.WriteLine($"Protocolo relacionado: {ocorrencia4.ProtocoloRelacionado}");
📍 CENÁRIO 5 — Tentativa inválida de encerramento
Console.WriteLine("\n--- CENÁRIO 5: ENCERRAMENTO INVÁLIDO ---");

var ocorrencia5 = new OcorrenciaViaDanificada(
    "Asfalto ruim",
    "PR-005",
    new Bairro("Zona Sul"),
    DateTime.Now,
    setor,
    null,
    new EstrategiaTriagemPadrao()
);

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
📍 CENÁRIO 6 — Troca de estratégia (polimorfismo real)
Console.WriteLine("\n--- CENÁRIO 6: TROCA DE ESTRATÉGIA ---");

var ocorrencia6 = new OcorrenciaAlagamento(
    "Rua alagada",
    "PR-006",
    new Bairro("Nordeste"),
    DateTime.Now,
    setor,
    null,
    new EstrategiaTriagemEmergencial()
);

Console.WriteLine($"Estratégia EMERGENCIAL: {ocorrencia6.Situacao}");

var ocorrencia7 = new OcorrenciaAlagamento(
    "Rua alagada",
    "PR-007",
    new Bairro("Nordeste"),
    DateTime.Now,
    setor,
    null,
    new EstrategiaTriagemRigida()
);

Console.WriteLine($"Estratégia RÍGIDA: {ocorrencia7.Situacao}");
📍 7. PRINT FINAL (importante para defesa)
Console.WriteLine("\n=== FIM DA DEMONSTRAÇÃO ===");
📍 8. O que esse Program.cs prova na defesa

Isso aqui cobre diretamente o enunciado:

✔ 6 cenários obrigatórios
✔ uso de strategy (triagem)
✔ polimorfismo real (ocorrências diferentes)
✔ regras de negócio aplicadas
✔ transições de estado corretas
✔ validações de erro demonstradas
📍 9. O que normalmente melhora ainda mais a nota (opcional)

Se quiser elevar nível:

imprimir histórico de movimentações no final
mostrar nível de prioridade
mostrar impedimentos

Exemplo:

Console.WriteLine($"Movimentações: {ocorrencia1.HistoricoMovimentacoes.Count}");
📍 Conclusão

Esse Program.cs:

✔ cumpre o enunciado
✔ demonstra arquitetura
✔ prova polimorfismo
✔ facilita defesa oral

# O que aprendi:

Aprendi sobre os cenários obrigatórios e como posso fazer validações na estrutura atual.

# IA utilizada

chat-GPT versão gratuita
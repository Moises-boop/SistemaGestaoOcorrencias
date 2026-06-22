# Sistema de Gestão de Ocorrências

Este projeto implementa um sistema em C# para gerenciar ocorrências urbanas, com foco em triagem, priorização, acompanhamento, vistoria, execução, encerramento e histórico de movimentações.

A solução foi organizada em camadas para separar claramente o domínio, as regras de aplicação, a infraestrutura simulada e a apresentação em console.

## Índice

- [1. Objetivo do projeto](#1-objetivo-do-projeto)
- [2. O que foi implementado](#2-o-que-foi-implementado)
  - [2.1 Domínio](#21-domínio)
  - [2.2 Aplicação](#22-aplicação)
  - [2.3 Infraestrutura](#23-infraestrutura)
  - [2.4 Apresentação](#24-apresentação)
- [3. Arquitetura da solução](#3-arquitetura-da-solução)
- [4. Estrutura de pastas atual](#4-estrutura-de-pastas-atual)
- [5. Como executar o projeto](#5-como-executar-o-projeto)
- [6. Fluxo de uso demonstrado](#6-fluxo-de-uso-demonstrado)
- [7. Regras principais cobertas](#7-regras-principais-cobertas)
- [8. Observações importantes](#8-observações-importantes)
- [9. Documentação complementar](#9-documentação-complementar)
- [10. Validação do projeto](#10-validação-do-projeto)
- [11. Autores](#11-autores)

---

## 1. Objetivo do projeto

O sistema simula o fluxo de uma ocorrência registrada em um centro de operações urbanas, incluindo:

- cadastro da ocorrência;
- triagem inicial;
- definição de prioridade;
- registro de impedimentos;
- vistoria quando necessária;
- execução do atendimento;
- encerramento com validação de regras;
- manutenção do histórico de movimentações.

---

## 2. O que foi implementado

### 2.1 Domínio

O projeto principal do domínio concentra as entidades, regras e objetos de valor mais importantes.

#### Entidades principais

- `Ocorrencia` (classe abstrata): representa a base comum para todas as ocorrências.
- `OcorrenciaAlagamento`, `OcorrenciaArvore`, `OcorrenciaDescarteIrregular`, `OcorrenciaIluminacao`, `OcorrenciaPracaPublica`, `OcorrenciaSemaforo`, `OcorrenciaViaDanificada`: tipos específicos de ocorrências.
- `Setor`: representa o setor responsável pelo atendimento.
- `Vistoria`: registra informação técnica da vistoria.
- `Movimentacao`: representa eventos do histórico da ocorrência.
- `Impedimento`: registra bloqueios ou condições que impedem o andamento.

#### Objetos de valor e enums

- `Bairro`: valor que identifica o bairro da ocorrência.
- `Situacao`: estados possíveis da ocorrência.
- `TipoMovimentacao`: tipos de eventos registrados no histórico.
- `NivelPrioridadeEnum`: níveis de prioridade.
- `ResultadoTriagem`: possíveis resultados da triagem.
- `TipoImpedimento`: tipos de impedimentos suportados.

#### Regras de negócio no domínio

A base `Ocorrencia` garante validações e estados consistentes, como:

- impedimento de alteração em ocorrências encerradas;
- bloqueio de execução quando há vistoria pendente;
- validação do histórico de movimentações;
- regras para triagem e encerramento.

---

### 2.2 Aplicação

A camada de aplicação implementa comportamentos variáveis por meio de interfaces e estratégias.

#### Estratégias de triagem

- `EstrategiaTriagemPadrao`
- `EstrategiaTriagemRigorosa`
- `EstrategiaTriagemEmergencial`

Essas estratégias alteram o fluxo da triagem sem mudar a lógica central da entidade.

#### Estratégias de prioridade

- `PrioridadePadrao`: calcula a prioridade da ocorrência com base em vistoria, duplicidade e outros sinais.

#### Validação de encerramento

- `ValidadorEncerramentoPadrao`: verifica se a ocorrência está em condições válidas para ser encerrada.

#### Geração de resumo

- `GeradorResumoPadrao`: gera um texto com dados principais da ocorrência.

---

### 2.3 Infraestrutura

A camada de infraestrutura simula persistência em memória.

- `MemoryContext`: armazena as ocorrências em lista em memória.
- `OcorrenciaMemoryRepository`: implementa o repositório para acessar e incluir ocorrências.
- `DependencyInjection`: registra serviços da infraestrutura com injeção de dependência.

---

### 2.4 Apresentação

A apresentação é feita por um console (`Program.cs`), que demonstra cenários reais de uso do sistema.

Os cenários executados são:

1. fluxo completo com aceitação, vistoria, execução e encerramento;
2. ocorrência com necessidade de vistoria;
3. ocorrência recusada;
4. ocorrência duplicada;
5. tentativa de encerramento inválido;
6. troca de estratégia de triagem sem alterar o domínio principal.

---

## 3. Arquitetura da solução

A solução segue uma separação em camadas:

| Camada | Projeto | Responsabilidade |
|---|---|---|
| Domínio | `SistemaGestaoOcorrencias.Domain` | Entidades, regras, validações e enums |
| Aplicação | `SistemaGestaoOcorrencias.Application` | Estratégias e regras processuais |
| Infraestrutura | `SistemaGestaoOcorrencias.Infrastructure` | Repositórios em memória e DI |
| Apresentação | `SistemaGestaoOcorrencias.Presentation` | Console demo |

---

## 4. Estrutura de pastas atual

```text
.
├── docs/
│   ├── ENUNCIADO.md
│   ├── MODELAGEM_ARQUITETURA.md
│   ├── REGRAS_DE_NEGOCIO.md
│   └── ai_logs/
│       ├── instructions.md
│       ├── session_moises_arquitetura-inicial-do-sistema.md
│       ├── session_moises_implementacao-documentacao-pastas.md
│       ├── session_moises_implementacao-persistencia-memoria.md
│       ├── session_nilseo_correcao_final_codigo.md
│       ├── session_nilseo_exemplos_program.md
│       └── session_nilseo_verificacao_construtor.md
├── SistemaGestaoOcorrencias.Application/
│   ├── EstrategiasEncerramento/
│   ├── EstrategiasGeracaoResumos/
│   ├── EstrategiasPrioridade/
│   └── EstrategiasTriagem/
├── SistemaGestaoOcorrencias.Domain/
│   ├── Entities/
│   ├── Interfaces/
│   ├── MemoryInterfaces/
│   ├── Repositories/
│   ├── Utils/
│   │   ├── Enums/
│   │   └── Validations/
│   └── ValueObjects/
├── SistemaGestaoOcorrencias.Infrastructure/
│   ├── DependencyInjection/
│   ├── Persistence/
│   └── Repositories/
└── SistemaGestaoOcorrencias.Presentation/
    └── Program.cs
```

---

## 5. Como executar o projeto

### Pré-requisitos

- .NET SDK instalado
- terminal com acesso ao projeto

### Build da solução

Na raiz do repositório, execute:

```bash
dotnet build SistemaGestaoOcorrencias.sln
```

### Execução da aplicação

Para executar a demonstração em console:

```bash
dotnet run --project SistemaGestaoOcorrencias.Presentation
```

Também é possível rodar diretamente dentro da pasta da apresentação:

```bash
cd SistemaGestaoOcorrencias.Presentation
dotnet run
```

---

## 6. Fluxo de uso demonstrado

O arquivo principal da apresentação cria instâncias de ocorrências e mostra como o sistema reage a cada situação.

Exemplo resumido do fluxo:

1. criação da ocorrência;
2. triagem;
3. encaminhamento para vistoria ou execução;
4. registro da vistoria;
5. execução;
6. encerramento.

Os cenários também mostram o que acontece quando a regra não é respeitada, como no caso de encerramento inválido.

---

## 7. Regras principais cobertas

O sistema busca respeitar regras como:

- ocorrência precisa ter descrição, bairro e protocolo;
- prioridade precisa existir;
- triagem é obrigatória antes do encaminhamento/execução/encerramento;
- ocorrências recusadas e duplicadas têm tratamento específico;
- encerramento exige condição válida;
- ocorrências encerradas não podem mais ser alteradas.

---

## 8. Observações importantes

- A solução usa uma persistência simulada em memória, o que é adequado para demonstração e testes locais.
- A apresentação é voltada para mostrar o comportamento do sistema, não para uma interface gráfica completa.
- A documentação adicional em `docs/` descreve o enunciado, a modelagem e as regras de negócio.

---

## 9. Documentação complementar

A pasta `docs` contém material importante para entender o contexto do projeto:

- `docs/ENUNCIADO.md`: descrição completa do problema e expectativas da solução.
- `docs/REGRAS_DE_NEGOCIO.md`: conjunto das regras definidas.
- `docs/MODELAGEM_ARQUITETURA.md`: visão da arquitetura escolhida.
- `docs/ai_logs/`: histórico de interações com IA e decisões relacionadas ao projeto.

---

## 10. Validação do projeto

A solução pode ser compilada com o comando abaixo:

```bash
dotnet build SistemaGestaoOcorrencias.sln
```

O projeto foi estruturado para demonstrar separação de responsabilidades e comportamento polimórfico entre camadas.

## 11. Autores

- Moisés Grassi
- Nilseo Cassol

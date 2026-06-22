# Sessão: Implementação de Persistência em Memória

## Pergunta:

Estou desenvolvendo um sistema em C# utilizando arquitetura em camadas. Não pretendo utilizar banco de dados neste momento e gostaria de saber se faz sentido criar uma camada Infrastructure contendo um MemoryContext, repositórios em memória e configuração de Injeção de Dependência.

## Resposta:

Sim. Mesmo sem utilizar banco de dados, é recomendável manter uma camada Infrastructure para centralizar detalhes de persistência e implementação técnica da aplicação.

A persistência em memória pode ser realizada através de um MemoryContext, responsável por armazenar coleções de objetos que simulam tabelas de um banco de dados.

Exemplo:

```csharp
public class MemoryContext
{
    public List<Ocorrencia> Ocorrencias { get; } = new();
}
```

Nesse cenário, a lista de ocorrências funciona como uma tabela em memória, permitindo armazenar e recuperar dados durante a execução da aplicação.

---

## Pergunta:

Nesse caso devo criar um repositório para cada entidade armazenada?

## Resposta:

Sim. O ideal é criar um repositório para cada entidade principal que necessite de operações de persistência.

Exemplo:

```text
IOcorrenciaRepository
OcorrenciaMemoryRepository

IUsuarioRepository
UsuarioMemoryRepository

IProdutoRepository
ProdutoMemoryRepository
```

Cada repositório será responsável por manipular apenas sua respectiva coleção dentro do MemoryContext.

Isso promove separação de responsabilidades e facilita a manutenção do sistema.

---

## Pergunta:

Como seria a implementação do repositório de ocorrências?

## Resposta:

Uma implementação simples seria:

```csharp
public class OcorrenciaMemoryRepository
    : IOcorrenciaRepository
{
    private readonly MemoryContext _context;

    public OcorrenciaMemoryRepository(
        MemoryContext context)
    {
        _context = context;
    }

    public void Adicionar(Ocorrencia ocorrencia)
    {
        _context.Ocorrencias.Add(ocorrencia);
    }

    public List<Ocorrencia> ObterTodos()
    {
        return _context.Ocorrencias;
    }
}
```

O repositório encapsula o acesso aos dados e impede que outras camadas manipulem diretamente as listas do contexto.

---

## Pergunta:

Por que utilizar Injeção de Dependência mesmo sem banco de dados?

## Resposta:

A Injeção de Dependência desacopla a aplicação da implementação concreta do repositório.

Em vez de depender diretamente de:

```csharp
OcorrenciaMemoryRepository
```

a aplicação passa a depender de:

```csharp
IOcorrenciaRepository
```

Isso permite trocar a implementação futuramente sem alterar regras de negócio ou a camada de apresentação.

Por exemplo:

Hoje:

```csharp
services.AddSingleton<
    IOcorrenciaRepository,
    OcorrenciaMemoryRepository>();
```

No futuro:

```csharp
services.AddSingleton<
    IOcorrenciaRepository,
    OcorrenciaSqlRepository>();
```

Toda a aplicação continuará funcionando sem modificações nas camadas superiores.

---

## Pergunta:

Quais são as vantagens dessa abordagem?

## Resposta:

As principais vantagens são:

* Separação clara entre regras de negócio e persistência.
* Facilidade para substituir a persistência em memória por banco de dados futuramente.
* Código mais organizado e manutenível.
* Menor acoplamento entre as camadas do sistema.
* Possibilidade de criar testes automatizados utilizando implementações alternativas dos repositórios.
* Maior aderência aos princípios SOLID, especialmente Inversão de Dependência (DIP).
* Estrutura preparada para crescimento sem necessidade de grandes refatorações.

Mesmo sem utilizar banco de dados, a adoção de MemoryContext, repositórios e Injeção de Dependência permite desenvolver a aplicação de forma profissional e alinhada às boas práticas de arquitetura de software.

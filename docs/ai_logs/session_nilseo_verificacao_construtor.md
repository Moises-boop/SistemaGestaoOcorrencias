## Pergunta

É válido o cenário 3 (Recusada) e o cenário 4 (Duplicada) estarem acontecendo no construtor de Ocorrência? Pareceu estranho esse fluxo. Verifique e altere conforme necessidade.

## Resposta

O cenário que você descreveu está correto: o problema não é visual, é de domínio. Vou revisar a estrutura atual com cuidado, ajustar os invariantes e então validar novamente com a execução.

Ajustei o fluxo para que a triagem passe a acontecer explicitamente no programa, o que deixa o modelo de estado coerente com as regras que você descreveu.

✅ Ajustei o modelo para tratar os cenários 3 e 4 como comportamento real de domínio, não como “simples print”.

O que mudou
Em Ocorrencia.cs:

adicionei o conceito de estado terminal (EhTerminal);
bloqueei operações que não devem ocorrer em estados terminais;
validei Recusada e Duplicada com regras mais explícitas;
removi o efeito colateral do construtor para que a ocorrência nasça em AguardandoTriagem.
Em Program.cs:

os cenários agora chamam Triar(...) explicitamente;
o fluxo ficou consistente com o modelo de domínio.
Resultado verificado
Executei:

A saída agora mostra:

cenário 1: criação → triagem → vistoria → execução → encerramento;
cenário 3: situação final Recusada;
cenário 4: situação final Duplicada;
sem exceções nos cenários principais.
Em resumo: o problema deixou de ser “o print está errado” e passou a ser tratado como fluxo + invariantes de estado corretos.

## O que eu aprendi

Realmente a abordagem de colocar triagem não é adequada, porque o objeto já nasce com um estado que não é o esperado. O ideal é que a triagem seja um passo explícito.


## IA utilizada

MAI-Code-1-Flash
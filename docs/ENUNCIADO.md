# Sistema de Gestão de Ocorrências em um Centro de Operações Urbanas



## Contexto

Uma prefeitura deseja informatizar parte do funcionamento de um Centro de Operações Urbanas, responsável por receber, classificar, encaminhar e acompanhar ocorrências registradas por cidadãos, agentes públicos e sensores espalhados pela cidade.

As ocorrências podem envolver diferentes áreas, como iluminação pública, vias danificadas, árvores em risco, alagamentos, descarte irregular de resíduos, falhas em semáforos, problemas em praças públicas e situações que exigem vistoria técnica.

O sistema não deve apenas cadastrar ocorrências. Ele precisa representar regras de negócio, estados possíveis, responsabilidades distintas e variações de comportamento conforme o tipo de ocorrência, o nível de prioridade, o órgão responsável e a forma de acompanhamento.

A equipe deverá construir uma aplicação em C# organizada em solução com projetos separados por responsabilidade. Dentro de cada projeto, também deverá existir uma organização clara de pastas, evitando concentração excessiva de código em poucos arquivos.


## Problema

O Centro de Operações Urbanas precisa registrar ocorrências com, no mínimo, as seguintes informações: protocolo, descrição, bairro, data de abertura, origem do registro, nível de prioridade, situação atual e histórico de movimentações.

Cada ocorrência deve passar por uma triagem inicial. A triagem define se a ocorrência será aceita, recusada, encaminhada para vistoria, encaminhada diretamente para execução ou marcada como duplicada. Uma ocorrência recusada deve possuir justificativa. Uma ocorrência aceita deve possuir um setor responsável. Uma ocorrência duplicada deve referenciar o protocolo relacionado. 

Depois da triagem, o sistema deve permitir o acompanhamento da ocorrência até seu encerramento. Algumas ocorrências exigem vistoria antes da execução. Outras podem ir diretamente para atendimento. Algumas podem exigir reclassificação de prioridade durante o processo. Também deve ser possível registrar impedimentos, como falta de acesso ao local, endereço insuficiente, risco climático, necessidade de autorização ou dependência de outro setor.

O encerramento só pode ocorrer quando as regras mínimas da ocorrência forem atendidas. O sistema deve impedir encerramentos inválidos, movimentações incompatíveis com a situação atual e alterações que quebrem a consistência do histórico.


## Regras mínimas obrigatórias

A equipe deverá implementar regras de negócio que impeçam, pelo menos, as seguintes situações:

    • Registrar ocorrência sem descrição, bairro ou origem;
    • Criar ocorrência com prioridade inexistente;
    • Aceitar ocorrência sem setor responsável;
    • Recusar ocorrência sem justificativa;
    • Marcar ocorrência como duplicada sem protocolo relacionado;
    • Executar ocorrência que ainda exige vistoria pendente;
    • Encerrar ocorrência sem registro de atendimento, vistoria ou justificativa adequada;
    • Alterar uma ocorrência encerrada;
    • Registrar movimentação com data anterior à abertura;
    • Registrar movimentação incompatível com a situação atual.

Além dessas regras, a equipe deverá criar pelo menos quatro regras adicionais próprias, coerentes com o domínio escolhido.


## Variações obrigatórias do sistema

O sistema deve lidar com diferentes formas de comportamento sem concentrar decisões em grandes estruturas condicionais.

Devem existir variações para:

    • Cálculo de prioridade operacional;
    • Estratégia de triagem;
    • Forma de registrar o histórico;
    • Forma de gerar resumo da ocorrência;
    • Forma de selecionar o setor responsável;
    • Forma de validar se a ocorrência pode ser encerrada.
    
Essas variações devem ser demonstradas em execução com cenários diferentes no projeto principal.


## Herança, abstrações e polimorfismo

O domínio deve conter uma família conceitual real em que existam características comuns e comportamentos específicos. Essa família deverá ser modelada de forma adequada, com reaproveitamento de estado, validações comuns e especializações com regras próprias.

Também deverão existir comportamentos que possam ser executados por objetos de naturezas diferentes, sem obrigar essas classes a pertencerem à mesma hierarquia.

A aplicação deve demonstrar polimorfismo em pelo menos dois momentos:

    • Ao tratar diferentes objetos por um mesmo tipo abstrato ou contratual;
    • Ao executar uma lista de comportamentos variados sem que o código principal precise conhecer cada implementação concreta.


## Organização da solução

A entrega deverá ser feita em um repositório Git contendo uma solução C# com projetos separados por responsabilidade. A equipe deve justificar a divisão escolhida.

A solução deve conter, no mínimo:

    • Um projeto para o domínio do problema;
    • Um projeto para regras de aplicação ou serviços;
    • Um projeto para implementações concretas ou infraestrutura simulada;
    • Um projeto console para execução e demonstração dos cenários.

Não é necessário utilizar banco de dados real. Persistências, integrações e registros externos podem ser simulados em memória ou no console, desde que a separação de responsabilidades seja preservada.


## Cenários obrigatórios de demonstração

No projeto principal, a equipe deverá demonstrar pelo menos seis cenários completos:

    1. Uma ocorrência simples aceita, encaminhada e encerrada corretamente;
    2. Uma ocorrência que exige vistoria antes da execução;
    3. Uma ocorrência recusada com justificativa;
    4. Uma ocorrência marcada como duplicada;
    5. Uma tentativa inválida de encerramento;
    6. Uma troca de comportamento do sistema sem alteração nas classes centrais do domínio.

Cada cenário deve imprimir no console uma descrição clara do que está sendo executado e o resultado obtido.


## Uso de Inteligência Artificial

O uso de ferramentas de Inteligência Artificial é permitido.

Entretanto, caso a equipe utilize IA em qualquer etapa do desenvolvimento, será obrigatório documentar esse uso.

A equipe deverá manter um registro contendo:

    • Todos os prompts enviados às ferramentas ou agentes de IA;
    • Todas as respostas recebidas;
    • Quais trechos do projeto foram influenciados pelas respostas;
    • Um resumo do que foi aprendido em cada interação;
    • Quais decisões foram aceitas, adaptadas ou descartadas pela equipe.

Essa documentação deverá ser incluída no repositório, em um arquivo próprio ou em uma pasta específica.

Durante a defesa oral, qualquer integrante poderá ser questionado sobre as interações realizadas com IA e deverá ser capaz de explicar as decisões tomadas. O uso de IA não substitui a compreensão do código produzido.


## Entrega

A equipe deverá entregar o link do repositório contendo:

    • Solução C# compilável;
    • Projetos separados por responsabilidade;
    • Pastas internas organizadas de forma coerente;
    • Código com encapsulamento adequado;
    • Validações de regra de negócio;
    • Uso de herança quando houver família conceitual real;
    • Uso de classe abstrata quando fizer sentido para reaproveitar estado ou comportamento comum;
    • Uso de interfaces quando houver contratos de comportamento variáveis;
    • Demonstração de polimorfismo;
    • README explicando o domínio, as decisões de modelagem, as regras implementadas e como executar o projeto;
    • Documentação do uso de IA, caso tenha sido utilizada.


## Defesa da implementação

A defesa oral ocorrerá na aula de **segunda-feira**.

Após a entrega, a equipe deverá defender oralmente as decisões tomadas. Cada integrante deverá explicar uma parte relevante do sistema, incluindo:

    • Por que determinadas estruturas foram modeladas como entidades;
    • Por que determinada abstração foi criada;
    • Onde houve reaproveitamento por herança;
    • Onde houve uso de contratos de comportamento;
    • Como o sistema evita acoplamento excessivo;
    • Quais regras de negócio foram protegidas pelo domínio;
    • Quais partes poderiam evoluir sem alterar classes centrais;
    • Quais decisões foram tomadas pela equipe e quais sugestões eventualmente vieram de ferramentas de IA.

A avaliação não será baseada apenas no funcionamento. A clareza da modelagem, a coerência das decisões, a organização da solução e a capacidade de defender o próprio código terão peso importante.

A participação individual na defesa poderá influenciar a avaliação de cada integrante.

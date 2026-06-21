docs/regras-negocio
# Regras de Negócio do Sistema de Gerenciamento de Ocorrências

| RN01            | Não é permitido registrar uma ocorrência sem descrição, bairro ou origem.                                |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN02            | Não é permitido criar uma ocorrência com prioridade inexistente.                                         |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN03            | Não é permitido aceitar uma ocorrência sem setor responsável.                                            |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN04            | Não é permitido recusar uma ocorrência sem justificativa.                                                |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN05            | Não é permitido marcar uma ocorrência como duplicada sem protocolo relacionado.                          |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN06            | Não é permitido executar uma ocorrência que ainda exige vistoria pendente.                               |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN07            | Não é permitido encerrar uma ocorrência sem registro de atendimento, vistoria ou justificativa adequada. |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN08            | Não é permitido alterar uma ocorrência encerrada.                                                        |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN09            | Não é permitido registrar uma movimentação com data anterior à abertura da ocorrência.                   |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN10            | Não é permitido registrar uma movimentação incompatível com a situação atual da ocorrência.              |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN11            | Toda ocorrência deve passar por uma triagem inicial antes de encaminhar, executar ou encerrar.           |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN12            | A triagem define ocorrência como aceita, recusada, encaminhada para vistoria ou execução, ou duplicada   |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN13            | O protocolo referenciado numa duplicação tem que existir e não pode ser o próprio protocolo              |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN14            | Toda alteração relevante de estado ou ação deve gerar uma entrada no histórico de movimentações          |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN15            | Somente ocorrências aceitas ou classificadas pela triagem são encaminhadas para execução ou vistoria     |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |
=======
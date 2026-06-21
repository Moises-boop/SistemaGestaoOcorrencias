# Regras de Negócio do Sistema de Gerenciamento de Ocorrências


| RN01            | Registrar uma ocorrência sem descrição, bairro ou origem é inválido.                                     |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN02            | A criação de uma ocorrência deve ter prioridade existente.                                               |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN03            | Uma ocorrência aceita precisa ter algum setor responsável.                                               |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN04            | A recusa de uma ocorrência deve ter justificativa.                                                       |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN05            | É inválido marcar uma ocorrência como duplicada sem protocolo relacionado.                               |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN06            | A execução de uma ocorrência pode ser feita se não houver vistoria pendente.                             |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN07            | Uma ocorrência não pode ser encerrada sem registro de atendimento, vistoria ou justificativa adequada.   |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN08            | Ocorrências encerradas não podem ser alteradas.                                                          |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN09            | Uma movimentação não deve ser registrada com data anterior à abertura da ocorrência.                     |
| :-------------- | :------------------------------------------------------------------------------------------------------- |
| **Versão:** 1.0 | **Prioridade:** Essencial                                                                                |

| RN10            | É inválido registrar uma movimentação incompatível com a situação atual da ocorrência.                   |
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
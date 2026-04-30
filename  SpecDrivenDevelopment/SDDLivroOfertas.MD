# SDD - Sistema de Livro de Ofertas

## 1. Objetivo
Implementar um motor de processamento de ordens que mantenha a integridade de um livro de ofertas baseado em notificações de eventos (Event Sourcing simplificado).

## 2. Design da Solução
A solução utiliza uma coleção dinâmica indexada para refletir as posições em tempo real.

### 2.1 Mapeamento de Operações
* **Inserção (Ação 0):** Implementada via deslocamento de memória. Ao inserir na posição `N`, todos os elementos de `N` em diante são incrementados.
* **Modificação (Ação 1):** Atualização seletiva (Patch). Campos com valor `0` no input são ignorados para preservar o dado anterior.
* **Remoção (Ação 2):** Exclusão física do registro, resultando na reindexação automática das posições subsequentes.

## 3. Análise de Complexidade
* **Tempo:** No pior caso (inserções/remoções no topo da lista), temos $O(N \times M)$, onde $N$ é o número de notificações e $M$ é o tamanho do livro, devido ao deslocamento de elementos da lista.
* **Espaço:** $O(M)$ para armazenar as ofertas ativas no livro.

## 4. Considerações de Performance
Para volumes massivos de dados, uma `LinkedList` poderia ser considerada para otimizar inserções no meio, mas para este desafio, a `List<T>` do .NET oferece o melhor equilíbrio entre acesso por índice ($O(1)$) e simplicidade de implementação.

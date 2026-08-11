# SDD - Menor Distância Entre Dois Arrays

## 1. Objetivo
Desenvolver um algoritmo eficiente para encontrar a menor diferença absoluta entre qualquer par de elementos de dois arrays distintos.

## 2. Estratégia de Implementação
A solução evita o custo computacional de comparar todos os pares ($O(n \times m)$) utilizando a técnica de **Dois Ponteiros**.

### 2.1 Passos do Algoritmo
1. **Sort:** Ordenar ambos os arrays para garantir a progressão linear dos valores.
2. **Iteração Eficiente:** - Comparar `arr1[i]` e `arr2[j]`.
   - Atualizar a `menorDistancia` se o resultado for menor que o valor global anterior.
   - Incrementar o índice do array que contém o menor valor atual.
3. **Short-circuit:** Se a distância zero for encontrada, o algoritmo encerra imediatamente.

## 3. Complexidade
* **Tempo:** $O(n \log n + m \log m)$ devido à ordenação. A busca em si é $O(n + m)$.
* **Espaço:** $O(1)$ (In-place sorting).

## 4. Execução Online
O código pode ser validado no link abaixo:
**[Executar no DotNetFiddle](https://dotnetfiddle.net/v2n2vG)** (Substituir pelo link gerado)

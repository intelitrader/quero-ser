# Desafio Encontre o telefone

fonte: https://dojopuzzles.com/problems/encontre-o-telefone/

Em alguns lugares é comum lembrar um número do telefone associando seus dígitos a letras. Dessa maneira a expressão MY LOVE significa 69 5683. Claro que existem alguns problemas, uma vez que alguns números de telefone não formam uma palavra ou uma frase e os dígitos 1 e 0 não estão associados a nenhuma letra.
Sua tarefa é ler uma expressão e encontrar o número de telefone correspondente baseado na tabela abaixo. Uma expressão é composta por letras maiúsculas (A-Z), hifens (-) e os números 1 e 0.
Letras  ->  Número 
ABC    ->  2 
DEF    ->  3 
GHI    ->  4 
JKL    ->  5 
MNO    ->  6 
PQRS    ->  7 
TUV    ->  8 
WXYZ   ->  9 
Entrada
A entrada consiste de um conjunto de expressões. Cada expressão está sozinha em uma linha e possui C caracteres, onde 1 ≤ C ≤ 30. 

# Desafio Vai Um

fonte: https://dojopuzzles.com/problems/vai-um/

As crianças aprendem a adicionar multi-dígitos da direita para a esquerda, um dígito por vez. Muitas acham o "vai um", operação aonde o 1 é carregado para a posição seguinte, um desafio significativo. Seu trabalho é dado dois números inteiros positivos, contar o número de operações de "vai um" para adição. Entrada: dois valores inteiros positivos. Retorno: quantidade de "vai um" da soma. Exemplos: Entrada: 123 456 Retorno: 0 "vai um"; Entrada: 555 555 Retorno: 3 "vai um"; Entrada: 123 594 Retorno: 1 "vai um"; Adaptado a partir do problema "Carry" do livro Programming Challenges - The Programming Contest Training Manual_Steven S. Skiena, Miguel A. Revilla (Springer 2003)


# Desafio Escolhendo uma pizza

Fonte: https://dojopuzzles.com/problems/escolhendo-uma-pizza/

Em algumas empresas de desenvolvimento de software é comum, quando o prazo de entrega de uma aplicação está próximo, a equipe passar algumas noites trabalhando. E como todo desenvolvedor também precisa se alimentar, eles sempre pedem pizza nessas ocasiões. Só que sempre é uma briga para conseguir escolher os sabores das pizza de sabores que todos gostam.
Um dos membros da equipe, incomodado com as intermináveis discussões sobre o sabor a ser escolhido, resolveu desenvolver um programa para facilitar essa escolha.
Para cada sabor de pizza disponível, cada um deve indicar uma nota para ele (nota 1, se a pessoa detesta o sabor e nota 5 se a pessoa adora o sabor). Depois de processar esses dados, cada pessoa vai saber quais as pessoas que tem o gosto mais parecido que o seu (e que provavelmente irá dividir uma pizza com você).

# Desafio 3 (DojoPuzzles)

## Analisador de expressões matemáticas

Converte uma expressão matemática infix para o formato postfix, posteriormente retorna seu resultado. O processo de conversão também analisa a semântica e sintaxe da expressão, isto é, verifica se um símbolo é reconhecido e, caso seja, se seu posicionamento dentro da expressão faz sentido. Desafio bem legal, nunca tinha feito um parser nesse nível.

Clique [aqui](http://dojopuzzles.com/problemas/exibe/avaliando-expressoes-matematicas/) para ir para a página do desafio no DojoPuzzles.

Desafio implementado em ambiente Linux.

Compilação: `make all`

Exemplos de uso:

```bash
./desafio3
Expressão: 3 + (100 - 33) * 10 - 55 + (100 / 10)
Resultado = 628
```

```bash
./desafio3
Expressão: (40 + (3 * (8 * (14 / 2) - 4 ) ) ) / 28
Resultado = 7
```

```bash
./desafio3
Expressão: 100 + (20 * / 2)

100 + (20 * / 2)
~~~~~~~~~~~~^~~~
Erro: operador "/" não esperado!
```

```bash
./desafio3
Expressão: (10 * 3 / 2) + (20 + 30) 40

(10 * 3 / 2) + (20 + 30) 40
~~~~~~~~~~~~~~~~~~~~~~~~~^~
Erro: operando não esperado!
```

```bash
./desafio3
Expressão: 10 * (20 + )

10 * (20 + )
~~~~~~~~~~~^
Erro: esperava-se um operando
```

```bash
./desafio3
Expressão: 10 / (5 - 5)

Erro: tentativa de divisão por zero! Por favor, reveja a expressão!
```

Pontos a serem melhorados:

- permitir uso de números negativos, pois (10 - -10) atualmente é um erro

- permitir uso de números com casa decimal

- aprimorar a análise dos parênteses

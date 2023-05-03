"""
Problema resolvido de acordo com o link abaixo
https://dojopuzzles.com/problems/geracao-de-fatores-primos/


Todo número inteiro positivo pode ser representado pelo produto de potências de números primos (os chamados fatores primos).

Por exemplo o número 6 pode ser representado pelo produto do números primos 2 x 3.

Outros exemplos:

5 = 5 (números primos só tem um fator primo - ele mesmo)
100 = 2 x 2 x 5 x 5
198 = 2 x 3 x 3 x 11
276 = 2 x 2 x 3 x 23
Desenvolva um programa que dado um número inteiro positivo, retorne os seus fatores primos

 

Fonte: http://butunclebob.com/ArticleS.UncleBob.ThePrimeFactorsKata
"""

def fatores_primos(numero):
    fatores = []
    divisor = 2
    while numero > 1:
        while numero % divisor == 0:
            fatores.append(divisor)
            numero = numero / divisor
        divisor += 1
    return fatores
numero = int(input("Digite um número inteiro positivo:"))
print("Fatores primos de", numero, ": ", fatores_primos(numero))

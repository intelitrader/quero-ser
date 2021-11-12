'''
Exercício disponível em: https://dojopuzzles.com/problems/palavras-primas/

Descrição do exercício:
Palavras Primas

Um número primo é definido se ele possuir exatamente dois divisores:
o número um e ele próprio. São exemplos de números primos: 2, 3, 5, 101, 367 e 523.

Neste problema, você deve ler uma palavra composta somente por letras [a-zA-Z].
Cada letra possui um valor específico, a vale 1, b vale 2 e assim por diante,
até a letra z que vale 26.
Do mesmo modo A vale 27, B vale 28, até a letra Z que vale 52.

Você precisa definir se cada palavra em um conjunto de palavras é prima ou não.
Para ela ser prima, a soma dos valores de suas letras deve ser um número primo.
'''

import re

# letra_valor será um dicionário python
# Que abrigará em suas keys um caractere válido
# E em seus values o valor inteiro conforme solicitado pelo problema.
letra_valor = {}

for unicode in range(1, 27):  # 26 letras no alfabeto
    # Como a ordem não irá importar, podemos adicionar tudo no mesmo loop.
    letra_valor.update({chr(unicode + 96): unicode})  # Pelo unicode as letras minúsculas começam em 97
    letra_valor.update({chr(unicode + 64): unicode + 26})  # E as maiúsculas em 65

# Loop main
while True:

    palavra = ''
    palavra_status = None
    while palavra_status is None:  # Garante que a palavra digitada só contenha caracteres válidos.
        palavra = input('Digite qualquer palavra, ou fim para sair: ')
        palavra_status = re.fullmatch('[a-zA-Z]*', palavra)
        if palavra_status is None:
            input('A palavra digitada é inválida. Pressione enter para continuar...\n')

    if palavra.lower() == 'fim':  # Condição de saída do loop main
        break

    # Loop que calcula o valor da palavra
    palavra_prima = 0
    for letra in palavra:
        palavra_prima += letra_valor[letra]

    # criação das variáveis que guardam os valores a serem impressos
    nao_prima = f'A palavra: {palavra}\nTem valor = {palavra_prima}\nE NÃO é uma palavra prima.\n'
    prima = f'A palavra: {palavra}\nTem valor = {palavra_prima}\nE é uma palavra prima.\n'

    if (palavra_prima % 2 == 0 and palavra_prima != 2) or palavra_prima < 2:
        # Se for 0, 1 ou um número par, diferente de 2 não é primo!
        print(nao_prima)

    else:
        outro_divisor = False
        for i in range(2, (palavra_prima // 2) + 1):

            # Números não são uniformemente divisíveis por um número superior a sua metade,
            # que não seja ele mesmo.
            # E todo número é divisível por 1 e por ele mesmo.
            # Desta forma, economizamos iterações no loop

            if palavra_prima % i == 0:
                outro_divisor = True
                print(nao_prima)
                break

        if not outro_divisor:
            print(prima)

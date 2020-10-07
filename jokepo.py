from random import randint
from time import sleep


jogar = 'S'
jogador_ganha = 0
comp_ganha = 0
empate = 0

while jogar == 'S':
    itens = ('Pedra', 'Papel', 'Tesoura')
    comp = randint(0, 2)
    print('Suas opções: [0] PEDRA [1] PAPEL [2] TESOURA')

# Validando se o usuário informou o tipo de dado correto
    continua = True
    while continua:
        try:
            jogador = int(input('Qual é a sua jogada? '))
        except ValueError:
            print('O valor informado é de um tipo inválido, tente novamente digitando 0, 1 ou 2')
        else:
            continua = False

    print('JO')
    sleep(0.5)
    print('KEN')
    sleep(0.5)
    print('PO!')
    sleep(0.5)
    print(f'O computador jogou {itens[comp]}')
    print(f'Você jogou {itens[jogador]}')

    if comp == 0:
        if jogador == 0:
            print('EMPATE!')
        elif jogador == 1:
            print('JOGADOR VENCEU!')
        elif jogador == 2:
            print('COMPUTADOR VENCEU!')
        else:
            print('JOGAGA INVÁLIDA')

    elif comp == 1:
        if jogador == 0:
            print('COMPUTADOR VENCEU!')
        elif jogador == 1:
            print('EMPATE!')
        elif jogador == 2:
            print('JOGADOR VENCEU!')
        else:
            print('JOGAGA INVÁLIDA')

    elif comp == 2:
        if jogador == 0:
            print('JOGADOR VENCEU!')
        elif jogador == 1:
            print('COMPUTADOR VENCEU!')
        elif jogador == 2:
            print('EMPATE!')
        else:
            print('JOGAGA INVÁLIDA')

# Contador do placar
    if comp == 0:
        if jogador == 0:
            empate = empate + 1
        elif jogador == 1:
            jogador_ganha = jogador_ganha + 1
        elif jogador == 2:
            comp_ganha = comp_ganha + 1

    elif comp == 1:
        if jogador == 0:
            comp_ganha = comp_ganha + 1
        elif jogador == 1:
            empate = empate + 1
        elif jogador == 2:
            jogador_ganha = jogador_ganha + 1

    elif comp == 2:
        if jogador == 0:
            jogador_ganha = jogador_ganha + 1
        elif jogador == 1:
            comp_ganha = comp_ganha + 1
        elif jogador == 2:
            empate = empate + 1

    print('-=-' * 15)
    print(f'Placar atual: Jogador {jogador_ganha} x {comp_ganha} Computador')
    print('-=-' * 15)

    jogar = str(input('Deseja continuar a jogar? [S/N]')).upper()
    while jogar not in 'SN':
        jogar = str(input(
            'Digite um dado válido. Deseja continuar a jogar? [S/N] ')).upper()


else:
    if jogador_ganha > comp_ganha:
        print(f'Você venceu o computador por {jogador_ganha} a {comp_ganha}.')
    elif jogador_ganha < comp_ganha:
        print(f'O computador venceu você por {jogador_ganha} a {comp_ganha}.')
    elif jogador_ganha == comp_ganha:
        print('Vocês empataram.')

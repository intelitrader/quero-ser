from random import randint
computador = randint(1, 3)
# gerando numero aleatorio a partir de modulo importado
print(f'[1] Pedra\n[2] Papel\n[3] Tesoura')
# pedindo input de usuario
humano = int(input('Qual a sua jogada?: '))
print(f'Computador jogou {computador}, Resultado: ')
# condicoes para decisao de resultado do jogo
if humano == computador:
    print('EMPATE!')
elif humano == 1 and computador == 2 or humano == 2 and computador == 3 or humano == 3 and computador == 1:
    print('Computador Ganha!')
else:
    print('Humano Ganha!')

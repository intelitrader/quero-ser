from random import randint
from time import sleep

lista = ("Pedra", "Papel", "Tesoura")

computador = randint(0, 2)

jogador = int(input('''Escolha uma opção para iniciar: 

Pedra   [0]  
Papel   [1] 
Tesoura [2] 
 
Digite sua jogada >>>  '''))

print( "Vamos Lá !!!\n" )
print("JO\n")
sleep(1)
print("KEN\n")
sleep(1)
print("PO!!!\n")

print("=*"*20)
print("O computador escolheu: {}\n".format(lista[computador]))
print("O jogador escolheu: {}".format(lista[jogador]))
print("=*"*20 + "\n")

if computador == 0:
    if jogador == 0:
        print("Empate!")
    elif jogador == 1:
        print("Jogador perdeu")
    elif jogador == 2:
        print("Computador venceu")
    else:
        print("Operacao invalida")

elif computador == 1:
    if jogador == 0:
        print("Computador perdeu")
    elif jogador == 1:
        print("Empate!")
    elif jogador == 2:
        print("Jogador venceu")
    else:
        print("Operacao invalida")
elif computador == 2:
    if jogador == 0:
        print("Jogador venceu")
    elif jogador == 1:
        print("Computador venceu")
    elif jogador == 2:
        print("Empate!")
    else:
        print("Operacao invalida")
else:
    print("Operacao invalida")

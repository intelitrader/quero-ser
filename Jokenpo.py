from random import randint
from time import sleep
print('''\033[1;34mFAÇA SUA ESCOLHA
(0)pedra
(1)papel
(2)tesoura\033[m''')
itens = ['pedra', 'papel', 'tesoura']
jogador = int(input('\033[4;33mescolha:\033[m'))
cpu = randint(0, 2)
print('\033[1;31mJO\033[m')
sleep(1)
print('\033[1;32mKEN\033[m')
sleep(1)
print('\033[1;33mPO!!!\033[m')
sleep(1)
print('\033[7;31;m-=\033[m'* 20)
print('\033[1;34mO computador jogou:\033[m{}'.format(itens[cpu]))
print('\033[1;33mO jogador jogou:\033[m{}'.format(itens[jogador]))
print('\033[7;31;m-=\033[m'* 20)
if cpu == 0:#PEDRA
    if jogador == 0:
        print('\033[1;32mEMPATE!\033[m')
    elif jogador ==1:
        print('\033[1;36mVOCÊ GANHOU!\033[m')
    elif jogador == 2:
        print('\033[1;31mCPU GANHOU!\033[m')
    else:
        print('jogada invalida!')
elif cpu == 1:#PAPEL
    if jogador == 0:
        print('\033[1;31mCPU GANHOU!\033[m')
    elif jogador == 1:
        print('\033[1;32mEMPATE!\033[m')
    elif jogador == 2:
        print('\033[1;36mVOCÊ GANHOU!\033[m')
    else:
        print('jogada invalida!')

elif cpu ==2:#TESOURA
    if jogador == 0:
        print('\033[1;36mVOCÊ GANHOU!\033[m')
    elif jogador == 1:
        print('\033[1;31mCPU GANHOU!\033[m')
    elif jogador == 2:
        print('\033[1;32mEMPATE!\033[m')
    else:
        print('jogada invalida!')

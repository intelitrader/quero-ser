"""
Seu desafio é fazer um programa que leia o valor total
a ser pago e o valor efetivamente pago, informando o menor número de cédulas
e moedas que devem ser fornecidas como troco.

Deve-se considerar que há:

cédulas de R$100,00, R$50,00, R$10,00, R$5,00 e R$1,00;
moedas de R$0,50, R$0,10, R$0,05 e R$0,01.
"""


def contagem(lista, num):
    clone = lista
    rep = 0
    for k, val in enumerate(clone):
        if num == val:
            rep += 1
        else:
            continue
    return rep


preço = float(input('Digite o valor a ser pago (preço): R$'))
pago = float(input('Quanto foi pago? R$'))
troco = pago - preço

n_usadas = []
m_usadas = []

print(f'{" Resultados ":=^50}')
print(f'O troco vale: R${troco:.2f}')

while True:
    # tratando as notas
    if troco >= 100:
        troco -= 100
        n_usadas.append(100)
    elif troco >= 50:
        troco -= 50
        n_usadas.append(50)
    elif troco >= 10:
        troco -= 10
        n_usadas.append(10)
    elif troco >= 5:
        troco -= 5
        n_usadas.append(5)
    elif troco >= 1:
        troco -= 1
        n_usadas.append(1)
    else:
        if troco == 0:
            break
        else:
            # tratando moedas
            if troco >= 0.50:
                troco -= 0.50
                m_usadas.append(0.50)
            elif troco >= 0.10:
                troco -= 0.10
                m_usadas.append(0.10)
            elif troco >= 0.05:
                troco -= 0.05
                m_usadas.append(0.05)
            elif troco >= 0.01:
                troco -= 0.01
                m_usadas.append(0.01)
            else:
                break
    continue


mtamanho = len(m_usadas)
ntamanho = len(n_usadas)
m_usadas.sort(reverse=True)
n_usadas.sort(reverse=True)

print('Serão usadas as seguintes notas para o Troco:')
for n, v in enumerate(n_usadas):
    nquantidade = contagem(n_usadas, v)

    if nquantidade == 1:
        print(f'Uma Nota de {v}.')
    elif nquantidade > 1:
        try:
            if v != n_usadas[n+1]:
                print(f'{nquantidade} Notas de {v}.')
        except IndexError:
            print(f'{nquantidade} Notas de {v}.')
    elif n+1 == ntamanho:
        print(f'E uma Nota de {v}.')

for n, v in enumerate(m_usadas):
    mquantidade = contagem(m_usadas, v)

    if n+1 == mtamanho:
        print(f'E {mquantidade} moedas de {v:.2f} centavos.')
    elif mquantidade == 1:
        print(f'Uma Moeda de {v:.2f} centavos.')
    elif mquantidade > 1:
        try:
            if v != m_usadas[n+1]:
                print(f'{mquantidade} moedas de {v:.2f} centavos.')
        except IndexError:
            print(f'{mquantidade} moedas de {v:.2f} centavos.')

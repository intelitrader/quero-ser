print('Bem vindo ao Banco DSM!')
valorSaque = int(input('Qual valor você gostaria de sacar R$ '))
print('-' * 40)
for nota in [100, 50, 20, 10]:
    quantidade = valorSaque // nota
    valorSaque = valorSaque % nota
    if quantidade > 0:
        print(f'{quantidade} notas de R$ {nota}')
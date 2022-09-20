notas100 = notas50 = notas20 = notas10 = totced = 0
while True:
    # pedindo ao usuario para inserir total desejado
    valor = int(input('Insira o valor que deseja sacar(R$): '))
    # adicionando notas necessarias de acordo com valor remanescente
    while valor >= 100:
        valor -= 100
        notas100 += 1
        totced += 1
    while valor >= 50:
        valor -= 50
        notas50 += 1
        totced += 1
    while valor >= 20:
        valor -= 20
        notas20 += 1
        totced += 1
    while valor >= 10:
        valor -= 10
        notas10 += 1
        totced += 1
    break # quebra do loop ao fugir das condicoes (valor diminuir de 10)
print(f'\n> Lhe serao entregues {totced} cedulas no total, sendo:')
# condicoes para mostrar quantidade de notas necessarias
if notas100 != 0:
    print(f'{notas100} notas de R$100,', end='')
if notas50 != 0:
    print(f' {notas50} notas de R$50,', end='')
if notas20 != 0:
    print(f' {notas20} notas de R$20,', end='')
if notas10 != 0:
    print(f' {notas10} notas de R$10. Bom dia!')

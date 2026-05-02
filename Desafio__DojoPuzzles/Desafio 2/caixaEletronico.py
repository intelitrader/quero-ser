print('=' * 30)
print('{:^30}'.format('Caixa Eletrônico'))
print('=' * 30)
valor = int(input('Qual valor você quer sacar? R$'))
total = valor
cedula = 100
totalCedula = 0
while True:
    if total >= cedula:
        total -= cedula
        totalCedula += 1
    else:
        if totalCedula > 0:
            print(f'Total de {totalCedula} cédulas de R$ {cedula}')
        if cedula == 100:
            cedula = 50
        elif cedula == 50:
            cedula = 20
        elif cedula == 20:
            cedula = 10
        totalCedula = 0
        if total == 0:
            break
print('=' * 30)

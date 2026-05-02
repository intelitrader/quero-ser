#https://dojopuzzles.com/problems/troco/

from decimal import Decimal, getcontext
getcontext().prec = 3

total=float(input('Valor a ser pago:'))
pago=float(input('Valor pago:'))

valortroco = pago-total

cedula100 = []
cedula50 = []
cedula10 = []
cedula5 = []
cedula1 = []
moeda50 = []
moeda10 = []
moeda5 = []
moeda1 = []

while valortroco >= 100.00:
    cedula100.append(1)
    valortroco -= 100.00
while valortroco >= 50.00:
    cedula50.append(1)
    valortroco -= 50.00
while valortroco >= 10.00:
    cedula10.append(1)
    valortroco -= 10.00
while valortroco >= 5.00:
    cedula5.append(1)
    valortroco -= 5.00
while valortroco >= 1.00:
    cedula1.append(1)
    valortroco -= 1.00
while valortroco >= 0.50:
    moeda50.append(1)
    valortroco = float(Decimal(valortroco) - Decimal(0.50))
while valortroco >= 0.10:
    moeda10.append(1)
    valortroco = float(Decimal(valortroco) - Decimal(0.10))
while valortroco >= 0.05:
    moeda5.append(1)
    valortroco = float(Decimal(valortroco) - Decimal(0.05))
while valortroco >= 0.01:
    moeda1.append(1)
    valortroco = float(Decimal(valortroco) - Decimal(0.01))

if cedula100:
    print(f'{len(cedula100)} cédula(s) de 100 Reais')
if cedula50:
    print(f'{len(cedula50)} cédula(s) de 50 Reais')
if cedula10:
    print(f'{len(cedula10)} cédula(s) de 10 Reais')
if cedula5:
    print(f'{len(cedula5)} cédula(s) de 5 Reais')
if cedula1:
    print(f'{len(cedula1)} cédula(s) de 1 Real')
if moeda50:
    print(f'{len(moeda50)} moeda(s) de 50 centavos')
if moeda10:
    print(f'{len(moeda10)} moeda(s) de 10 centavos')
if moeda5:
    print(f'{len(moeda5)} moeda(s) de 5 centavos')
if moeda1:
    print(f'{len(moeda1)} moeda(s) de 1 centavo')

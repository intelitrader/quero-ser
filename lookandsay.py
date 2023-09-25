#https://dojopuzzles.com/problems/sequencia-look-and-say/

def lookandsay(numero):
	numero = str(numero)
	contador = 1
	sequencia = ""
	for i in range(len(numero)):
		if len(numero) == 1:
			sequencia += "1" + numero
			break
		elif len(numero) == 2:
			if numero[0] == numero[1]:
				sequencia += "2" + numero[0]
				break
			else:
				sequencia += "1" + numero[0] + "1" + numero[1]
				break
		else:
			if (i<(len(numero)-1)):
				if numero[i] == numero[i+1]:
					contador += 1
				else:
					sequencia += str(contador) + numero[i]
					contador = 1
			else:
				if numero[i] == numero[i-1]:
					sequencia += str(contador) + numero[i]
				else:
					sequencia += "1" + numero[i] 
	return sequencia
numero = input('digito: ')
for i in range(49):
	numero = lookandsay(numero)
a = 0
for i in range(len(numero)):
	a += int(numero[i])
print(a)
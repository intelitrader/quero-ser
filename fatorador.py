#https://dojopuzzles.com/problems/geracao-de-fatores-primos/
import math

n = int(input('numero: '))
a = n
l = ""

def fatorar(num):
	a = 0
	for i in range(2,math.floor(num/2)+1):
		if num%i==0:
			a = i
			break
	if a == 0:
		a = num
	return a
while n >= 4:
	d = fatorar(n)
	if l == "":
		l += f'{d}'
	else:
		l += f'x{d}'
	n = int(n/d)
if n < 4 and n != 1:
	if l == '':
		l = f'{n}'
	else:
		l += f'x{n}'
print(f'{a} = {l}')
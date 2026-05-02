#https://dojopuzzles.com/problems/encontre-o-telefone/

num1 = ['0','1', '2', '3', '4', '5', '6', '7', '8', '9']
num2 = ['A', 'B', 'C']
num3 = ['D', 'E', 'F']
num4 = ['G', 'H', 'I']
num5 = ['J', 'K', 'L']
num6 = ['M', 'N', 'O']
num7 = ['P', 'Q', 'R', 'S']
num8 = ['T', 'U', 'V']
num9 = ['W', 'X', 'Y', 'Z']

Nome = input('Digite uma frase para transforma-la em número de telefone:').upper()

numprint = []

for a in Nome:
    if a in num1:
        numprint.append(a)
    if a in num2:
        numprint.append('2')
    if a in num3:
        numprint.append('3')
    if a in num4:
        numprint.append('4')
    if a in num5:
        numprint.append('5')
    if a in num6:
        numprint.append('6')
    if a in num7:
        numprint.append('7')
    if a in num8:
        numprint.append('8')
    if a in num9:
        numprint.append('9')
    if a == '-':
        numprint.append('-')

print(''.join(numprint))
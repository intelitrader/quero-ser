'''
Exercício disponível em: https://dojopuzzles.com/problems/fizzbuzz/

Descrição do exercício:
FizzBuzz
Neste problema, você deverá exibir uma lista de 1 a 100, um em cada linha, com as seguintes exceções:

Números divisíveis por 3 deve aparecer como 'Fizz' ao invés do número;
Números divisíveis por 5 devem aparecer como 'Buzz' ao invés do número;
Números divisíveis por 3 e 5 devem aparecer como 'FizzBuzz' ao invés do número'.
'''

for i in range(1, 101):
    result = ''
    if i % 3 == 0:
        result = 'Fizz'
    if i % 5 == 0:
        result += 'Buzz'
    print(result or i)

"""
É possível resolver essa questão desta outra forma, embora utilize menos linhas ela é
menos legível e menos performática.

for i in range(1, 101):
    print('Fizz' * (i % 3 < 1) + 'Buzz' * (i % 5 < 1) or i)
"""
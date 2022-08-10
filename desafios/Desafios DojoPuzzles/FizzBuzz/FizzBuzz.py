"""Neste problema, você deverá exibir uma lista de 1 a 100, um em cada linha, com as seguintes exceções:

Números divisíveis por 3 deve aparecer como 'Fizz' ao invés do número;
Números divisíveis por 5 devem aparecer como 'Buzz' ao invés do número;
Números divisíveis por 3 e 5 devem aparecer como 'FizzBuzz' ao invés do número'."""

for n in range(1, 101):
    if n % 5 == 0 and n % 3 == 0:
        print('FizzBuzz')
    elif n % 3 == 0:
        print('Fizz')
    elif n % 5 == 0:
        print('Buzz')
    else:
        print(n, end='\n')

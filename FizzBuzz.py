# DojoPuzzle: FizzBuzz
# Autor: Taynan Carvalho
# Data de criação: 14/01/2022

# Faz a lista do número 1 ao 100, um em cada linha, com algumas EXCEÇÕES
for num in range(1,101):

    # Divide um em centena, dezena e unidade
    c = num // 100 % 10
    d = num // 10 % 10
    u = num // 1 % 10

    # Realiza a soma dos dígitos do número
    soma = c + d + u
    
    # EXCEÇÕES

    # Números divisíveis por 3 e 5 aparece 'FizzBuzz' ao invés do número
    if soma % 3 == 0 and (u == 0 or u == 5):
        print('FizzBuzz')

    # Números divisíveis por 5 aparece 'Buzz' ao invés do número
    elif u == 0 or u == 5:
        print('Buzz')

    # Números divisíveis por 3 aparece 'Fizz' ao invés do número
    elif soma % 3 == 0:
        print('Fizz')

    # Caso não seja um número disíveil por 3 e nem 5, aparece o próprio número
    else:
        print(num)

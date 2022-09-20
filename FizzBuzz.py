# for loop para printar numeros de zero a cem
for i in range(1, 101):
    # condicoes diferenciadas de acordo com resultado esperado
    if i % 3 == 0 and i % 5 == 0:
        print('FizzBuzz')
        # pular iteracoes seguintes, entregando controle de volta para loop
        continue
    elif i % 3 == 0:
        print('Fizz')
        continue
    elif i % 5 == 0:
        print('Buzz')
        continue
    print(i)

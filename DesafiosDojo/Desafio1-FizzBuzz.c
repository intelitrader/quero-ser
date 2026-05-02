/*
Neste problema, você deverá exibir uma lista de 1 a 100, um em cada linha, com as seguintes exceções:

Números divisíveis por 3 deve aparecer como 'Fizz' ao invés do número;

Números divisíveis por 5 devem aparecer como 'Buzz' ao invés do número;

Números divisíveis por 3 e 5 devem aparecer como 'FizzBuzz' ao invés do número'.

https://dojopuzzles.com/problems/fizzbuzz/  */

#include <stdio.h>

void fizzBuzz();

int main()
{
    const int fizz = 3;
    const int buzz = 5;

    fizzBuzz(fizz, buzz);
    return 0;
}

void fizzBuzz(const int num1, const int num2)
{
    int i;

    for(i = 1; i<=100; i++)
    {
        if (i % num1 == 0 && i % num2 == 0 )
            printf("FizzBuzz\n");

        else if (i % num1 == 0 )
            printf("Fizz\n");

        else if (i % num2 == 0 )
            printf("Buzz\n");

        else
            printf("%d\n", i);  
     }
}
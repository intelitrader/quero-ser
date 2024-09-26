/*
DESAFIO DOJO 3 - FIZZBUZZ

Este problema foi utilizado em 1304 Dojo(s).

Neste problema, voc� dever� exibir uma lista de 1 a 100, um em cada linha, com as seguintes exce��es:

N�meros divis�veis por 3 deve aparecer como 'Fizz' ao inv�s do n�mero;
N�meros divis�veis por 5 devem aparecer como 'Buzz' ao inv�s do n�mero;
N�meros divis�veis por 3 e 5 devem aparecer como 'FizzBuzz' ao inv�s do n�mero'.
*/

#include <stdio.h>

void main(){
    int numero=1;
    while (numero <= 100){
        if ((numero%3 == 0) && (numero%5 == 0)){
            printf("\nFizzBuzz");
        } else {
            if (numero%5 == 0){
                printf("\nBuzz");
            } else {
               if (numero%3 == 0){
                    printf("\nFizz");
               } else {
                    printf("\n%d", numero);
               }
            }
        }
        numero++;
    }
}

#include <stdio.h>
/*
Desenvolva um programa que simule a entrega de notas quando um cliente efetuar um saque em um caixa eletrônico. Os requisitos básicos são os seguintes:

Entregar o menor número de notas;
É possível sacar o valor solicitado com as notas disponíveis;
Saldo do cliente infinito;
Quantidade de notas infinito (pode-se colocar um valor finito de cédulas para aumentar a dificuldade do problema);
Notas disponíveis de R$ 100,00; R$ 50,00; R$ 20,00 e R$ 10,00  

https://dojopuzzles.com/problems/caixa-eletronico/ */

int main()
{
    int dinheiro, N100, N50, N20, N10;

    printf("Valor do Saque: R$ ");
    scanf("%i", &dinheiro);

    printf("Entregar");

        N100 = dinheiro / 100;
        if ( N100 != 0 )
        {
            printf(" %i nota de R$ 100,00 ", N100);    
        }
        
        N50 = (dinheiro % 100) / 50;
        if ( N50 != 0)
        {
            printf(" %i nota de R$ 50,00 ", N50);   
        }
        
        N20 = (dinheiro % 50) / 20;
        if ( N20 != 0) 
        {
            printf(" %i nota de R$ 20,00 ", N20);
        }
        
        N10 = (dinheiro % 50) / 10 ;
        if ( N10 == 1 || N10 == 3 )
        {
            N10 = 1;
            printf(" %i nota de R$ 10,00 ", N10);
        } 
        
    return 0;
}
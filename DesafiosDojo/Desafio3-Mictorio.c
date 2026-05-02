#include <stdio.h>
/*
Um problema enfrentado pelos homens no uso de mictórios em banheiros públicos é o 
constrangimento causado por outro homem urinando no mictório ao lado. 
Uma situação contrangedora é definida quando dois "mijões" deveriam ocupar mictórios adjacentes.

Dada uma quantidade de mictórios em um banheiro e a ocupação inicial deles 
(informando em qual deles já existe um "mijão"), determine quantos "mijões" ainda podem usar 
os mictórios e qual a posição deles antes para que não ocorra uma situação constrangedora.

https://dojopuzzles.com/problems/distribuicao-de-mictorios/
*/

int main()
{
    int mictorio, mijoes, inicio, i ;

    printf("Quantidade de mictorios no banheiro: ");
    scanf("%i", &mictorio);

    printf("Ocupacao inicial do \"mijao\": ");
    scanf("%i", &inicio);

    i = inicio;
    mijoes = (mictorio-inicio)/2 ;

    if (mijoes == 1)
    {
        printf("%i mijao ainda pode usar os mictorios ", mijoes ); 
    }
    else
    {
        printf("%i mijoes ainda podem usar os mictorios ", mijoes );
    }   

    for ( i ; i<= mictorio ; i+= 2)
    {
        if (i != inicio)
        {
            if ( mijoes == 1)
            {
               printf("na posicao %i.", i);               
            }

            else if ( mijoes > 1)
            {
                printf("na posicao %i", i);

                if ( i+1 != mictorio)
                {
                    printf(" e "); 
                }
                
            }
            
        } 
        
    }

    return 0;
}
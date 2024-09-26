/*
DESAFIO DOJO 2 - CAIXA ELETRONICO
Este problema foi utilizado em 1537 Dojo(s).

Desenvolva um programa que simule a entrega de notas quando um cliente efetuar um saque em um caixa eletr�nico. Os requisitos b�sicos s�o os seguintes:

Entregar o menor n�mero de notas;
� poss�vel sacar o valor solicitado com as notas dispon�veis;
Saldo do cliente infinito;
Quantidade de notas infinito (pode-se colocar um valor finito de c�dulas para aumentar a dificuldade do problema);
Notas dispon�veis de R$ 100,00; R$ 50,00; R$ 20,00 e R$ 10,00
Exemplos:

Valor do Saque: R$ 30,00 � Resultado Esperado: Entregar 1 nota de R$20,00 e 1 nota de R$ 10,00.
Valor do Saque: R$ 80,00 � Resultado Esperado: Entregar 1 nota de R$50,00 1 nota de R$ 20,00 e 1 nota de R$ 10,00.
*/

#include <stdio.h>
int solicitaSaque(float saldo);
void contabilizaNotas(int saque);
void exibeQuantidade(int cont100, int cont50, int cont20, int cont10);

void main(){
    float saldo;
    int valorSaque;
    int qtd100=0, qtd10=0, qtd20=0, qtd50=0;
    saldo = 9999.99;
    valorSaque = solicitaSaque(saldo);
    contabilizaNotas(valorSaque);
}

int solicitaSaque(float saldo){
    int valor;
    printf("----PROGRAMA SAQUE----\n");
    printf("Saldo disponivel: %.2f\n", saldo);
    printf("Insira o valor do saque: "); //O valor do saque � inteiro pois n�o � poss�vel sacar moedas.
    scanf("%d", &valor);
    //Como o saldo no problema � infinito, n�o haver� atualiza��o do saldo. Ou seja, n�o ser� descontado o valor do saque.
    return valor;
}

/*
Como as notas no problema s�o infinitas, n�o h� a possibilidade de faltar uma nota.
Portanto, n�o � necess�rio substitu�-la caso esteja faltando.
*/
void contabilizaNotas(int saque){
    int cont100=0, cont50=0, cont20=0, cont10=0;
    while (saque != 0){
        if (saque >= 100){ //Assim, � poss�vel fazer o c�lculo da quantidade de notas, somente dividindo o valor do saque pelo valor das notas.
            cont100=saque/100;
            saque=saque%100; //Atualiza��o do valor do saque para o resto da divis�o por 100, para que seja poss�vel descibrir quais notas faltam.
        } else {
            if (saque >= 50){
                cont50=saque/50;
                saque=saque%50;
            } else {
                if (saque >= 20){
                    cont20=saque/20;
                    saque=saque%20;
                } else {
                     cont10=saque/10;
                    saque=saque%10;
                }
            }
        }
    }
    exibeQuantidade(cont100, cont50, cont20, cont10);
}

//Exibi��o
void exibeQuantidade(int cont100, int cont50, int cont20, int cont10){
    if (cont100!=0){
        printf("\nEntregar %d notas de 100", cont100);
    }
    if (cont50!=0){
        printf("\nEntregar %d notas de 50", cont50);
    }
	if (cont20!=0){
        printf("\nEntregar %d notas de 20", cont20);
	}
	if (cont10!=0){
        printf("\nEntregar %d notas de 10", cont10);
	}
}

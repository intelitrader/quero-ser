/*
DESAFIO DOJO 1 - JOKENPO
Este problema foi utilizado em 2014 Dojo(s).
Jokenpo é uma brincadeira japonesa, onde dois jogadores escolhem um dentre três possíveis itens: Pedra, Papel ou Tesoura.

O objetivo é fazer um juiz de Jokenpo que dada a jogada dos dois jogadores informa o resultado da partida.

As regras são as seguintes:

Pedra empata com Pedra e ganha de Tesoura
Tesoura empata com Tesoura e ganha de Papel
Papel empata com Papel e ganha de Pedra
*/

//Inclusão de bibliotecas
#include <stdio.h>

//Definição de constantes
#define PEDRA 1
#define PAPEL 2
#define TESOURA 3

//Protótipo das funções:
int leituraJogada(int player);
int realizaJogada1();
int realizaJogada2();
void verificaJogada(int escolha1, int escolha2);

//Main
void main(){
    int round1, round2;
    round1 = realizaJogada1();
    round2 = realizaJogada2();
    verificaJogada(round1, round2);
}

int leituraJogada(int player){
    int jogada;
    printf("\nJOGADOR %d: INSIRA SUA JOGADA: \n [1] PEDRA \n [2] PAPEL \n [3] TESOURA \n \t  ESCOLHA: ", player);
    scanf("%d", &jogada);
     if (jogada > 3 || jogada < 1){
        printf("\nINSIRA UMA JOGADA VALIDA: ");
        scanf("%d", &jogada);
    }
    return jogada;
}

int realizaJogada1(){
    int escolha;
    escolha = leituraJogada(1);
    return escolha;
}

int realizaJogada2(){
    int escolha;
    escolha = leituraJogada(2);
    return escolha;
}

void verificaJogada(int escolha1, int escolha2){
    printf ("\n\nRESULTADOS: \t");
    switch(escolha1){
        case PEDRA:
            if (escolha2 == TESOURA) {
                printf ("JOGADOR 1 VENCEU!!");
            } else {
                if (escolha2 == PEDRA) {
                    printf ("EMPATE!!");
                } else {
                    printf ("JOGADOR 2 VENCEU!!");
                }
            }
            break;

        case PAPEL:
            if (escolha2 == PEDRA) {
                printf ("JOGADOR 1 VENCEU!!");
            } else {
                if (escolha2 == PAPEL) {
                    printf ("EMPATE!!");
                } else {
                    printf ("JOGADOR 2 VENCEU!!");
                }
            }
            break;

        case TESOURA:
            if (escolha2 == PAPEL) {
                printf ("JOGADOR 1 VENCEU!!");
            } else {
                if (escolha2 == TESOURA) {
                    printf ("EMPATE!!");
                } else {
                    printf ("JOGADOR 2 VENCEU!!");
                }
            }
            break;
    }
}

#include <iostream>
#include <stdio.h>

int jogador1, jogador2;
/* run this program using the console pauser or add your own getch, system("pause") or input loop */

int main(int argc, char** argv) {
	
		
	printf("Oi, quer participar do nosso jogo? Vamos la.\n");
		printf("O nosso consagrado jogo e o JOKENPO.\n\n");
		
	printf("2 jogarodes terao que escolher entre PEDRA, PAPEL e TESOURA\n");
		printf("PEDRA sera representado pelo numero '1'\n");
			printf("PAPEL sera representado pelo numero '2'\n");
		printf("TESOURA sera representado pelo numero '3'\n");
		printf("O nosso programinha ira exibir o vencedor na tela\n\n");
		printf("Escolha entre PEDRA, PAPEL e TESOURA pelo seu numero correspondente\n\n");
		
		printf("jogador 1: ");
		scanf("%d", &jogador1);
		
		printf("\njogador 2: ");
		scanf("%d", &jogador2);
					
		if(jogador1 >=1 && jogador1 <=3 && jogador2 >=1 && jogador2 <=3 ){
			if(jogador1 != jogador2){
				
				if((jogador1 ==1 && jogador2 == 3) || (jogador1 == 2 && jogador2 == 1) || (jogador1 == 3 && jogador2 == 2)){
					printf("\nJogador 1 venceu\n");
				} else{
					printf("\njogador 2 venceu\n");
				}
				
				
			} else{
				printf("\nEsta partida deu empate\n");
			}
		} else{
			printf("\n\ndados invalidos\n");
		}
				
		


	return 0;
}

#include <stdio.h>

int main()
{
	
	int jog1, jog2 ;
	
	printf( "Digite o numero da jogada, do primeiro jogador:\n1 para Pedra \n2 para Tesoura \n3 para Papel\n");
	scanf("%d" , &jog1 );
	
	printf( "Digite o numero da jogada, do segundo jogador:\n1 para Pedra \n2 para Tesoura \n3 para Papel\n");
	scanf("%d" , &jog2 );
	
	if(jog1 == jog2 || jog2 == jog1 ){
		printf("\nEmpate!");
	} 
	if(jog1 == 1 && jog2 == 2){
		printf("\nPrimeiro jogador Ganhou!");
	} 
	if(jog1 == 1 && jog2 ==3){
		printf("\nSegundo jogador Ganhou!");
	}
	if(jog1 == 2 && jog2 ==1){
		printf("\nSegundo jogador Ganhou!");
	}
	if(jog1 == 2 && jog2 ==3   ){
		printf("\n Primeiro jogador Ganhou!");
	}
	if(jog1 == 3 && jog2 == 1  ){
		printf("\n Primeiro jogador Ganhou!");
	}
	if(jog1 == 3 && jog2  == 2){
		printf("\n Segungo jogador Ganhou!");
	}
	
	return 0 ;
}

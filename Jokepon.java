package primeirodesafio;

import java.util.Scanner;

public class Jokepon {
	
	public static void main(String[] args) {
		
		//1Papel - 2Pedra - 3-Tesoura.
		//j1(1)j2(2) = -1, vencedor jogador1
		//j1(1)j2(3) = -2, vencedor jogador2
		//j1(2)j2(1) =  1, vencedor jogador2
		//j1(2)j2(3) = -1, vencedor jogador1
		//j1(3)j2(1) =  2, vencedor jogador1
		//j1(3)j2(2) =  1, vencedor jogador2
		Scanner in = new Scanner(System.in);
		
		int jogador1;
		int jogador2;
		System.out.println(" Escolha a opção desejada: ");
		System.out.println(" 1 Papel - 2 Pedra - 3 Tesoura. ");
		System.out.println(" Jogador 1 ");
		jogador1 = in.nextInt();
		System.out.println(" Jogador 2 ");
		jogador2 = in.nextInt();
		
		if(jogador1 == jogador2) {
			System.out.println("Empate");
		}
		else if((jogador1 - jogador2) == -1 || (jogador1 - jogador2) == 2) {
			System.out.println("Jogador 1 é o vencedor!!!");
		}
		else {
			System.out.println("Jogador 2 é o vencedor!!!");
		}
		
		
	}
}

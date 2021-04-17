package partida_tenis;

/* Link do desafio: https://dojopuzzles.com/problems/partida-de-tenis/
 * 
 * Author: Luiz Araujo
 * */

import java.util.Random;
import java.util.Scanner;

public class Main {
	static Scanner input = new Scanner(System.in);
	static Random r = new Random();
	public static void main(String[] args) {
		
		Jogador player1 = new Jogador("",0,0,0), player2 = new Jogador("",0,0,0);
		String escolha, piso;
		int setar;
		
		do {
			System.out.println("Setar jogadores, tipo de jogo e tipo de quadra:");
			System.out.println("Entre [0] para AUTOMÁTICO OU [1] para MANUAL");
			setar = input.nextInt();
			input.nextLine();
			if(setar != 0 && setar != 1)
				System.out.println("Entre [A] para AUTOMÁTICO OU [M] para MANUAL");
		}while(setar != 0 && setar != 1);
		
		definirJogadores(player1, player2, setar);
		escolha = escolherPartida(setar);
		piso = escolherPiso(setar);
		
		EstiloPartida estilo = new EstiloPartida(escolha, piso, definirQtdSets(escolha), true);
		Partida partida = new Partida (estilo, player1, player2);
		
		iniciarPartida(player1, player2);
		
		Regras regras = new Regras(partida);
		regras.iniciarSet();
	}
	
	public static void definirJogadores(Jogador player1, Jogador player2, int setar) {
		for(int i = 0; i < 2; i++) {
			System.out.println("Entre o nome do jogador " + (i + 1));
			String nome;
			if(setar == 1)
				nome = input.nextLine();
			else {
				if(i == 0) {
					nome = "Nadal";		
				}
				else
					nome = "Djokovic";
				System.out.println("Nome setado automaticamente para " + nome);
			}
			if(i == 0) {
				player1.setName(nome);
			}else {
				player2.setName(nome);
			}
		}
	}
	
	public static String escolherPartida(int setar) {
		String escolha;
		System.out.println("Escolha o tipo 'Torneio'[T] (até 3 SETS) ou 'GrandSlam'[G] (até 5 SETS)");
		if(setar == 1) {
			do {
				escolha = input.nextLine();
				if(!escolha.equals("T") && !escolha.equals("G"))
					System.out.println("Entre T ou G!");
			}while(!escolha.equals("T") && !escolha.equals("G"));
		}
		else {
			int aux = r.nextInt(2);
			if(aux == 0)
				escolha = "G";
			else
				escolha = "T";
		}
		if(escolha.equals("G"))
			escolha = "GrandSlam";
		else
			escolha = "Torneio";
		return escolha;
	}
	
	public static int definirQtdSets(String s) {
		if(s.equals("GrandSlam"))
			return 5;
		return 3;
	}
	
	public static String escolherPiso(int setar) {
		String escolha;
		System.out.println("Esolha o tipo de piso: [G]Grama, [D]Duro, [S]Saibro: ");
		if(setar == 1) {
			do {
				escolha = input.nextLine();
				if(!escolha.equals("D") && !escolha.equals("G") && !escolha.equals("S"))
				System.out.println("Escolha [G],[D] ou [S]");
			}while(!escolha.equals("D") && !escolha.equals("G") && !escolha.equals("S"));
		}
		else {
			int aux = r.nextInt(3);
			if(aux == 0) 
				escolha = "G";
			else if(aux == 1) 
				escolha = "D";
			else
				escolha = "S";
		}
		
		if(escolha.equals("G"))
			escolha = "Grama";
		else if(escolha.equals("D"))
			escolha = "Duro";
		else
			escolha = "Saibro";
		return escolha;
	}
	
	public static void iniciarPartida(Jogador player1, Jogador player2) {
		Random r = new Random();
		int caraCoroa = r.nextInt(2);
		System.out.println("CARA OU COROA!");
		if(caraCoroa == 0) {
			player1.setSaque(true);
			player2.setSaque(false);
			System.out.println(player1.getName() + " começa sacando!");
			System.out.println(player2.getName() + " começa recebendo!");
		}else {
			player1.setSaque(false);
			player2.setSaque(true);
			System.out.println(player2.getName() + " começa sacando!");
			System.out.println(player1.getName() + " começa recebendo!");
		}
		
	}
}

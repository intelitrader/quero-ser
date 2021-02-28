package poker;

import java.util.Random;
import java.util.Scanner;

/* Link do desafio: https://dojopuzzles.com/problems/poker/
 * 
 * Author: Luiz Araujo
 *
 * */

public class Main {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		Jogador player1 = new Jogador();
		Jogador player2 = new Jogador();
		int escolha;
		
		System.out.println("Entrada de cartas automática[1] ou manual[2]: ");
		do {
			escolha = input.nextInt();
			if(escolha != 1 && escolha != 2)
				System.out.println("Entre 1 para automático e 2 para manual!");
		}while(escolha != 1 && escolha != 2);
		
		if(escolha == 1)
			shuffleAuto(player1, player2);
		else
			shuffleManual(player1, player2);
		
		System.out.println("    JOGADOR 1   |   JOGADOR 2  ");
		System.out.println("============================");
		for (Carta card : player1.ordenarCartas()) {
			System.out.printf(card.toString());
		}
		System.out.printf(" |  ");
		for (Carta card : player2.ordenarCartas()) {
			System.out.printf(card.toString());
		}
		System.out.println();
		Game g1 = new Game(player1);
		Game g2 = new Game(player2);
		System.out.println("");
		System.out.println("JOGADOR 1");
		System.out.println(g1.contagemCartas());
		System.out.println("");
		System.out.println("JOGADOR 2");
		System.out.println(g2.contagemCartas());
		System.out.println("");
		System.out.println("VENCEDOR");
		System.out.println(Game.checkWinner(g1, g2));
		
		input.close();
	}
	
	public static void shuffleAuto(Jogador j, Jogador j2){
		for(int i = 0; j.hand.size() < 5; i++) {
        	Integer num = gerarNumero();
        	String n = gerarNum(num);
        	Carta c = new Carta(gerarNaipe(), n, num);
        	if(checkIfExists(j, c, 1) || checkIfExists(j2, c, 1))
        		continue;        	
		
        	j.addCard(c);
        }
        
        for(int i = 0; j2.hand.size() < 5; i++) {
        	Integer num = gerarNumero();
        	String n = gerarNum(num);
        	Carta c = new Carta(gerarNaipe(), n, num);
        	if(checkIfExists(j, c, 1) || checkIfExists(j2, c, 1))
        		continue; 
        	j2.addCard(c);
        }
	}

	public static void shuffleManual(Jogador j, Jogador j2) {
		String carta, numCarta, naipe;
		String [] aux = new String[2];
		Carta c;
		int i = 0, numeroCarta = 0;
		Scanner input = new Scanner(System.in);
		System.out.println("D-Diamond(Ouro) | H-Hearts(Copas) | S-Spade(Espadas) | C-Clubs(Paus)");
		System.out.println("2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A");
		
		do {
			System.out.println("Carta " + (i + 1) + "/10 - Entre uma carta nesse formato 3D, AS (NUMERO/NAIPE): ");
			carta = input.nextLine().toUpperCase();
		
			if(carta.length() > 2) {
				if(!carta.equals("10D") && !carta.equals("10H") && !carta.equals("10S") && !carta.equals("10C")) {
					System.out.println("Entre uma carta dentro da faixa permitida de número e naipe");
					continue;
				}
				else 
					aux = carta.split("0", 2);
				
				numeroCarta = Integer.parseInt(aux[0]) * 10;
				numCarta = Integer.toString(numeroCarta);
				naipe = aux[1];
				c = new Carta(naipe, numCarta, numeroCarta);
	        	if(checkIfExists(j, c, 0) || checkIfExists(j2, c, 0))
	        		continue;
				if(j.hand.size() == 5)
					j2.addCard(c);
				else
					j.addCard(c);
				i++;
			}else if(carta.length() == 2) {
				aux = carta.split("", 2);
				if(!aux[1].equals("D") && !aux[1].equals("H") && !aux[1].equals("S") && !aux[1].equals("C")) {
					System.out.println("Entre uma carta dentro da faixa permitida de número e naipe");
					continue;
				}
				else {
					if(aux[0].equals("J") || aux[0].equals("Q") || aux[0].equals("K") || aux[0].equals("A")) {
						numCarta = aux[0];
						if(aux[0].equals("A")) 
							numeroCarta = 14;
						else if(aux[0].equals("K")) 
							numeroCarta = 13;
						else if(aux[0].equals("Q"))
							numeroCarta = 12;
						else
							numeroCarta = 11;
						naipe = aux[1];
					}
					else {
						numeroCarta = Integer.parseInt(aux[0]);
						numCarta = Integer.toString(numeroCarta);
						naipe = aux[1];
					}
					c = new Carta(naipe, numCarta, numeroCarta);
		        	if(checkIfExists(j, c, 0) || checkIfExists(j2, c, 0))
		        		continue;
				}
				if(j.hand.size() == 5)
					j2.addCard(c);
				else
					j.addCard(c);
				i++;
			}		
		}while(i < 10);
		
		input.close();
	}
	
	public static boolean checkIfExists(Jogador j, Carta c, int n) {
		for (Carta card : j.hand) {
    		if (c.equals(card)) {
    			if(n == 0)
    				System.out.println("Carta já distribuída!");
    			return true;
    		}
		}
		return false;
	}
	
	public static String gerarNaipe() {
		Random geradorNaipe = new Random();
		int naipe;
		String n;
		naipe = geradorNaipe.nextInt(4);
		if (naipe == 0)
			n = "D";
		else if (naipe == 1)
			n = "H";
		else if (naipe == 2)
			n = "S";
		else
			n = "C";

		return n;
	}
	
	public static int gerarNumero() {
		Random geradorNum = new Random();
		Integer num;
		num = geradorNum.nextInt(13) + 2;
		
		return num;
	}
	
	public static String gerarNum(Integer num) {
		String n;
		if (num == 14)
			n = "A";
		else if (num == 11)
			n = "J";
		else if (num == 12)
			n = "Q";
		else if (num == 13)
			n = "K";
		else
			n = num.toString();
		
		return n;
	}
}

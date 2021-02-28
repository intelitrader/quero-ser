package partida_tenis;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Random;

import poker.Carta;

public class Game {
	public Partida partida;
	public int pontosPlayer1 = 0, pontosPlayer2 = 0, servico = 0;
	public static int game = 0, set = 0;
	int dado;
	List<SetGame> sets = new ArrayList<SetGame>();
	
	public Game(Partida partida) {
		this.partida = partida;
	}
	
	public void saque() {
		if (partida.player1.isSaque()) {
			System.out.println("jogador " + partida.player1.name + " saca");
			partida.player1.setBola(true);
			definirSaque(partida.player1, partida.player2, 0);
		}
		else {
			System.out.println("jogador " + partida.player2.name + " saca");
			partida.player2.setBola(true);
			definirSaque(partida.player2, partida.player1, 0);
		}
		
	}
	
	public void definirSaque(Jogador j1, Jogador j2, int i) {
		Random r = new Random();
		dado = r.nextInt(9);
		if(dado == 0) {
			System.out.println("Falta!");
			if(i == 0) {
				i++;
				System.out.println("Segundo Serviço!");
				definirSaqueStackClean(j1, j2, i);
			}else {
				System.out.println("Dupla falta!");
				ponto(j2, j1);
			}
		}else if(dado == 1) {
			System.out.println("Fora!");
			if(i == 0) {
				i++;
				System.out.println("Segundo Serviço!");
				definirSaqueStackClean(j1, j2, i);
			}else
				ponto(j2, j1);
		}else if(dado == 2) {
			if(i == 0) {
				System.out.println("Rede. Primeiro Serviço!");
				definirSaqueStackClean(j1, j2, i);
			}
			else if(i == 1) {
				System.out.println("Rede. Segundo Serviço!");
				definirSaqueStackClean(j1, j2, i);
			}else
				ponto(j2, j1);
		}else if(dado == 3) {
			System.out.println("Ace.");
			ponto(j1, j2);
		}else if(dado >= 4) {
			System.out.println("Dentro.");
			j1.bola = false;
			j2.bola = true;
			resposta(j1, j2);
		}		
	}
	
	public void definirSaqueStackClean(Jogador j, Jogador j2, int i) {
		definirSaque(j, j2, i);
	}
	
	public void ponto(Jogador j, Jogador j2) {
		if(j.getPonto() == 0)
			j.setPonto(15);
		else if(j.getPonto() == 15)
			j.setPonto(30);
		else if(j.getPonto() == 30)
			j.setPonto(40);
		else if(j.getPonto() == 40){
			if(j2.getPonto() < 40) {
				finishGame(j, j2);
				return;
			}
			else if(j2.getPonto() > 40) {
				j2.setPonto(40);
			}
			else if(j2.getPonto() == j.getPonto())
				j.setPonto(45);
		}
		else if(j.getPonto() == 45) {
			finishGame(j, j2);
			return;
		}
		if(j.isSaque() && j.getPonto() < 45)
			System.out.println(j.getPonto() + " - " + j2.getPonto());
		else if(j.getPonto() == 45)
			System.out.println("Vantagem " + j.getName());
		else if(j2.getPonto() == 45)
			System.out.println("Vantagem " + j2.getName());
		else
			System.out.println(j2.getPonto() + " - " + j.getPonto());
		saque();
		
	}
	
	public void resposta(Jogador j, Jogador j2) {
		Random r = new Random();
		dado = r.nextInt(7);
		System.out.println(j2.name + " responde!");
		if(dado == 0) {
			System.out.println("Fora!");
			ponto(j, j2);
		}
		else if(dado == 1) {
			System.out.println(j2.name + " não conseguiu chegar na bola!");
			ponto(j, j2);
			
		}
		else if(dado == 2) {
			System.out.println("Rede!");
			ponto(j, j2);
		}
		else if(dado >= 3) {
			System.out.println("Dentro!");
			j.setBola(true);
			j2.setBola(false);
			respostaStackClean(j2, j);
		}
	}
	
	public void respostaStackClean(Jogador j, Jogador j2) {
		resposta(j, j2);
	}
	
	public void finishGame(Jogador j, Jogador j2) {
		j.game++;
		System.out.println("Games: " + j.getName() + " " + j.game + " x " + j2.game + " " + j2.getName());
		j.setPonto(0);
		j2.setPonto(0);
		
		if(j.game == 6 && j2.game < 5) {
			SetGame set = new SetGame(partida, j, j2, Game.set);
			sets.add(set);
			set.toString();
			j.set++;
			nextSet(j, j2);
			return;
		}else if(j.game == 7) {
			SetGame set = new SetGame(partida, j, j2, Game.set);
			sets.add(set);
			set.toString();
			j.set++;
			nextSet(j, j2);
			return;
		}
		
		if(j.saque) {
			j.saque = false;
			j2.saque = true;
		}else {
			j.saque = true;
			j2.saque = false;
		}
		
		Game.game++;
		mostrarGameSet();
		saque();
	}
	
	public static void mostrarGameSet() {
		System.out.println("");
		System.out.println("SET " + Game.set + " | GAME: " + Game.game);
		System.out.println("");
	}
	
	public void nextSet(Jogador j, Jogador j2) {
		if(partida.estilo.tipo == "GrandSlam") {
			if(j.set == 3) {
				endMatch(j, j2);
			}
			else {
				zerarSet(j, j2);
			}
		}else {
			if(j.set == 2) {
				endMatch(j, j2);
			}
			else {
				zerarSet(j, j2);
			}
		}
	}
	
	public void zerarSet(Jogador j, Jogador j2) {
		Game.game = 1;
		Game.set++;
		j.game = 0;
		j2.game = 0;
		mostrarGameSet();
		saque();
	}
	
	public void endMatch(Jogador j, Jogador j2) {
		System.out.println("Acabou o jogo!");
		System.out.println("");
		System.out.println("====================");
		System.out.println("RESUMO DO JOGO");
		System.out.println("====================");
		System.out.println("Tipo de jogo: " + partida.estilo.getTipo());
		System.out.println("Tipo de piso: " + partida.estilo.getPiso());
		System.out.println("Jogadores: " + partida.player1.getName() + " " + partida.player1.getSet() + " x " + partida.player2.getSet() + " " + partida.player2.getName());
		System.out.println("Quantidade de sets jogados: " + sets.size());
		System.out.println("====================");
		
		for (SetGame setGame : sets) {
			System.out.println("SET " + setGame.nSet + ": Vencedor -> " + setGame.player1.getName());
			System.out.println(setGame.player1.getName() + " " + setGame.setJ1 + " x " + setGame.setJ2 + " " + setGame.player2.getName());
			System.out.println("");
		}
		
		System.out.println();
	}
}

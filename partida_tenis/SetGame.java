package partida_tenis;

public class SetGame {
	
	public Partida partida;
	public Jogador player1;
	public Jogador player2;
	public int setJ1, setJ2;
	public int nSet;

	public SetGame(Partida partida, Jogador player1, Jogador player2, int nSet) {
		this.partida = partida;
		this.player1 = player1;
		this.player2 = player2;
		this.nSet = nSet;
		this.setJ1 = this.player1.game;
		this.setJ2 = this.player2.game;
	}
	
	public int getnSet() {
		return nSet;
	}
	
	public Jogador getVencedor() {
		return player1;
	}
	
	@Override
	public String toString() {
		return player1.name + "venceu o " + nSet + "º Set.";
	}

}

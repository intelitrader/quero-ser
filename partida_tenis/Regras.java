package partida_tenis;

public class Regras {
	public Partida partida;
	int dados;
	
	
	public Regras(Partida partida) {
		this.partida = partida;
	}

	public void game(Game g) {
		Game.game++;
		Game.gamesTotal++;
		Game.mostrarGameSet();
		g.saque();
	}
	
	public void iniciarSet() {
		Game newGame = new Game(partida);
		Game.set++;
		game(newGame);
	}
}

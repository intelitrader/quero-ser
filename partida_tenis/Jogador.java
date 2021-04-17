package partida_tenis;

public class Jogador {
	public String name;
	public int ponto, game, set;
	public boolean saque, bola;
	
	public Jogador(String name, int ponto, int game, int set) {
		this.name = name;
		this.ponto = ponto;
		this.game = game;
		this.set = set;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public boolean isSaque() {
		return saque;
	}

	public void setSaque(boolean saque) {
		this.saque = saque;
	}

	public boolean isBola() {
		return bola;
	}

	public void setBola(boolean bola) {
		this.bola = bola;
	}

	public int getPonto() {
		return ponto;
	}

	public void setPonto(int ponto) {
		this.ponto = ponto;
	}
	
	public int getSet() {
		return set;
	}
	
	public int getGame() {
		return game;
	}
	
}

package efeito_magnetico;

public class PontoMagnetico extends PontoMouse{
	
	public int raio;

	public PontoMagnetico(int x, int y, int raio) {
		super(x, y);
		this.raio = raio;
	}

	public int getRaio() {
		return raio;
	}
	
}

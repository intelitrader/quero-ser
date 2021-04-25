package problema1;

import java.util.ArrayList;
import java.util.Random;

public class Caso {
	private String assassino;
	private String local;
	private String arma;
	
	public int verificarCaso(String assassinoC,String localC,String armaC) {
		ArrayList<Integer> erros = new ArrayList<Integer>();
		if(!assassinoC.equals(assassino)) {
			erros.add(1);
		}if(!localC.equals(local)) {
			erros.add(2);
		}if(!armaC.equals(arma)) {
			erros.add(3);
		}
		Random gerador = new Random();
		if(erros.size() == 0) {
			return 0;
		}else {
		return erros.get(gerador.nextInt(erros.size()));
		}
	}

	public String getAssassino() {
		return assassino;
	}

	public void setAssassino(String assassino) {
		this.assassino = assassino;
	}

	public String getLocal() {
		return local;
	}

	public void setLocal(String local) {
		this.local = local;
	}

	public String getArma() {
		return arma;
	}

	public void setArma(String arma) {
		this.arma = arma;
	}
	


	
	
	
}

package partida_tenis;

public class EstiloPartida {
		public String tipo;
		public String piso;
		public int qtdSets;
		public boolean tieBreak;
		
		public EstiloPartida(String tipo, String piso, int qtdSets, boolean tieBreak) {
			this.tipo = tipo;
			this.piso = piso;
			this.qtdSets = qtdSets;
			this.tieBreak = tieBreak;
		}

		public String getTipo() {
			return tipo;
		}
		
		public String getPiso() {
			return piso;
		}
		
		public int getQtdSets() {
			return qtdSets;
		}

		public boolean isTieBreak() {
			return tieBreak;
		}
		
		
	}

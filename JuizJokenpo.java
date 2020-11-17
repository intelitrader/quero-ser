package jokenpo;

public class JuizJokenpo {
	
	public String juiz(JogadorJokenpo jogador1, JogadorJokenpo jogador2) {
		
		
		
		if(jogador1.getNumeroEscolha() == jogador2.getNumeroEscolha()) {
			return "Empate entre " + jogador1.getNome() + " e "  + jogador2.getNome() +". " + "Ambos escolheram: " +jogador1.getEscolha();
		}else if(jogador1.getNumeroEscolha() - jogador2.getNumeroEscolha() == -1 || jogador1.getNumeroEscolha() - jogador2.getNumeroEscolha() == 2 ) {
			return "Jogador " + jogador1.getNome() + " ganhou de " + jogador2.getEscolha() + " escolhendo " + jogador1.getEscolha();
		}else {
			
			return "Jogador " + jogador2.getNome() + " ganhou de " + jogador1.getEscolha() + " escolhendo " + jogador2.getEscolha();
		}
		
	}

}

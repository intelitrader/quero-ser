package jokenpo;

public class JogoJokenpo {
	
	public static void main(String[] args) {
		
		JogadorJokenpo jogador1 = new JogadorJokenpo("Artur");
		JogadorJokenpo jogador2 = new JogadorJokenpo("Solange");
		
		int i = (int) ((int) 1 + (Math.random() * 3));
		int x = (int) ((int) 1 + (Math.random() * 3));
		
		
		if(i == 1) {
			jogador1.setEscolha("Papel");
			jogador1.setNumeroEscolha(i);
		}else if(i== 2) {
			jogador1.setEscolha("Pedra");
			jogador1.setNumeroEscolha(i);
		}else if(i== 3) {
			jogador1.setEscolha("Tesoura");
			jogador1.setNumeroEscolha(i);
		}
		
		if(x == 1) {
			jogador2.setEscolha("Papel");
			jogador2.setNumeroEscolha(x);
		}else if(x== 2) {
			jogador2.setEscolha("Pedra");
			jogador2.setNumeroEscolha(x);
		}else if(x== 3) {
			jogador2.setEscolha("Tesoura");
			jogador2.setNumeroEscolha(x);
		}
		
		String resultado = new JuizJokenpo().juiz(jogador1, jogador2);		
		
		System.out.println(jogador1.getNumeroEscolha() + " vs " + jogador2.getNumeroEscolha());
		System.out.println(resultado);
		
	}
	

}

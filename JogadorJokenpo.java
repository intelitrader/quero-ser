package jokenpo;

public class JogadorJokenpo {
	
	private String nome;
	private String escolha;
	private int numeroEscolha;
	
	
	
	
	public int getNumeroEscolha() {
		return numeroEscolha;
	}
	public void setNumeroEscolha(int numeroEscolha) {
		this.numeroEscolha = numeroEscolha;
	}
	public JogadorJokenpo(String nome) {
		this.nome = nome;
	}
	public String getNome() {
		return nome;
	}
	public void setNome(String nome) {
		this.nome = nome;
	}
	public String getEscolha() {
		return escolha;
	}
	public void setEscolha(String escolha) {
		this.escolha = escolha;
	}
	
	

}

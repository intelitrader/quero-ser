package Solucao;

import java.util.Objects;

public class Produto {
	
	//Código do Produto
	private int codProduto;
	//Quantidade em estoque no início do período
	private int quantEstoque;
	//Quantidade mínima que deve ser mantida no Centro Operacional
	private int quantMin;
	
	public Produto() {
		
	}
	
	public Produto(int codProduto, int quantEstoque, int quantMin) {
		super();
		this.codProduto = codProduto;
		this.quantEstoque = quantEstoque;
		this.quantMin = quantMin;
	}

	public int getCodProduto() {
		return codProduto;
	}
	public void setCodProduto(int codProduto) {
		this.codProduto = codProduto;
	}
	public int getQuantEstoque() {
		return quantEstoque;
	}
	public void setQuantEstoque(int quantEstoque) {
		this.quantEstoque = quantEstoque;
	}
	public int getQuantMin() {
		return quantMin;
	}
	public void setQuantMin(int quantMin) {
		this.quantMin = quantMin;
	}
	
	@Override
	public int hashCode() {
		return Objects.hash(codProduto);
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Produto other = (Produto) obj;
		return Objects.equals(codProduto, other.codProduto);
	}

	@Override
	public String toString() {
		return "Produto [codProduto=" + codProduto + ", quantEstoque=" + quantEstoque + ", quantMin=" + quantMin + "]";
	}
	
	

}

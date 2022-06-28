package Solucao;

import java.util.Objects;

public class Venda {
	
	private int codProduto;
	private int quantVendida;
	private SituacaoVenda situacaoVenda;
	private CanalVenda canalVenda;
	
	public Venda() {
		
	}
	
	
	public Venda(int codProduto, int quantVendida, SituacaoVenda situacaoVenda, CanalVenda canalVenda) {
		super();
		this.codProduto = codProduto;
		this.quantVendida = quantVendida;
		this.situacaoVenda = situacaoVenda;
		this.canalVenda = canalVenda;
	}


	public int getCodProduto() {
		return codProduto;
	}

	public void setCodProduto(int codProduto) {
		this.codProduto = codProduto;
	}

	public int getQuantVendida() {
		return quantVendida;
	}

	public void setQuantVendida(int quantVendida) {
		this.quantVendida = quantVendida;
	}

	public SituacaoVenda getSituacaoVenda() {
		return situacaoVenda;
	}

	public void setSituacaoVenda(SituacaoVenda situacaoVenda) {
		this.situacaoVenda = situacaoVenda;
	}

	public CanalVenda getCanalVenda() {
		return canalVenda;
	}

	public void setCanalVenda(CanalVenda canalVenda) {
		this.canalVenda = canalVenda;
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
		Venda other = (Venda) obj;
		return Objects.equals(codProduto, other.codProduto);
	}

	@Override
	public String toString() {
		return "Venda [codProduto=" + codProduto + ", QuantVendida=" + quantVendida + ", situacaoVenda=" + situacaoVenda
				+ ", canalVenda=" + canalVenda + "]";
	}
	
	
}

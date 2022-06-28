package Solucao;

import java.util.Objects;

public class Transfere {
	
	private int codProduto;
	private int qtCO;
	private int qtMin;
	private int qtVendas;
	private int estoquePosVendas;
	private int necess;
	private int transfArmCO;
	
	public Transfere() {
		
	}

	public Transfere(int codProduto, int qtCO, int qtMin, int qtVendas, int estoquePosVendas, int necess,
			int transfArmCO) {
		super();
		this.codProduto = codProduto;
		this.qtCO = qtCO;
		this.qtMin = qtMin;
		this.qtVendas = qtVendas;
		this.estoquePosVendas = estoquePosVendas;
		this.necess = necess;
		this.transfArmCO = transfArmCO;
	}
	
	

	public int getCodProduto() {
		return codProduto;
	}

	public void setCodProduto(int codProduto) {
		this.codProduto = codProduto;
	}

	public int getQtCO() {
		return qtCO;
	}

	public void setQtCO(int qtCO) {
		this.qtCO = qtCO;
	}

	public int getQtMin() {
		return qtMin;
	}

	public void setQtMin(int qtMin) {
		this.qtMin = qtMin;
	}

	public int getQtVendas() {
		return qtVendas;
	}

	public void setQtVendas(int qtVendas) {
		this.qtVendas = qtVendas;
	}

	public int getEstoquePosVendas() {
		return estoquePosVendas;
	}

	public void setEstoquePosVendas(int estoquePosVendas) {
		this.estoquePosVendas = estoquePosVendas;
	}

	public int getNecess() {
		return necess;
	}

	public void setNecess(int necess) {
		this.necess = necess;
	}

	public int getTransfArmCO() {
		return transfArmCO;
	}

	public void setTransfArmCO(int transfArmCO) {
		this.transfArmCO = transfArmCO;
	}

	@Override
	public String toString() {
		return "Transfere [codProduto=" + codProduto + ", qtCO=" + qtCO + ", qtMin=" + qtMin + ", qtVendas=" + qtVendas
				+ ", estoquePosVendas=" + estoquePosVendas + ", necess=" + necess + ", transfArmCO=" + transfArmCO
				+ "]";
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
		Transfere other = (Transfere) obj;
		return Objects.equals(codProduto, other.codProduto);
	}
	
	

}

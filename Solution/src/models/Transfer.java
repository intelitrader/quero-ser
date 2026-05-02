package models;

public class Transfer {
	private int productCode;
	private int quantityCO;
	private int quantitytMin;
	private int quantitySales;
	private int storageAfterSales;
	private int necessity;
	private int transferred;
	
	public Transfer(int productCode) {
		this.productCode = productCode;
		this.necessity = 0;
		this.transferred = 0;
		this.quantitySales = 0;
	}
	
	public int getProductCode() {
		return productCode;
	}
	
	public void setProductCode(int productCode) {
		this.productCode = productCode;
	}
	
	public int getQuantityCO() {
		return quantityCO;
	}
	
	public void setQuantityCO(int quantityCO) {
		this.quantityCO = quantityCO;
	}
	
	public int getQuantitytMin() {
		return quantitytMin;
	}
	
	public void setQuantitytMin(int quantitytMin) {
		this.quantitytMin = quantitytMin;
	}
	
	public int getQuantitySales() {
		return quantitySales;
	}
	
	public void addSales(int quantity) {
		this.quantitySales += quantity;
	}
	
	public int getStorageAfterSales() {
		return storageAfterSales;
	}
	
	private void refreshStorageAfterSales() {
		this.storageAfterSales = quantityCO - quantitySales;
	}
	
	public int getNecessity() {
		return necessity;
	}
	
	private void refreshNecessity() {
		if(storageAfterSales < quantitytMin) {
			this.necessity = quantitytMin - storageAfterSales;
		}
	}
	
	public int getTransferred() {
		return transferred;
	}
	
	private void refreshTransferred() {
		if(necessity > 0) {
			this.transferred = necessity < 10 ? 10 : necessity;
		} 
	}
	
	// Este método gera os dados para os campos:
	// storageAfterSales, necessity, transferred
	public void makeAnalysis() {
		refreshStorageAfterSales();
		refreshNecessity();
		refreshTransferred();
	}

	@Override
	public String toString() {
		return String.format("%-8d\t%-8d\t%-8d\t%-8d\t%-8d\t%-8d\t%-8d\t\n", 
				productCode,
				quantityCO,
				quantitytMin,
				quantitySales,
				storageAfterSales,
				necessity,
				transferred
				);
	}
	
	
}

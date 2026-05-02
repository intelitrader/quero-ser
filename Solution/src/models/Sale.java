package models;

import enums.SaleChannel;
import enums.SaleSituation;

public class Sale {
	private int productCode;
	private int quantity;
	private SaleSituation situation;
	private SaleChannel channel;
	
	public Sale(String[] sale) {
		this.setProductCode(Integer.parseInt(sale[0]));
		this.setQuantity(Integer.parseInt(sale[1]));
		this.setSituation(Integer.parseInt(sale[2]));
		this.setChannel(Integer.parseInt(sale[3]));
	}
	
	public int getProductCode() {
		return productCode;
	}
	
	public void setProductCode(int productCode) {
		this.productCode = productCode;
	}
	
	public int getQuantity() {
		return quantity;
	}
	
	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}
	
	public SaleSituation getSituation() {
		return situation;
	}
	
	public void setSituation(int situation) {
		switch(situation) {
			case 100:
				this.situation = SaleSituation.SALE_CONFIRMED_AND_APPROVED;
				break;
				
			case 102:
				this.situation = SaleSituation.SALE_CONFIRMED;
				break;
				
			case 135:
				this.situation = SaleSituation.SALE_CALCELED;
				break;
				
			case 190:
				this.situation = SaleSituation.SALE_NOT_FINALIZED;
				break;
				
			case 999:
			default:
				this.situation = SaleSituation.UNKNOWN_ERROR;
				break;
		}
	}
	
	public SaleChannel getChannel() {
		return channel;
	}
	
	public void setChannel(int channel) {
		switch (channel) {
			case 1:
				this.channel = SaleChannel.TRADE_REPRESENTATIVE;
				break;
			case 2:
				this.channel = SaleChannel.WEBSITE;
				break;
			case 3:
				this.channel = SaleChannel.ANDROID_APP;
				break;
			case 4:
				this.channel = SaleChannel.IPHONE_APP;
				break;
		}
	}

	@Override
	public String toString() {
		return "Sale [productCode=" + productCode + ", quantity=" + quantity + ", situation=" + situation + ", channel="
				+ channel + "]";
	}
	
}

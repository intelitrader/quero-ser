package models;

import enums.SaleChannel;
import utils.ResponseStucture;

public class SalesPerChannel {
	private int representative;
	private int website;
	private int android;
	private int iphone;
	
	public SalesPerChannel() {
		this.representative = 0;
		this.website = 0;
		this.android = 0;
		this.iphone = 0;
	}
	
	public void addSales(SaleChannel channel, int quatity) {
		switch (channel) {
			case TRADE_REPRESENTATIVE:
				representative += quatity;
				break;
			case WEBSITE:
				website += quatity;
				break;
			case ANDROID_APP:
				android += quatity;
				break;
			case IPHONE_APP:
				iphone += quatity;
				break;
		}
	}

	@Override
	public String toString() {
		return String.format(
					ResponseStucture.SALES_CHANNEL_STRUCTURE,
					representative, 
					website, 
					android, 
					iphone
				);
	}
	
	
}

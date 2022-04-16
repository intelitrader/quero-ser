package models;

public class Product {
	private int code;
	private int storageQuantity;
	private int minQuantity;
	
	public Product(String[] data) {
		this.setCode(Integer.parseInt(data[0]));
		this.setStorageQuantity(Integer.parseInt(data[1]));
		this.setMinQuantity(Integer.parseInt(data[2]));
	}
	
	public int getCode() {
		return code;
	}
	
	public void setCode(int code) {
		this.code = code;
	}
	
	public int getStorageQuantity() {
		return storageQuantity;
	}
	
	public void setStorageQuantity(int storageQuantity) {
		this.storageQuantity = storageQuantity;
	}
	
	public int getMinQuantity() {
		return minQuantity;
	}
	
	public void setMinQuantity(int minQuantity) {
		this.minQuantity = minQuantity;
	}

	@Override
	public String toString() {
		return "Product [code=" + code + ", storageQuantity=" + storageQuantity + ", minQuantity=" + minQuantity + "]";
	}
	
}

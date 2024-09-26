import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;

import models.Product;
import models.Sale;
import models.SalesPerChannel;
import models.Transfer;
import utils.DivergenceMessages;
import utils.Utils;

public class Report {
	private HashMap<Integer, Product> products = new HashMap<Integer, Product>();
	private ArrayList<Sale> sales = new ArrayList<Sale>();
	private HashMap<Integer, Transfer> transfers = new HashMap<Integer, Transfer>();
	private ArrayList<String> divergences = new ArrayList<String>();
	private SalesPerChannel salesPerChannel = new SalesPerChannel();
	
	private void getData(String productsFilePath, String salesFilePath) {
		try {
			ArrayList<String[]> products = Utils.readInputFile(productsFilePath);
			
			for(String[] product: products) {
				Product p = new Product(product);
				this.products.put(p.getCode(), p);
			}
			
			ArrayList<String[]> sales = Utils.readInputFile(salesFilePath);
			
			for(String[] sale: sales)
				this.sales.add(new Sale(sale));
			
		} catch (IOException e) {
			System.out.println("Error while trying to read files: ");
			System.out.println(e);
		}
	}
	
	public void generateReports(String productsFilePath, String salesFilePath) {
		getData(productsFilePath, salesFilePath);
		
		int line = 1;
		for(Sale sale: sales) {
			switch (sale.getSituation()) {
				case SALE_CONFIRMED_AND_APPROVED:
				case SALE_CONFIRMED:
					if(!products.containsKey(sale.getProductCode())) {
						divergences.add(String.format(
								DivergenceMessages.PRODUCT_DOES_NOT_EXIST, line, sale.getProductCode()));
					} else {
						registerTransfer(sale);
					}
					
					salesPerChannel.addSales(
							sale.getChannel(), 
							sale.getQuantity()
						);
					break;
				case SALE_CALCELED:
					divergences.add(String.format(DivergenceMessages.SALE_CANCELED, line));
					break;
				case SALE_NOT_FINALIZED:
					divergences.add(String.format(DivergenceMessages.SALE_NOT_FINALIZED, line));
					break;
				case UNKNOWN_ERROR:
					divergences.add(String.format(DivergenceMessages.UNKNOWN_ERROR, line));
					break;
				default:
					break;
			}
					
			line++;
		}
	}
	
	private void registerTransfer(Sale sale) {
		int code = sale.getProductCode();
		
		Transfer transfer;
		Product product = products.get(code);
		
		if(!transfers.containsKey(code)) {
			transfer = new Transfer(code);
			transfer.setQuantityCO(product.getStorageQuantity());
			transfer.setQuantitytMin(product.getMinQuantity());
			
			transfers.put(code, transfer);
		} else {
			transfer = transfers.get(code);
		}
		
		transfer.addSales(sale.getQuantity());
		transfer.makeAnalysis();
	}

	public void registerReports() {
		try {
			ReportWriter rw = new ReportWriter(transfers, divergences, salesPerChannel);
			rw.register();
		} catch(IOException e) {
			System.out.println("Falha ao tentar escrever o arquivo de saida");
		}
	}
	
}

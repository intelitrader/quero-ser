package utils;

public class ResponseStucture {
	public static final String SALES_CHANNEL_STRUCTURE = 
			"Quantidades de Vendas por canal\n"
			+ "\n"
			+ "1 - Representantes		%-5d\n"
			+ "2 - Website			%-5d\n"
			+ "3 - App móvel Android		%-5d\n"
			+ "4 - App móvel iPhone		%-5d\n";
	
	public static final String TRANSFER_HEADER = 
			String.format("Necessidade de Transferência Armazém para CO\n\n"
			+ "%-8s\t%-8s\t%-8s\t%-8s\t%-8s\t%-8s\t%-8s\n"
			+ "\t\t\t\t\t\t\t\t%-8s\t\t\t%-8s\n",
			
			"Produto", "QtCO", "QtMin", "QtVendas", "Estq.após", "Necess.", "Transf. de", "Vendas", "Arm p/ CO");
}

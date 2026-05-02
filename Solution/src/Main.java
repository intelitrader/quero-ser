import java.io.IOException;


public class Main {
	public static void main(String[] args) throws IOException {
		Report report = new Report();
		report.generateReports("inputs/c1_produtos.txt", "inputs/c1_vendas.txt");
		//report.generateReports("inputs/c2_produtos.txt", "inputs/c2_vendas.txt");
		report.registerReports();
	}
}

import java.util.Scanner;


public class Main {

	public static void main(String[] args) {
		
		Scanner sc = new Scanner(System.in);
		
		int quant, n10, n20, n50, n100;
		
		System.out.println("Quantidade de notas: ");
		quant = sc.nextInt();
		System.out.println("Saque R$ " +quant);
		
		n100 = quant / 100;
		quant = quant % 100;
		n50 = quant / 50;
		quant = quant % 50;
		n20 = quant / 20;
		quant = quant % 20;
		n10 = quant /10;
		quant = quant % 10;
		
		
		System.out.println("Entregar = " +n100+ " nota(s) de R$100 + " +n50+ " nota(s) de R$50 + " +n20+ " nota(s) de R$20 + "  +n10+ " nota(s) de R$10.");
		sc.close();
	}

}


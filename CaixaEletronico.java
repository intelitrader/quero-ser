package terceirodesafio;

import java.util.Scanner;

public class CaixaEletronico {
	
	public static void main(String[] args) {
		
		Scanner in = new Scanner(System.in);
		int Cnota100 = 0;
		int Cnota50 = 0;
		int Cnota20 = 0;
		int Cnota10 = 0;
		int saque;
		int saquetot;
		System.out.println("=               Caixa eletronico            =");
		System.out.println("=============================================");
		System.out.println("Notas Disponiveis para saque: 100, 50, 20, 10");
		System.out.println("=============================================");
		System.out.println("Digite o valor do saque: ");
		saque = in.nextInt();
		saquetot = saque;
		while(saque >= 100) {
			saque = saque - 100;			
			Cnota100++;
		}
		while(saque >= 50) { 
			
			saque = saque - 50;
			Cnota50++;
		}
		while(saque >= 20) {
			
			saque = saque - 20;
			Cnota20++;
		}
		while(saque >= 10) {
			
			saque = saque - 10;
			Cnota10++;
		}
		System.out.println("Valor do saque: R$" + saquetot + " Notas Distribuidos: " + Cnota100 + " Notas de R$100, " + Cnota50 + " Notas de R$50,");
		System.out.println( Cnota20 + " Notas de R$20, " + Cnota10 + " Notas de R$10,");
		
	}
}
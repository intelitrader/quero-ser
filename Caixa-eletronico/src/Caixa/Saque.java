package Caixa;

import java.util.Scanner;

import javax.swing.JOptionPane;

public class Saque {
	public static void main(String[] args) {
		
		Scanner entrada = new Scanner(System.in);
		
		// Inicio da interacao com o usuario
		System.out.println("Notas disponíveis: 100, 50, 20 e 10");
		String novoSaque = JOptionPane.showInputDialog("Deseja Fazer um novo saque? S(sim), N(não");
		
		int n100;
		int n50;
		int n20;
		int n10;
		
		// laco de repeticao caso o usuario queira fazer mais de um saque
		while (novoSaque.equalsIgnoreCase("sim")) {
			
			System.out.println("Qual o valor?");
			int valor = entrada.nextInt();
	
			//logica realizada para contar as cedulas com menor quantidade de notas possiveis
			n100 = valor / 100;
			valor = valor % 100;
			n50 = valor / 50;
			valor = valor % 50;
			n20 = valor / 20;
			valor = valor % 20;
			n10 = valor /10;
			valor = valor % 10;
		

			System.out.println("será entregue "+ n100 +
				" nota(s) de R$100, + " + n50 +
				" nota(s) de R$50, + " + n20 +
				" nota(s) de R$20 e + "  + n10 +
				" nota(s) de R$10.\n"); 
		
			novoSaque = JOptionPane.showInputDialog("Deseja Fazer um novo saque? S(sim), N(não");
		}
		entrada.close();
	
	}

}

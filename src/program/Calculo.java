package program;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

// https://dojopuzzles.com/problems/calculando-estatisticas-simples/

public class Calculo {

	public static void main(String[] args) {
		
		List<Double> listN = new ArrayList<>();
		
		Scanner sc = new Scanner(System.in);
		
		System.out.print("Digite a sequencia de numeros separados por (,):" );
		String list = sc.nextLine();
		String [] array = list.split(",");
		
		int elementos = array.length;
		
		for(int i = 0; i < array.length; i++) {
			listN.add(Double.parseDouble(array[i]));
		}
		
		double menor = listN.get(0);
		double maior = listN.get(0);
		double soma = 0;
		
		for(Double n : listN) {
			if(n >= maior) {
				maior = n;
			}
			if (n <= menor) {
				menor = n;
			}
			soma += n;
		}
	
		double media = soma / elementos;
		
		System.out.printf("Valor minimo: %.0f%n" , menor);
		System.out.printf("Valor maximo: %.0f%n" , maior);
		System.out.println("Numero de elementos da sequencia:" + elementos);
		System.out.printf("Valor medio: %.2f", media);
		sc.close();
	}

}

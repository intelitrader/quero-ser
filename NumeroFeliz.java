package principal;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/*
 * 
 * desafio: Números Felizes
 * url: https://dojopuzzles.com/problems/numeros-felizes/
 * Autor do desafio: Marianna Reis
 * 
 */

public class NumeroFeliz {

	public static void main(String[] args) {

		try (Scanner scn = new Scanner(System.in)){
			
			System.out.print("Digite um número para saber se é triste ou feliz: ");
			Integer numero = scn.nextInt();
			
			verificarNumero(numero);
			
		} catch (Exception e) {
           System.out.println("Digite um numero válido.");
		}

	}

	public static void verificarNumero(Integer num) {
		
		Integer numParaExibir = num;
		
		List<Integer> verificarNumero = new ArrayList<>();

		Integer aux = 0;
		while (num > 1) {

			if (verificarNumero.contains(num)) {
				System.out.println("O número " + numParaExibir + " é triste.");
				break;
			}

			aux = 0;

			verificarNumero.add(num);

			while (num != 0) {
				aux = aux + ((int) Math.pow((num % 10), 2));
				num = (int) num / 10;
			}
			num = aux;
		}

		if (num == 1) {
			System.out.println("O número " + numParaExibir + " é feliz.");
		}
	}

}

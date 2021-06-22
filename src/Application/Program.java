package Application;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

import Entities.caixaeletronico.CachMachine;
import Entities.estatisticaSimples.Numbers;
import Entities.troco.Transaction;

public class Program {

	public static void main(String[] args) throws Exception {
		Scanner sc = new Scanner(System.in);

		/* Desafio 1º https://dojopuzzles.com/problems/troco/ */

		Transaction transaction = new Transaction();
		System.out.println("Informe o Valor total da compra ##.##");
		double total = Double.parseDouble(sc.nextLine());
		System.out.println("Informe o Valor recebido ##.##");
		double received = Double.parseDouble(sc.nextLine());
		transaction.toPerformTransaction(total, received);

		/*
		 * Desafio 2º https://dojopuzzles.com/problems/calculando-estatisticas-simples/
		 */

		List<Integer> integers = new ArrayList<>();
		Numbers numbers = new Numbers();

		char aswer = 's';
		while (aswer == 's') {
			System.out.println("Informe o número inteiro que deseja adicionar: ");
			int number = sc.nextInt();
			integers.add(number);
			System.out.println("Deseja continuar? s/n");
			aswer = sc.next().charAt(0);
		}
		numbers.minValue(integers);
		numbers.maxValue(integers);
		numbers.quantitynumbers(integers);
		numbers.averageNumbers(integers);

		System.out.println("Menor Número: " + numbers.getMin());
		System.out.println("Maior Número: " + numbers.getMax());
		System.out.println("Quantidade de numeros: " + numbers.getNumbersQuantity());
		System.out.println("Média entre os números: " + numbers.getAverage());

		/* Desafio 3 https://dojopuzzles.com/problems/caixa-eletronico/ */

		CachMachine cachMachine = new CachMachine();
		System.out.println("Informe o Valor inteiro de Saque");
		double money = Double.parseDouble(sc.nextLine());
		transaction.toCalculeBankNotes(money);

	}

}

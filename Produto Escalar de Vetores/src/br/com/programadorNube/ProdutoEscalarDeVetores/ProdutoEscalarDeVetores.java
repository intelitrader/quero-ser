package br.com.programadorNube.ProdutoEscalarDeVetores;

import java.util.Random;

//https://dojopuzzles.com/problems/produto-escalar-de-vetores/

public class ProdutoEscalarDeVetores {
	public static void main(String[] args) {
		
		Random gerador = new Random();
		
		int tam = 10;
		
		Integer[] a = new Integer[tam];
		Integer[] b = new Integer[tam];
		Integer[] mult = new Integer[tam];
		
		for (int i = 0; i < a.length; i++) {
			a[i] = 	gerador.nextInt(30);
		}
		
		for (int i = 0; i < b.length; i++) {
			b[i] = 	gerador.nextInt(30);
		}
		
		for (int i = 0; i < a.length; i++) {
			mult[i] = a[i] * b[i];
			System.out.println("a: " + a[i] + " x b: " + b[i] + " = " + mult[i]);
		}
		
		
	}
}

package program;

import java.util.Scanner;
// https://dojopuzzles.com/problems/entre-letras/

public class LapsoLetras {

	public static void main(String[] args) {
		
		Scanner sc = new Scanner(System.in);
		
		String [] lista = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
				
		System.out.println("Didite a letras do alfabeto e descubra o espaco entre elas!!!");
		System.out.print("Digite a primeira letra do alfabeto: ");
		String primeira = sc.nextLine().toUpperCase();
		System.out.print("Digite a segunda letra do alfabeto: ");
		String segunda = sc.nextLine().toUpperCase();
		
		int n1 = 0;
		int n2 = 0;
		
		for(int i = 0; i<= 25 ; i++) {
			if( lista[i].equals(primeira)) {
				n1 = i + 1;
			}
		}
		for(int i = 0 ; i<= 25; i++) {
			if(lista[i].equals(segunda)) {
				n2 = i;
			}
		}
		int resultado = (n2-n1);
		
		if(resultado >= 0) {
			System.out.println("De " + primeira + " ate a letra " + segunda + " = "+ resultado + ".");
		}else {
			System.out.println("Nao esta em ordem alfabetica.");
		}
		
		sc.close();
	}

}

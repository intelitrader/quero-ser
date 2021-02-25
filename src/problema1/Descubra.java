package problema1;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;

/*
 * Problema: https://dojopuzzles.com/problems/descubra-o-assassino/
 * Programador: Roberto da Silva Mitsunari
 */
public class Descubra {
	public static void main(String[] args) {
		Caso caso = new Caso();
		ArrayList<String> suspeitos = new ArrayList<String> (Arrays.asList(
				  "Charles B. Abbage",
				  "Donald Duck Knuth",
				  "Ada L. Ovelace",
				  "Alan T. Uring",
				  "Ivar J. Acobson",
				  "Ras Mus Ler Dorf"));
		ArrayList<String> locais = new ArrayList<String> (Arrays.asList(
				"Redmond",
				"Palo Alto",
				"San Francisco",
				"Tokio",
				"Restaurante no Fim do Universo",
				"São Paulo",
				"Cupertino",
				"Helsinki",
				"Maida Vale",
				"Toronto"));
		ArrayList<String> armas = new ArrayList<String> (Arrays.asList(
				"Peixeira",
				"DynaTAC 8000X (o primeiro aparelho celular do mundo)",
				"Trezoitão",
				"Trebuchet",
				"Maça",
				"Gládio"));
		
		System.out.println("Digite um número de 1 a 6 para escolher um assassino");
		System.out.println("Opções: \r\n"
				+ "0: Charles B. Abbage\r\n"
				+ "1: Donald Duck Knuth\r\n"
				+ "2: Ada L. Ovelace\r\n"
				+ "3: Alan T. Uring\r\n"
				+ "4: Ivar J. Acobson\r\n"
				+ "5: Ras Mus Ler Dorf");
		Scanner sc = new Scanner(System.in);
		caso.setAssassino(suspeitos.get(sc.nextInt()));
		System.out.println("Digite um número de 1 a 10 para escolher um local");
		System.out.println("Opções: "
				+ "0:Redmond\r\n"
				+ "1: Palo Alto\r\n"
				+ "2: San Francisco\r\n"
				+ "3: Tokio\r\n"
				+ "4: Restaurante no Fim do Universo\r\n"
				+ "5: São Paulo\r\n"
				+ "6: Cupertino\r\n"
				+ "7: Helsinki\r\n"
				+ "8: Maida Vale\r\n"
				+ "9: Toronto");
		caso.setLocal(locais.get(sc.nextInt()));
		System.out.println("Digite um número de 1 a 6 para escolher uma arma");
		System.out.println("Opções: \r\n"
				+ "0: Peixeira\r\n"
				+ "1: DynaTAC 8000X (o primeiro aparelho celular do mundo)\r\n"
				+ "2: Trezoitão\r\n"
				+ "3: Trebuchet\r\n"
				+ "4: Maça\r\n"
				+ "5: Gládio");
		caso.setArma(armas.get(sc.nextInt()));
		int resultado, randAssa,  randLocal, randArma;
		Random gerador = new Random();

		randAssa = gerador.nextInt(suspeitos.size());
		randLocal = gerador.nextInt(locais.size());
		randArma = gerador.nextInt(armas.size());
		int x = 0;
		do {
			resultado = caso.verificarCaso(suspeitos.get(randAssa), locais.get(randLocal), armas.get(randArma));
			System.out.println("Assa " + randAssa + " local: " + randLocal + " arma:" + randArma);
			System.out.println(" ===================== resultado da tentativa: " + resultado + " =====================");
			System.out.println("Suspeito: " + suspeitos.get(randAssa));
			System.out.println("Local: " + locais.get(randLocal));
			System.out.println("Arma: " + armas.get(randArma));
			
			/*Quando uma suspeita tanto de arma, local ou assassino é confirmada, ela é retirada do array para q n seja
			* chutada novamente
			*/
			if(resultado == 1) {
				if(suspeitos.size() > 1) {
					suspeitos.remove(randAssa);
					randAssa = gerador.nextInt(suspeitos.size());
				}
			}if(resultado == 2) {
				if(locais.size() > 1) {
					locais.remove(randLocal);
					randLocal = gerador.nextInt(locais.size());
				}
			}if(resultado == 3) {
				if(armas.size() > 1) {
					armas.remove(randArma);
					randArma = gerador.nextInt(armas.size());
				}
			}
			x++;
		}while(resultado != 0 && x <= 100);
		System.out.println("Tentativas: " + x);
		
	}

}

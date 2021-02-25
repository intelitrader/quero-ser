package problema3;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

/*
 * Problema: https://dojopuzzles.com/problems/encontre-o-telefone/
 * Programador: Roberto da Silva Mitsunari
 */

public class Telefone {
	public static void main(String[] args) {
		
		//Hash map para vincular cada letra ao seu respectivo número
		//Criei vários objetos "numeros" para as letras referenciem ao msm objeto
		Map<String, Integer> siglas = new HashMap<String, Integer>();
		Integer dois = new Integer(2);
		siglas.put("A", dois);
		siglas.put("B", dois);
		siglas.put("C", dois);
		Integer tres = new Integer(3);
		siglas.put("D", tres);
		siglas.put("E", tres);
		siglas.put("F", tres);
		Integer quatro = new Integer(4);
		siglas.put("G", quatro);
		siglas.put("H", quatro);
		siglas.put("I", quatro);
		Integer cinco = new Integer(5);
		siglas.put("J", cinco);
		siglas.put("K", cinco);
		siglas.put("L", cinco);
		Integer seis = new Integer(6);
		siglas.put("M", seis);
		siglas.put("N", seis);
		siglas.put("O", seis);
		Integer sete = new Integer(7);
		siglas.put("P", sete);
		siglas.put("Q", sete);
		siglas.put("R", sete);
		siglas.put("S", sete);
		Integer oito = new Integer(8);
		siglas.put("T", oito);
		siglas.put("U", oito);
		siglas.put("V", oito);
		Integer nove = new Integer(9);
		siglas.put("W", nove);
		siglas.put("X", nove);
		siglas.put("Y", nove);
		siglas.put("Z", nove);
		
		String entrada;
		Scanner sc = new Scanner(System.in);
		do {
			StringBuffer saida = new StringBuffer();
			entrada = sc.next();
			if (entrada.length() >= 1 && entrada.length() <= 30) {
				String[] letras = entrada.split("");
				for (String letra : letras) {
					if (letra.matches("[A-Z]")) {
						saida.append(siglas.get(letra));
					} else {
						saida.append(letra);
					}
				}
				System.out.println(saida);
			}else {
				System.out.println("Entrada inválida");
			}
		} while (!entrada.equals("EOF"));
	}
}

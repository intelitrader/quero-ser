import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Scanner;
import java.util.Set;

public class DependenciasTransitivas {

	Map<String, StringBuffer> listas = new HashMap<String,StringBuffer>();
	
	
	public void init() {
		Scanner in = new Scanner (System.in);
		
		listas.put("A", new StringBuffer());
		listas.put("B", new StringBuffer());
		listas.put("C", new StringBuffer());
		listas.put("D", new StringBuffer());
		listas.put("E", new StringBuffer());
		listas.put("F", new StringBuffer());
		
		
		for(int i = 0; i<6; i++) {
			String linha = in.nextLine();
			depDireta(linha);
		}
		

		for (String chave : listas.keySet()) { 
			
			StringBuffer valorAntigo = listas.get(chave);
			
			listas.replace(chave, new StringBuffer(eliminaRepetida(valorAntigo)));
			
			StringBuffer valorNovo = listas.get(chave);

            System.out.println(chave + " " + valorNovo);
        }
	}
	
	public void depDireta(String linha) {
		
		linha = linha.trim().replaceAll("\\s+", "");
		
		char[] elementos = linha.toCharArray();
		
		String elementoInicial = elementos[0] + "";
		
		int largura = elementos.length;
		
		for(int i = 1; i<largura; i++) {
			listas.get(elementoInicial).append(elementos[i] +"");	

		}
		
		for (String chave : listas.keySet()) { 
	         depIndireta(chave);	          
		}

	}
	
	public void depIndireta(String elemento) { //"A"
		
		StringBuffer valor = listas.get(elemento);
		
		char[] elementos = valor.toString().toCharArray();
		
		int largura = elementos.length;
		
		for(int i = 0; i<largura; i++) {
			
			String elemAtual = elementos[i] + "";
			
			if(listas.get(elemento).indexOf(listas.get(elemAtual) + "") == -1 
				&& listas.get(elemAtual) != null) {
				listas.get(elemento).append(listas.get(elemAtual));	
			}
		}
	}

	
	public String eliminaRepetida(StringBuffer texto) {

		StringBuffer semRepetida = new StringBuffer();
		
		int largura = texto.length();
		
		for(int i = 0; i<largura ; i++) {
			
			for(int j = i; j<largura; j++) {
				
				if(semRepetida.indexOf(texto.charAt(j) + "") == -1) {
					
					semRepetida.append(texto.charAt(j));
				}
			}
		}
		
		return semRepetida.toString();
		
	}
	

	public static void main(String[] args) {
		DependenciasTransitivas t = new DependenciasTransitivas();
		t.init();
	}
	
	
}

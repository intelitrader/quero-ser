package quebraLinha;

public class QuebraLinha {
	
	
	public static String quebraColuna(String frase) {
		
		
	  int contador = 0;
	  int limite = 20;
	  StringBuilder novoTexto = new StringBuilder();
	  String[] palavrasSeparadas = frase.split(" ");


	  for (String palavra : palavrasSeparadas) {

	    if(contador + palavra.length() >= limite) {
	      contador = 0;
	      novoTexto.append('\n');
	    }

	    novoTexto.append(palavra);
	    novoTexto.append(' ');
	    contador += palavra.length() + 1;
	  }
		  
	  String colunado = novoTexto.toString();
	  return colunado;
	}

}

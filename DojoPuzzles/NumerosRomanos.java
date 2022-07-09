import java.util.Scanner;

public class NumerosRomanos {

  public static void main(String[] args) {
    Scanner entrada = new Scanner(System.in);

    System.out.println("Conversão entre números romanos e indo-arábicos\n\nDigita 1 ou 2:");
    String valor = "";

    while (true) {
      System.out.println("1 - Indo-arábico para número romano, 2 - Número romano para indo-arábicos:");

      valor = entrada.next().trim();
      if (!valor.equals("1") && !valor.equals("2")) {
        System.out.println("Valor inválido, digita 1 ou 2!");
      } else {
        break;
      }

    }

    // break one line
    System.out.println();
    String valor2 = "";

    if (valor.equals("1")) {
      System.out.println("Coverter número indo-arábico para número romano");
      System.out.println("Digita o número que tu queres converter para número romano:");

      valor2 = entrada.next();
      obterValorEmNumeroRomano(Integer.parseInt(valor2));

    } else if (valor.equals("2")) {
      System.out.println("Coverter número romano para indo-arábicos");
      System.out.println("Digita os simbolos romanos:");
      valor2 = entrada.next();
      valor2 = valor2.toUpperCase();

      converterNumeroRomanoParaInteiro(String.valueOf(valor2));

    }

    entrada.close();

  }

  public static void obterValorEmNumeroRomano(int numero) {

    String[] letrasRomanas = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
    int[] valores = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

    StringBuilder valorConvertido = new StringBuilder();

    for (int i = 0; i < valores.length; i++) {

      while (numero >= valores[i]) {
        numero = numero - valores[i];
        valorConvertido.append(letrasRomanas[i]);
      }
    }

    System.out.println("\nO valor em número romanos é: " + valorConvertido.toString());

  }

  public static void converterNumeroRomanoParaInteiro(String simboloRomano) {

    int numero = 0;
    for (int i = 0; i < simboloRomano.length(); i++) {
      char caractere = simboloRomano.charAt(i);
      switch (caractere) {
        case 'I':
          numero = (i != simboloRomano.length() - 1
              && (simboloRomano.charAt(i + 1) == 'V' || simboloRomano.charAt(i + 1) == 'X'))
                  ? numero - 1
                  : numero + 1;
          break;
        case 'V':
          numero += 5;
          break;
        case 'X':
          numero = (i != simboloRomano.length() - 1
              && (simboloRomano.charAt(i + 1) == 'L' || simboloRomano.charAt(i + 1) == 'C'))
                  ? numero - 10
                  : numero + 10;
          break;
        case 'L':
          numero += 50;
          break;
        case 'C':
          numero = (i != simboloRomano.length() - 1
              && (simboloRomano.charAt(i + 1) == 'D' || simboloRomano.charAt(i + 1) == 'M'))
                  ? numero - 100
                  : numero + 100;
          break;
        case 'D':
          numero += 500;
          break;
        case 'M':
          numero += 1000;
          break;
      }
    }

    System.out.println("O valor em em formato indo-arábico é: " + numero);
    ;
  }
}

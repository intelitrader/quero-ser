import java.util.Scanner;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.HashMap;
import java.util.Collections;

public class CaixaEletronico {

  public static void main(String[] args) {

    Scanner entrada = new Scanner(System.in);
    int[] notasDisponeiveis = { 100, 50, 20, 10 };
    List<Integer> notasParaEntrega = new ArrayList<Integer>();

    String valorSaque = "";
    while (true) {
      System.out.println("Digita o valor que tu queres sacar: ");
      valorSaque = entrada.next();

      // checa se o valor enviado pelo usuario é um numero
      if (isNumero(valorSaque)) {

        int valor = Integer.parseInt(valorSaque);
        for (int i = 0; i < notasDisponeiveis.length;) {
          if (valor >= notasDisponeiveis[i]) {

            valor = valor - notasDisponeiveis[i];
            notasParaEntrega.add(notasDisponeiveis[i]);

          } else {
            i++;
          }
        }

        break;

      } else {
        System.out.println("\nValor invalido, digita um numero!");
      }
    }

    entrada.close();

    Map<Integer, Integer> quantidadeNotaPorValor = new HashMap<>();

    for (int i = 0; i < notasParaEntrega.size(); i++) {
      int chave = notasParaEntrega.get(i);
      int valor = Collections.frequency(notasParaEntrega, notasParaEntrega.get(i));

      quantidadeNotaPorValor.put(chave, valor);
    }
    System.out.println("\nValor do saque R$" + valorSaque + ",00");
    System.out.println("Saque:");
    for (Integer chave : quantidadeNotaPorValor.keySet()) {
      System.out.println(quantidadeNotaPorValor.get(chave) + " nota de " + chave);
    }

  }

  public static boolean isNumero(final String str) {

    // nulo ou vazio
    if (str == null || str.length() == 0) {
      return false;
    }

    for (char c : str.toCharArray()) {
      if (!Character.isDigit(c)) {
        return false;
      }
    }

    return true;

  }
}

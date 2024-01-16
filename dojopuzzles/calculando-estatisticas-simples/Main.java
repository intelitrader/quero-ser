import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        while (true) {
            System.out.print("Inclua um número inteiro na lista:\nDigite o valor ou 'S' para sair:");
            String entrada = scan.nextLine();

            int valor;
            try {
                valor = Integer.parseInt(entrada);

                Lista.getLista().add(valor);
            } catch (Exception e) {
                if (entrada.equalsIgnoreCase("s")) {
                    break;
                } else {
                    System.out.println("Valor inválido.");
                }
            }
        }

        System.out.println(Lista.ListarInformacoes());
    }
}

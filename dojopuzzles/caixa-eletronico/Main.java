import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);
        CaixaEletronico caixa = new CaixaEletronico();

        while (true) {

            try {
                System.out.print("Digite o valor para saque ou 0 (zero) para sair:\nR$ ");
                int valor = scan.nextInt();

                if (valor == 0) {
                    System.exit(0);
                }

                int resto = caixa.sacar(valor);
                System.out.println(caixa.toString());
                System.out.println("Não foi possível sacar: R$" + resto + ",00");

            } catch (Exception e) {
                System.out.println("Informe apenas valores inteiros.");
                scan.nextLine();
            }
        }

    }
}

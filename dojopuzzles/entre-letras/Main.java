import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        System.out.print("Insira a letra inicial: ");
        char letraInicio = Character.toLowerCase(scan.nextLine().charAt(0));
        System.out.print("Insira a letra final: ");
        char letraFim = Character.toLowerCase(scan.nextLine().charAt(0));

        if (Validadora.validarLetra(letraInicio) && Validadora.validarLetra(letraFim)) {

            int posicaoInicio = Validadora.descobrirPosicao(letraInicio);
            int posicaoFim = Validadora.descobrirPosicao(letraFim);

            int quantidade = Validadora.calcular(posicaoInicio, posicaoFim);

            if (quantidade < 0) {
                System.out.println("Não está na ordem alfabética.");
            } else {
                System.out.println(quantidade);
            }
        } else {
            System.out.println("Insira apenas letras do alfabeto.");
        }

        scan.close();
    }
}
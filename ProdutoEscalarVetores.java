/* Produto Escalar de Vetores: https://dojopuzzles.com/problems/produto-escalar-de-vetores/
 */

package Problema3;
import java.util.Scanner;

public class ProdutoEscalarVetores {
    public static void main(String[] args) {
        Scanner ler = new Scanner(System.in);
        int n;

        System.out.print("Digite a quantidade de números: ");
        n = ler.nextInt();

        int[] A = new int[n];
        int[] B = new int[n];

        for(int x = 0; x < n; x++){
            System.out.print("Digite o " + (x + 1) + "° Número do vetor A: ");
            A[x]= ler.nextInt();
        }
        for(int y = 0; y < n; y++){
            System.out.print("Digite o " + (y + 1) + "° Número do vetor B: ");
            B[y]= ler.nextInt();
        }

        double P = 0;

        System.out.print("A multiplicação dos vetores é:\n");
        for(int w = 0; w < n; w++){
            P += (B[w] * A[w]);
            System.out.println(A[w] + " * " + B[w] + " = "+(B[w] * A[w]));
        }
        System.out.println("A soma dos produtos é: ");
        System.out.println(P);
    }
}

package DojoPuzzles.CalculandoEstatisticaSimples;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Estatistica {

    public List<Integer> lista = new ArrayList<>();
    public int maximo;
    public int minimo;
    public int quantidadeNumeros;
    public double media;

    public void constroiLista(int a, int b, int c, int d, int e) {
        lista = Arrays.asList(a, b, c, d, e);
    }

    public int maiorNumero() {
        maximo = lista.stream().mapToInt(i -> i).max().getAsInt();
        return maximo;
    }

    public int menorNumero() {
        minimo = lista.stream().mapToInt(i -> i).min().getAsInt();
        return minimo;
    }

    public int calculaQuantidade() {
        quantidadeNumeros = lista.size();
        return quantidadeNumeros;
    }

    public double calculaMedia() {
        media = (lista.stream().mapToDouble(i -> i).sum())/lista.size();
        return media;
    }

    public void calculaTudo() {
        System.out.println("=======================================");
        System.out.println("Lista ->  " + lista);
        maiorNumero();
        System.out.println(".Valor maximo: " + maximo);
        menorNumero();
        System.out.println(".Valor minimo: " + minimo);
        calculaQuantidade();
        System.out.println(".Numeros de elementos na sequencia: " + quantidadeNumeros);
        calculaMedia();
        System.out.println(".Valor medio: " + media);
        System.out.println("=======================================");
    }

    public static void main(String[] args) {
        Estatistica stats = new Estatistica();
        stats.constroiLista(225, 6543, -3426, -2920, 2312);
        stats.calculaTudo();
    }
}

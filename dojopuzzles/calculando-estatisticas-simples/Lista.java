import java.util.ArrayList;
import java.util.List;

public class Lista {

    private static List<Integer> lista = new ArrayList<>();

    public static List<Integer> getLista() {
        return lista;
    }

    public static int getValorMínimo() {
        int valorMinimo = lista.get(0);
        for (int valor : lista) {
            if (valor < valorMinimo) {
                valorMinimo = valor;
            }
        }
        return valorMinimo;
    }

    public static int getValorMaximo() {
        int valorMaximo = lista.get(0);
        for (int valor : lista) {
            if (valor > valorMaximo) {
                valorMaximo = valor;
            }
        }
        return valorMaximo;
    }

    public static double getValorMedio() {
        double soma = 0;

        for (int valor : lista) {
            soma += valor;
        }
        return soma / lista.size(); // a soma de todos os valores dividida pela quantidade de elementos
    }

    public static String ListarInformacoes() {
        if (lista.size() > 0) {
            return "\nValor mínimo: " + getValorMínimo()
                    + "\nValor máximo: " + getValorMaximo()
                    + "\nNúmero de elementos na sequência: " + lista.size()
                    + "\nValor médio: " + getValorMedio();
        } else {
            return "Nenhum resultado a ser mostrado.";
        }
    }
}

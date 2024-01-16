import java.util.regex.Pattern;

public class Validadora {
    public static final char[] ALFABETO = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

    public static int descobrirPosicao(char letra) {

        for (int i = 0; i < ALFABETO.length; i++) {
            if (letra == ALFABETO[i]) {
                return i;
            }
        }
        return -1;
    }

    public static int calcular(int inicio, int fim) {
        if (inicio == fim || inicio == (fim-1)) { // não há nenhuma letra no meio
            return 0;
        } else {
            return fim - inicio - 1; // quantidade de letras entre início e fim
        }
    }

    public static boolean validarLetra(char letra) {
        return Pattern.matches("[a-z]", String.valueOf(letra));
    }
}
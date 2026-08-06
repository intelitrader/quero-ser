public class CaixaEletronico {

    private static final int[] NOTAS = {100,50,20,10};
    private int[] qtdNotas = new int[4];

    public int sacar(int valor) {
        int resto = valor;

        for (int i = 0; i < NOTAS.length; i++) {
            qtdNotas[i] = (int) resto/NOTAS[i];
            resto = resto % NOTAS[i];
        }
        return resto;
    }

    @Override
    public String toString() {
        String mensagem = "Entregar: \n";
        for (int i = 0; i < NOTAS.length; i++) {
            mensagem += qtdNotas[i] + " nota(s) de R$" + NOTAS[i] + ",00\n";
        }
        return mensagem;
    }
}

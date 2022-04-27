package DojoPuzzles.Troco;

import java.util.LinkedHashMap;
import java.util.Map;

public class Troco {

    public int[] notasEMoedas = {10000, 5000, 1000, 500, 100, 50, 10, 5, 1};
    public Map<Double, Integer> valoresEQuantidade = new LinkedHashMap<>();
    public double valorTotal;
    public double valorPago;
    public double troco;
    public int trocoEmCentavos;

    public void pagamento(double total, double pago) {
        valorTotal = total;
        valorPago = pago;
        troco = valorPago - valorTotal;
        troco = Math.round(troco * 100.0)/100.0; //Duas casas decimais
        trocoEmCentavos = (int) (troco * 100);

        System.out.println("==================================================");
        System.out.println("Valor Total:  " + valorTotal + "      Valor Pago: " + valorPago);
        System.out.println("Troco: " + troco);

        analiseTroco();
        devolveTroco();
    }

    public void analiseTroco() {
        for (int notaAtual : notasEMoedas) {
            if (trocoEmCentavos >= notaAtual) {
                int qtd = trocoEmCentavos / notaAtual;
                valoresEQuantidade.put((notaAtual / 100.0), qtd);
                trocoEmCentavos = trocoEmCentavos % notaAtual;

                if (trocoEmCentavos == 0) {
                    break;
                }
            }
        }

    }

    public void devolveTroco() {

        for (Map.Entry<Double, Integer> mapa : valoresEQuantidade.entrySet()) {
            double notaMoeda = mapa.getKey();
            int qtd = mapa.getValue();

            String tipoTroco;
            if (notaMoeda > 1){
                tipoTroco = "nota(s)";
            } else {
                tipoTroco = "moeda(s)";
            }
            System.out.println(qtd + " " + tipoTroco + " de " + notaMoeda);
        }
        System.out.println("==================================================");
    }

    public static void main(String[] args) {
        Troco testando = new Troco();
        testando.pagamento(754.43, 1000.00);
    }


}

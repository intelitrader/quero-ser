package DojoPuzzles.Troco;

import org.junit.Assert;
import org.junit.Test;

public class TrocoTest {

    @Test
    public void confereTroco() {
        Troco testando = new Troco();
        testando.pagamento(1520.91, 1700.00);
        Assert.assertEquals(179.09, testando.troco, 0.001);
    }

    @Test
    public void confereNotasNoMapa() {
        Troco testando = new Troco();
        testando.pagamento(630.00, 900.00);
        Assert.assertTrue(testando.valoresEQuantidade.containsKey(100.0));
        Assert.assertTrue(testando.valoresEQuantidade.containsKey(50.0));
        Assert.assertTrue(testando.valoresEQuantidade.containsKey(10.0));
    }

    @Test
    public void confereMoedasNoMapa() {
        Troco testando = new Troco();
        testando.pagamento(1134.32, 1200.00);
        Assert.assertTrue(testando.valoresEQuantidade.containsKey(0.01));
        Assert.assertTrue(testando.valoresEQuantidade.containsKey(0.05));
        Assert.assertTrue(testando.valoresEQuantidade.containsKey(0.01));
    }

    @Test
    public void trocoSemMoedas() {
        Troco testando = new Troco();
        testando.pagamento(130.00, 300.00);
        Assert.assertFalse(testando.valoresEQuantidade.containsKey(0.01));
        Assert.assertFalse(testando.valoresEQuantidade.containsKey(0.05));
        Assert.assertFalse(testando.valoresEQuantidade.containsKey(0.01));
    }

    @Test
    public void trocoSemNotas() {
        Troco testando = new Troco();
        testando.pagamento(0.26, 1.00);
        Assert.assertFalse(testando.valoresEQuantidade.containsKey(100.0));
        Assert.assertFalse(testando.valoresEQuantidade.containsKey(50.00));
        Assert.assertFalse(testando.valoresEQuantidade.containsKey(10.00));
    }

}

package DojoPuzzles.CalculandoEstatisticaSimples;

import org.junit.Assert;
import org.junit.Test;

public class EstatisticaTest {

    @Test
    public void MaiorNumeroCasoNormal(){
        Estatistica stats = new Estatistica();
        stats.constroiLista(4, -4, 31, 525, -5232);
        stats.maiorNumero();

        Assert.assertEquals(525, stats.maximo);
    }

    @Test
    public void MaiorNumeroComMaxMinInt(){
        Estatistica stats = new Estatistica();
        stats.constroiLista(4, Integer.MAX_VALUE, Integer.MIN_VALUE, 525, -5232);
        stats.maiorNumero();

        Assert.assertEquals(Integer.MAX_VALUE, stats.maximo);
    }


    @Test
    public void MenorNumeroCasoNormal(){
        Estatistica stats = new Estatistica();
        stats.constroiLista(3134, -534, 3531, 525, -32);
        stats.menorNumero();

        Assert.assertEquals(-534, stats.minimo);
    }

    @Test
    public void MenorNumeroComMaxMinInt(){
        Estatistica stats = new Estatistica();
        stats.constroiLista(4, Integer.MAX_VALUE, Integer.MIN_VALUE, 525, -5232);
        stats.menorNumero();

        Assert.assertEquals(Integer.MIN_VALUE, stats.minimo);
    }

    @Test
    public void MediaCasoNormal(){
        Estatistica stats = new Estatistica();
        stats.constroiLista(512,-35,25,-5,-135);
        stats.calculaMedia();

        Assert.assertEquals(72.4, stats.media, 0.01);
    }

    @Test
    public void MediaComMaxMinInt(){
        Estatistica stats = new Estatistica();
        stats.constroiLista(Integer.MIN_VALUE,-35,25,Integer.MAX_VALUE,-135);
        stats.calculaMedia();

        Assert.assertEquals(-29.2, stats.media, 0.01);
    }

    @Test
    public void Quantidade(){
        Estatistica stats = new Estatistica();
        stats.constroiLista(512,-35,25,-5,-135);
        stats.calculaQuantidade();

        Assert.assertEquals(5, stats.quantidadeNumeros);
    }

    @Test
    public void CalculandoTudo() {
        Estatistica stats = new Estatistica();
        stats.constroiLista(-213, 9090, -324, 1021, 23);
        stats.calculaTudo();

        Assert.assertEquals(9090, stats.maximo);
        Assert.assertEquals(-324, stats.minimo);
        Assert.assertEquals(1919.4, stats.media, 0.1);
        Assert.assertEquals(5, stats.quantidadeNumeros);
    }
}

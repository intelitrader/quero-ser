package DojoPuzzles.EntreLinhas;

import org.junit.Assert;
import org.junit.Test;

public class EntreLinhasTest {

    @Test
    public void tamanhoDoMapa() {
        EntreLinhas testando = new EntreLinhas();
        testando.constroiAlfabeto();
        Assert.assertEquals(26, testando.alfabeto.size());
    }

    @Test
    public void comparandoMapa() {
        EntreLinhas alfabeto = new EntreLinhas();
        alfabeto.constroiAlfabeto();
        EntreLinhas alfabetoEsperado = new EntreLinhas();
        alfabetoEsperado.constroiAlfabeto();
        Assert.assertEquals(alfabetoEsperado.alfabeto, alfabeto.alfabeto);
    }

    @Test
    public void ordemNormal() {
        EntreLinhas alfabeto = new EntreLinhas();
        alfabeto.constroiAlfabeto();
        alfabeto.calculoEntreLetras('a', 'z');
    }

    @Test
    public void ordemNormal2() {
        EntreLinhas alfabeto = new EntreLinhas();
        alfabeto.constroiAlfabeto();
        alfabeto.calculoEntreLetras('f', 'r');
        Assert.assertEquals(11, alfabeto.dif);
    }

    @Test
    public void duasLetrasEmCapslock() {
        EntreLinhas alfabeto = new EntreLinhas();
        alfabeto.constroiAlfabeto();
        alfabeto.calculoEntreLetras('D', 'v');
        Assert.assertEquals(17, alfabeto.dif);
    }

    @Test
    public void umaLetraEmCapslock() {
        EntreLinhas alfabeto = new EntreLinhas();
        alfabeto.constroiAlfabeto();
        alfabeto.calculoEntreLetras('G', 'p');
        Assert.assertEquals(8, alfabeto.dif);
    }

    @Test
    public void foraDaOrdemAlfabetica() {
        EntreLinhas alfabeto = new EntreLinhas();
        alfabeto.constroiAlfabeto();
        alfabeto.calculoEntreLetras('d', 'a');
        Assert.assertEquals(2, alfabeto.dif);
    }

    @Test
    public void foraDaOrdemAlfabetica2() {
        EntreLinhas alfabeto = new EntreLinhas();
        alfabeto.constroiAlfabeto();
        alfabeto.calculoEntreLetras('d', 'c');
        Assert.assertEquals(0, alfabeto.dif);
    }

    @Test
    public void letrasIguais() {
        EntreLinhas alfabeto = new EntreLinhas();
        alfabeto.constroiAlfabeto();
        alfabeto.calculoEntreLetras('g', 'g');
        Assert.assertEquals(0, alfabeto.dif);
    }


}

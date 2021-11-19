package DojoPuzzles.EntreLinhas;

import java.util.HashMap;
import java.util.Map;

public class EntreLinhas {

    public Map<Character, Integer> alfabeto = new HashMap<>();
    public Integer num = 1;
    public Character letra1;
    public Character letra2;
    public int numLetra1;
    public int numLetra2;
    public int dif;

    public void constroiAlfabeto() {
        for (Character c = 'a'; c <= 'z'; c++) {
            alfabeto.put(c.charValue(), num++);
        }
    }

    public void calculoEntreLetras(Character um, Character dois) {
        letra1 = Character.toLowerCase(um);
        letra2 = Character.toLowerCase(dois);

        confereCaractere();
        conversor();
        calculaDiferença();
        resultado();
    }

    public void confereCaractere() {
        if (!alfabeto.containsKey(letra1.charValue()) || !alfabeto.containsKey(letra2.charValue())) {
            System.out.println("Caractere inválido, insira apenas letras!");
        }
    }

    public void conversor() {
        numLetra1 = alfabeto.get(letra1.charValue());
        numLetra2 = alfabeto.get(letra2.charValue());
    }

    public void calculaDiferença() {
        if (numLetra1 != numLetra2) {
            dif = Math.abs(numLetra1 - numLetra2) - 1;
        } else {
            dif = Math.abs(numLetra1 - numLetra2);
        }
    }

    public void resultado() {
        if (numLetra1 >  numLetra2) {
            System.out.println("'"+letra1+"',"+"'"+letra2+"' = "+
                    "Nao esta na ordem alfabetica!");

        } else if (numLetra1 <= numLetra2) {
            System.out.println("'"+letra1+"',"+"'"+letra2+"' = "+ dif );
        }
    }

    public static void main(String[] args) {
        EntreLinhas testando = new EntreLinhas();
        testando.constroiAlfabeto();
        testando.calculoEntreLetras('a', 'z');
    }
}

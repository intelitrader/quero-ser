// Caixa eletronico: https://dojopuzzles.com/problems/caixa-eletronico/
package Problema1;

import java.util.Scanner;
public class CaixaEletronico {
    public static void main(String[] args) {
        Scanner ler = new Scanner(System.in);
        int valor, troco, cem , cinquenta , vinte , dez;

        System.out.print("Digite o valor do saque: ");
        valor = ler.nextInt();

        troco = valor;
        cem = troco / 100;
        troco = troco - (cem *100);
        cinquenta = troco / 50;
        troco = troco - (cinquenta * 50);
        vinte = troco / 20;
        troco = troco - (vinte * 20);
        dez = troco /10;
        troco = troco -(dez * 10);

        System.out.println(cem + " nota(s) de R$ 100,00 ");
        System.out.println(cinquenta + " nota(s) de R$ 50,00 ");
        System.out.println(vinte + " nota(s) de R$ 20,00 ");
        System.out.println(dez + " nota(s) de R$ 10,00 ");
    }
}
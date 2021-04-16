package Problema2;
//Buracos nas letras: https://dojopuzzles.com/problems/buracos-nas-letras/

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
public class BuracosNasLetras {
    public static void main(String[] args) {
        Scanner ler = new Scanner(System.in);
//A B C D E F G H I J K L M N O P Q R S T U V W X Y Z
//a b c d e f g h i j k l m n o p q r s t u v w x y z
        Integer buraco  = 0;

        System.out.print("Digite uma frase qualquer em letras maiusculas (CASO CONTRARIO NOS MUDAREMOS A FRASE PARA CAPSLOCK): ");
        String frase = ler.nextLine();

        String fraseTeste = frase.toUpperCase(); //Para transformar letras minusculas em maiusculas

        System.out.println(fraseTeste);
//-------------------------------------------------------------------------------------------------

        for ( int i = 0; i < fraseTeste.length(); i++) {
            if (fraseTeste.charAt(i) == 'A' || fraseTeste.charAt(i) == 'D' ||fraseTeste.charAt(i) == 'O' || fraseTeste.charAt(i) == 'P' || fraseTeste.charAt(i) =='Q' || fraseTeste.charAt(i) == 'R') {
                buraco += 1;
            } else if (fraseTeste.charAt(i) == 'B') {
                buraco += 2;
            }
        }
//-------------------------------------------------------------------------------------------------
        System.out.println("A quantidade de buracos nessa frase é de: " + buraco);
    }
}

import java.util.Scanner;

public class Jokenpo {

  public static void main(String[] args) {
    
    Scanner entrada = new Scanner(System.in);
    System.out.println("Jodador 1, escolhe Pedra, Papel ou Tesoura:");
    String escolhaJogador1 = entrada.next().trim();

    System.out.println("Jodador 2, escolhe Pedra, Papel ou Tesoura:");
    String escolhaJogador2 = entrada.next().trim();

    if(escolhaJogador1.equalsIgnoreCase("pedra") && escolhaJogador2.equalsIgnoreCase("tesoura")) {
      System.out.println("O jogador 1 ganhou.");
    } else if(escolhaJogador1.equalsIgnoreCase("pedra") && escolhaJogador2.equalsIgnoreCase("pedra")) {
      System.out.println("Deu empate.");
    } else if(escolhaJogador1.equalsIgnoreCase("tesoura") && escolhaJogador2.equalsIgnoreCase("pedra")) {
      System.out.println("O jogador 2 ganhou");
    } else if(escolhaJogador1.equalsIgnoreCase("tesoura") && escolhaJogador2.equalsIgnoreCase("papel")) {
      System.out.println("O jogador 1 ganhou.");
    } else if(escolhaJogador1.equalsIgnoreCase("tesoura") && escolhaJogador2.equalsIgnoreCase("tesoura")) {
      System.out.println("Deu empate.");
    } else if(escolhaJogador1.equalsIgnoreCase("papel") && escolhaJogador2.equalsIgnoreCase("tesoura")) {
      System.out.println("O jogador 2 ganhou");
    } else if(escolhaJogador1.equalsIgnoreCase("papel") && escolhaJogador2.equalsIgnoreCase("pedra")) {
      System.out.println("O jogador 1 ganhou.");
    } else if(escolhaJogador1.equalsIgnoreCase("papel") && escolhaJogador2.equalsIgnoreCase("papel")) {
      System.out.println("Deu empate");
    } else if(escolhaJogador1.equalsIgnoreCase("pedra") && escolhaJogador2.equalsIgnoreCase("papel")) {
      System.out.println("O jogador 2 ganhou");
    }

    entrada.close();
  }

}

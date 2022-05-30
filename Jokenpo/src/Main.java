import java.util.Scanner;

public class Main 
{

	public static void main(String[] args) 
	{
		
		Scanner sc = new Scanner(System.in);
		
		int j1, j2;
		
		System.out.println("Por favor, informe as duas jogadas!\n");
		j1 = sc.nextInt();
		j2 = sc.nextInt();
		
		
		       if (j1 != j2) {
		      
		       if ((j1 == 1 && j2 == 3) || (j1 == 2 && j2 == 1) || (j1 == 3 && j2 == 2)) {
				System.out.println("Jogador 1 Vence");
		       }
				else {
				System.out.println("Jogador 2 Vence!");
			   }
		       }
		       if (j1 == j2) {
					System.out.println("Empate!");
			       } 
		
		sc.close();
	}		
      
}

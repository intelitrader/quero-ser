import java.util.Scanner;

public class IndiceEquilibrio {

	 int[] vetor;
	 int numElementos;
	
	public IndiceEquilibrio() {
		init();
	}
	
	public void init() {
		Scanner in = new Scanner (System.in);

		System.out.println("Digite o número de elementos do vetor");
		numElementos = in.nextInt();
		
		vetor = new int[numElementos];
		
		System.out.println("Digite os elementos do vetor");
		for(int i = 0; i < numElementos; i++) {
			vetor[i] = in.nextInt();
		}
		
		System.out.println("O ponto de equilibrio é: " + pontoEquilibrio(vetor));
	}

	
	public int pontoEquilibrio(int [] vetorNumeros) {

		int numeroElementos = vetorNumeros.length;
		int limiteSoma = 1;
		int soma = 0;
		int somaRestante = 0;
		
		for(int i = 0; i<numeroElementos; i++) {
			
			for(int j = 0; j < limiteSoma; j++) {
				soma += vetorNumeros[j];
				continue;
			}
			
			int limiteSomaResto = i +1;
		
			while(limiteSomaResto < numeroElementos) {
				somaRestante += vetorNumeros[limiteSomaResto];
				limiteSomaResto ++;
			}
			
			if(soma == somaRestante) {
				return i + 1;
			}
			soma = 0;
			somaRestante = 0;
			limiteSoma ++;
		}
		
		return -1;
	}
	
	public static void main(String[] args) {
		IndiceEquilibrio ie = new IndiceEquilibrio();
		
	}
	
}

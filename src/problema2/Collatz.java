package problema2;

/*
 * Problema: https://dojopuzzles.com/problems/analisando-a-conjectura-de-collatz/
 * Programador: Roberto da Silva Mitsunari
 */
public class Collatz {
	public static void main(String[] args) {
		int maiorResul = 0;
		int numMaior = 0;
		int r;
		for(int x = 1;x <= 1000000;x++) {
			r = funcCollatz(x);
			if(r > maiorResul) {
				numMaior = x;
				maiorResul = r;
			}
			System.out.println("x: "+ x + " " + r);
		}
		System.out.println("Maior sequencia -> Numero: " + numMaior + " Tamanho: " + maiorResul);

	}
	//fatorial funcionando mas ele estoura a memória stack com números muito grandes > 110000
	public static int fatorialCollatz(int re) {
		int count = 1;
		if (re == 1) {
			return 1;
		} else {
			if (re % 2 == 0) {
				count += fatorialCollatz(re / 2);
				return count;
			} else {
				count += fatorialCollatz((3 * re) + 1);
				return count;	
			}
		}
	}
	
	public static int funcCollatz(int x) {
		int count = 1;
		while(x > 1) {
			if (x % 2 == 0) {
				x = x / 2;
			} else {
				x = ((3 * x) + 1);
			}
			count++;
		}
		return count;
	}
}

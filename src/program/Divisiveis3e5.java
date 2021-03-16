package program;

//https://dojopuzzles.com/problems/fizzbuzz/

public class Divisiveis3e5 {
	public static void main(String[] args) {
		
		int tres = 3;
		int cinco = 5;
		for (int i = 1; i <= 100; i++) {
			if ((i / tres == 1) & (i / cinco !=1)){
				System.out.println("Fizz");
				tres += 3;
			}else if ((i / cinco == 1) & (i / tres != 1)){
				System.out.println("Buzz");
				cinco +=5;
			}else if((i / tres == 1) & ( i / cinco == 1)){
				System.out.println("FizzBuzz");
				tres += 3;
				cinco += 5;
			}else
				System.out.println(i);
		}	
	}
}
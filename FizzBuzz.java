package segundodesafio;

import java.util.Scanner;

public class FizzBuzz {
	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		
		for(int i = 0; i <= 100; i++) {
			
			if(i%3 == 0) {
				System.out.println("Fizz"+i);
			}
			if(i%5 == 0) {
				System.out.println("Buzz"+i);			
			}
			if((i%3 == 0) && (i%5 ==0)) {
				System.out.println("FizzBuzz"+i);
		
		
	 		}	
	    }
    }
}
#include <stdio.h>

int main()
{
	int limite, i ;
	limite = 100;
	
	 
	
	for(i = 1; i <= limite; i++)
		if (i%3 == 0){
			if (i%5 == 0) {
		
				printf("BuzzFizz \n" );
			
			} else {

				printf("Fizz \n" );
	
			}

		}  else if  ( i%5 == 0) {
	
					printf("Buzz \n" );
	
				} else { 

					printf(" %d \n " , i ) ;
				}

	return 0;
 

}
	


 

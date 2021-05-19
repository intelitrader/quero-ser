
#include <stdio.h>

int main()
{
	int  i, Qmic, Pmic ;
	
	 	printf("Qual a quantidade de mictorio disponiveis ? \n");
	 
	 	scanf("%d", &Qmic);
	 
	 
		printf("Qual a posicao do mictorio ocupado ? \n");
	 
	 	scanf("%d", &Pmic);
	 
	 
	 	for(i = 1; i <= Qmic; i++)
	 
			 if (Pmic % 2 == 0 && i % 2 == 0) {
						printf("Pode usar o mictorio %d \n",i);
			
				} 				
		 	
			 else if (Pmic  % 2 != 0 && i % 2 != 0){				
			 
					printf("Pode usar o mictorio  %d \n",i);
			} 

		return 0 ;
}

	

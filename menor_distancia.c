#include <stdlib.h>
#include <stdio.h>
#include <sys/random.h>
#include <limits.h>

int menor_distancia_arr(int *arr1, int size1, int *arr2, int size2)
{
	int min = INT_MAX;
	int distancia;

	for(int i = 0; i < size1; i++)
		{
			for(int j = 0; j < size2; j++)
				{
					distancia = abs(arr1[i] - arr2[j]);
					if(distancia < min)
						{
							min = distancia;
						}
				}
		}

	return distancia;
}

void main()
{
	int arr1[20] = {0};
	int arr2[20] = {0};
	int range = 1000;
	int min = -100;
	int result;
		
	uint number;
	getrandom(&number, sizeof(uint), GRND_RANDOM);
	printf("number= %d\n", number);
	srandom(number);

	for(unsigned long i = 0; i < sizeof(arr1) / sizeof(int); i++)
		{
		arr1[i] = random() % range + min;
		arr2[i] = random() % range + min;
		}
		
    result = menor_distancia_arr(arr1, sizeof(arr1)/sizeof(int), arr2, sizeof(arr2)/sizeof(int));
	
	printf("Menor distância: %d", result);
}

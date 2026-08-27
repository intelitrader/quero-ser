#include <stdlib.h>
#include <stdio.h>
#include <sys/random.h>
#include <limits.h>

int menor_numero_arr(int *arr, int size)
{
	int min = INT_MAX;
	for(int i = 0; i < size; i++)
		{
			if(arr[i] < min)
				{
					min = arr[i];
				}
		}

	return min;
}

void main()
{
	int arr1[20] = {0}; 
	int arr2[20] = {0};
	int range = 1000;
	int min = -100;
	int min_arr1, min_arr2;
		
	uint number;
	getrandom(&number, sizeof(uint), GRND_RANDOM);
	printf("number= %d\n", number);
	srandom(number);

	for(unsigned long i = 0; i < sizeof(arr1) / sizeof(int); i++)
		{
		arr1[i] = random() % range + min;
		arr2[i] = random() % range + min;
		}
		
    min_arr1 = menor_numero_arr(arr1, sizeof(arr1)/sizeof(int));
	min_arr2 = menor_numero_arr(arr2, sizeof(arr2)/sizeof(int));

	if(min_arr1 < min_arr2)
		{
			printf("Menor 1: %d\n", min_arr1);
			printf("Menor 2: %d\n", min_arr2);
			printf("Distância: %d - %d = %d\n", min_arr1, min_arr2, min_arr1 - min_arr2);
		}
	else
		{
			printf("Menor 2: %d\n", min_arr2);
			printf("Menor 1: %d\n", min_arr1);
			printf("Distância: %d - %d = %d\n", min_arr2, min_arr1, min_arr2 - min_arr1);
		}
}

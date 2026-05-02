#include <iostream>

using namespace std;

#define N_LINHAS_V    30

int main()
{

    //recebe o arquivo vendas//
    
	FILE * arq_ven;

    unsigned int num2[N_LINHAS_V][4];
    unsigned int i2=0;
    char ch2;

    arq_ven = fopen("c1_vendas.TXT","rt");

    if(arq_ven == NULL)
	{
        cout << "Nao foi possivel abrir o arquivo de vendas!" << endl;
        exit(0);
    }

    for(int j1=0; j1<N_LINHAS_V; j1++)
	{

        fscanf(arq_ven,"%d;%d;%d;%d",&num2[j1][0],&num2[j1][1],&num2[j1][2],&num2[j1][3]);

        while((ch2 = fgetc(arq_ven)) != EOF)
		{
         if(ch2=='\n') break;
        }

       
    }

    fclose(arq_ven);
    
    //trabalhando com os dados do arquivo//
    
   int item1, item2, item3, item4;
    
    for(int k1=0; k1<=29; k1++)
    {
    	if((num2[k1][2]==100 || num2[k1][2]==102 ) && (num2[k1][3] == 1))
    	{
    		item1 += num2[k1][1];
		}
	}
	
	for(int k1=0; k1<=29; k1++)
    {
    	if((num2[k1][2]==100 || num2[k1][2]==102 ) && (num2[k1][3] == 2))
    	{
    		item2 += num2[k1][1];
		}
	}
	
	for(int k1=0; k1<=29; k1++)
    {
    	if((num2[k1][2]==100 || num2[k1][2]==102 ) && (num2[k1][3] == 3))
    	{
    		item3 += num2[k1][1];
		}
	}
	
	for(int k1=0; k1<=29; k1++)
    {
    	if((num2[k1][2]==100 || num2[k1][2]==102 ) && (num2[k1][3] == 4))
    	{
    		item4 += num2[k1][1];
		}
	}
	
	item1 -= 1;
	
	printf("\n  %d \n", item1);
	printf("\n  %d \n", item2);
	printf("\n  %d \n", item3);
	printf("\n  %d \n", item4);
	
	// registrando no arquivo//
	
	FILE* arq_canais;
	
	arq_canais = fopen("totcanais.txt","wt");
	
	fprintf(arq_canais,"Quantidades de Vendas por canal\n\n");
	fprintf(arq_canais,"1 - Representantes		%d\n", item1);
	fprintf(arq_canais,"2 - Website			%d\n", item2);
	fprintf(arq_canais,"3 - App móvel Android		%d\n", item3);
	fprintf(arq_canais,"4 - App móvel iPhone		%d\n", item4);
	
	fclose(arq_canais);

    system ("pause");
     return 0;
}

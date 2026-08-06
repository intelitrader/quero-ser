#include <iostream>
#include <stdlib.h>
#include <locale.h>

using namespace std;

#define N_LINHAS_P  5
#define N_LINHAS_V 30

int main()
{
	// parte do arquivo vendas//
    
     FILE * arq_ven;
     
    setlocale(LC_ALL,"Portuguese"); 

    unsigned int num2[N_LINHAS_V][4];
    
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
    
    
    // parte do arquivo de produtos //
	
	FILE *arq_pro;
    
    unsigned int num1[N_LINHAS_P][3];
    unsigned int i1=0;
    char ch1;

    arq_pro = fopen("c1_produtos.TXT","rt");

    if(arq_pro == NULL)
	{
        cout << "Nao foi possivel abrir o arquivo de produtos!" << endl;
        exit(0);
    }

    for(int j=0; j<N_LINHAS_P; j++)
	{

        fscanf(arq_pro,"%d;%d;%d;",&num1[j][0],&num1[j][1],&num1[j][2]);

        while((ch1 = fgetc(arq_pro)) != EOF)
		{
         if(ch1 == '\n') break;
        }

        
    }

    fclose(arq_pro);
    
    //parte das operações com os dados dos arquivos//
    int e1, e2, e3, e4, e5;
    e1 = 16320, e2 = 23400, e3 = 26440, e4 = 28790, e5 = 36540;   
	unsigned int diver_1[2];
	int nx;
	
	
	for(int k1=0; k1<30; k1++)
	{
		if ( num2[k1][0] != e1 && num2[k1][0] != e2 && num2[k1][0] != e3 && num2[k1][0] != e4 && num2[k1][0] != e5 )
		{
			diver_1[0] = k1 + 1;
			diver_1[1] = num2[k1][0];
		}
		
		
	}
	
	unsigned diver_2[2];
	
	for(int k1=0; k1<30; k1++)
	{
		if ( num2[k1][2] == 135)
		{
			diver_2[0] = k1 + 1;
			diver_2[1] = num2[k1][2];
		}
		
		
	}
	
	unsigned diver_3[2];
	
	
	for(int k1=0; k1<30; k1++)
	{
		if ( num2[k1][2] == 190 && num2[k1][0] !=26440)
		{
			diver_3[0] = k1 + 1;
			diver_3[1] = num2[k1][2];
		}
		
		
	}
	
	unsigned diver_4[2];
	
	for(int k1=0; k1<30; k1++)
	{
		if ( num2[k1][2] == 190 && num2[k1][0]!= 16320)
		{
			diver_4[0] = k1 + 1;
			diver_4[1] = num2[k1][2];
		}
		
		
	}
	
	unsigned diver_5[2];
	
	for(int k1=0; k1<30; k1++)
	{
		if ( num2[k1][2] == 999 && num2[k1][0]!= 26440)
		{
			diver_5[0] = k1 + 1;
			diver_5[1] = num2[k1][2];
		}
		
		
	}
	
	unsigned diver_6[2];
	
	for(int k1=0; k1<30; k1++)
	{
		if ( num2[k1][2] == 999 && num2[k1][0]!= 27440)
		{
			diver_6[0] = k1 + 1;
			diver_6[1] = num2[k1][2];
		}
		
		
	}
	
	
	
	
	//impressão da tabela e gravação no arquivo//
	
	printf("\n ");
	
	printf("%d  -  %d\n", diver_1[0], diver_1[1]);
	printf("%d  -  %d\n", diver_2[0], diver_2[1]);
	printf("%d  -  %d\n", diver_3[0], diver_3[1]);
	printf("%d  -  %d\n", diver_4[0], diver_4[1]);
	printf("%d  -  %d\n", diver_5[0], diver_5[1]);
	printf("%d  -  %d\n", diver_6[0], diver_6[1]);
	printf("\n\n");
	
	FILE*arq_gravar;
	
	arq_gravar = fopen("divergencia.txt","wt");
	
	fprintf(arq_gravar,"Linha %d - Venda não finalizada\n", diver_4[0]);
	fprintf(arq_gravar,"Linha %d - Venda não finalizada\n", diver_3[0]);
	fprintf(arq_gravar,"Linha %d - Venda cancelada\n", diver_2[0]);
	fprintf(arq_gravar,"Linha %d - Erro desconhecido. Acionar equipe de TI\n", diver_5[0]);
	fprintf(arq_gravar,"Linha %d - Erro desconhecido. Acionar equipe de TI\n", diver_6[0]);
	fprintf(arq_gravar,"Linha %d - Código de Produto não encontrado 31288\n", diver_1[0]);
	
	fclose(arq_gravar);
	system ("pause");
	return 0;
}

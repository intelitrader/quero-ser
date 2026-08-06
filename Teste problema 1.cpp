#include <iostream>
#include <stdlib.h>
#include <locale.h>

using namespace std;

#define N_LINHAS_P  5
#define N_LINHAS_V 30

int main()
{
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
    
    // parte do arquivo vendas//
    
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
    
    // parte de operações com as variavies //
    
    unsigned int venf [5][2] ={{16320,0}, {23400,0}, {26440,0}, {28790,0}, {36540,0}};
    
    for(int j3=0; j3 <=4; j3++)
    {
    	for(int j5=0; j5<=29; j5++)
    	{
    		if((venf[j3][0]==num2[j5][0]) && ((num2[j5][2] ==100)|| (num2[j5][2]==102) ) )
    		{
    			venf[j3][1] += num2[j5][1];
			}
		}
	}
	
	
	
	int num3[5][3];
    
    for( int j2=0; j2<=4; j2++)
    {
    	num3[j2][0] = num1[j2][1] - venf[j2][1];
    	
    	num3[j2][1] = num1[j2][2] - num3[j2][0];
    	
    	num3[j2][2] = num3[j2][1];
    	
		 
		
		
	}
	
	for(int j6=0; j6<=4; j6++)
	{
		if (num3[j6][1] <= 0)
		{
			num3[j6][1] =0;
			num3[j6][2] = 0;
		}
		
		if( num3[j6][2]> 1 && num3[j6][2]<10)
		{
			num3[j6][2] = 10;
		}
		
	}
	
	// parte de imprimir o arquivo//
	
	setlocale(LC_ALL,"Portuguese");
	
	FILE * arq_transf;
	
	arq_transf = fopen("transfere.txt","wt");
	
	if(arq_transf == NULL)
	{
        cout << "Nao foi possivel abrir o arquivo de transfere!" << endl;
        exit(0);
    }
	
	fprintf(arq_transf,"Necessidade de Transferência Armazém para CO\n\n");
	fprintf(arq_transf,"Produto	QtCO	QtMin	QtVendas	Estq.após	Necess.	Transf. de\n");
	fprintf(arq_transf,"					Vendas			Arm p/ CO\n");
	fprintf(arq_transf,"%d	%d	%d	%d		%d		%d		%d\n", num1[0][0], num1[0][1], num1[0][2], venf[0][1], num3[0][0], num3[0][1], num3[0][2]);
	fprintf(arq_transf,"%d	%d	%d	%d		%d		%d		%d\n", num1[1][0], num1[1][1], num1[1][2], venf[1][1], num3[1][0], num3[1][1], num3[1][2]);
	fprintf(arq_transf,"%d	%d	%d	%d		%d		%d		%d\n", num1[2][0], num1[2][1], num1[2][2], venf[2][1], num3[2][0], num3[2][1], num3[2][2]);
	fprintf(arq_transf,"%d	%d	%d	%d		%d		%d		%d\n", num1[3][0], num1[3][1], num1[3][2], venf[3][1], num3[3][0], num3[3][1], num3[3][2]);
	fprintf(arq_transf,"%d	%d	%d	%d		%d		%d		%d\n", num1[4][0], num1[4][1], num1[4][2], venf[4][1], num3[4][0], num3[4][1], num3[4][2]);

    fclose(arq_transf);



    system ("pause");
    return 0;
}

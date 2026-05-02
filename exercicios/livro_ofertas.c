#include <stdlib.h>
#include <stdio.h>

#define MAX_ORDEM 1000

typedef struct {double preco; uint quantidade;} Ordem;
typedef struct {Ordem ordem[MAX_ORDEM]; int quantidade;} LivroOrdem;

void operacao(LivroOrdem *livro, int pos, int tipo, double valor, uint quantidade)
{
	switch(tipo)
		{
		case 0:
			if(pos > livro->quantidade)
				{
					livro->quantidade += 1;
				}
			livro->ordem[pos - 1].preco = valor;
			livro->ordem[pos - 1].quantidade = quantidade;
			break;

		case 1:
			if(pos <= livro->quantidade)
				{
					livro->ordem[pos - 1].quantidade = quantidade;
				}
			break;

		case 2:
			if(pos <= livro->quantidade)
				{
					for(int i = pos - 1; i < livro->quantidade - 1; i++)
						{
							livro->ordem[i] = livro->ordem[i+1];
						}
					livro->quantidade -= 1;
				}
			break;
		}
}

void print_livro_ordem(LivroOrdem *livro) {
    for (int i = 0; i < livro->quantidade; i++) {
        printf("%d,%.2f,%d\n", i + 1, livro->ordem[i].preco, livro->ordem[i].quantidade);
    }
}

void main()
{
	int notificacao;
	char str[255] = {0};
	uint pos, quantidade, tipo;
	double valor;
	LivroOrdem livro_ordem = {.quantidade = 0};

	printf("\nNotificacoes: ");
	scanf("%d", &notificacao);

	for(int i = 0; i < notificacao; i++)
		{
			printf("Valor: ");
		    if(scanf("%u,%u,%lf,%u", &pos, &tipo, &valor, &quantidade) != 4)
				{
					printf("\nFatal: Formato inválido\n");
					return;
				}
			if(tipo < 0 || tipo > 3) {printf("\nFatal: Tipo inválido\n"); return;}
			operacao(&livro_ordem, pos, tipo, valor, quantidade);			
		}

	print_livro_ordem(&livro_ordem);
}

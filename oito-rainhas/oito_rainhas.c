#include <stdlib.h>
#include <stdio.h>

/*
  Utilizando backtracking para resolver o problema das 8 rainhas.
  Exibe todas as 92 possibilidades de posicionamento.
*/

#define MAX_LINES 8
#define MAX_COLS  8
#define QNT_RAINHAS MAX_LINES

#define mesma_diagonal(x1, y1, x2, y2) ( \
     ( (x1) + (y1) ) == ( (x2) + (y2) ) \
  || ( (x1) - (y1) ) == ( (x2) - (y2) ) \
)


// variável global para contar as possibilidades
int possibilidades = 0;

void mostrar_tabuleiro(int rainhas[]) {
  printf("Possibilidade %d:\n", possibilidades);
  puts("  1 2 3 4 5 6 7 8");
  for(int linha = 0; linha < MAX_LINES; linha++) {
    printf("%c ", 65 + linha);
    for(int y = 0; y < MAX_COLS; y++) {
      if(rainhas[linha] == y)
        printf("R ");
      else
        printf("- ");
    }

    putchar('\n');
  }

  putchar('\n');
}

void adicionar_rainha(int rainhas[], int linha) {
  for(int coluna = 0; coluna < MAX_LINES; coluna++) {
    
    // toda vez que a última rainha é posicionada, significa que foi achada mais uma possibilidade
    if(rainhas[QNT_RAINHAS - 1] != -1) {
      ++possibilidades;
      mostrar_tabuleiro(rainhas);
      rainhas[QNT_RAINHAS - 1] = -1; // retira última rainha
    }

    int rainha;

    // verifica se qualquer uma das rainhas já posicionadas irão atacar a rainha que eu quero por agora
    for(rainha = 0; rainha < linha; rainha++)
      if(coluna == rainhas[rainha] ||
         mesma_diagonal(rainha, rainhas[rainha], linha, coluna))
        break;

    // se rainha for igual a `linha`, significa que eu verifiquei todas as rainhas já então posicionadas, e nenhuma 
    // delas atacam a nova rainha na posição desejada, dessa forma, eu adiciono a nova rainha nessa posição 
    if(rainha == linha) { 
      rainhas[linha] = coluna;

      // chamo novamente a função adicionar_rainha partindo para a próxima linha
      adicionar_rainha(rainhas, linha + 1);
    }
  }

  // se eu já tentei posicionar minha rainha em todas as colunas dessa linha, e mesmo assim não obtive sucesso,
  // a função retorna, voltando o tabuleiro para o estado anterior (backtracking for the win hehe)
}

int main() {

  // ao invés de representar o tabuleiro como um vetor 8x8, eu represento ele através de um vetor unidimensional de 8 posições.
  // cada posição representa uma linha diferente do tabuleiro (8 posições = 8 linhas), e o conteúdo de cada posição representa a coluna
  // dessa forma, se a posição 3 do vetor armazenar o inteiro 6, significa que há uma rainha posicionada na linha 4 coluna 6 do tabuleiro :)
  int rainhas[QNT_RAINHAS] = {-1, -1, -1, -1, -1, -1, -1, -1}; // -1 = posição vazia

  adicionar_rainha(rainhas, 0);

  printf("Há, ao todo, %d formas de posicionar as 8 rainhas sem que elas se ataquem :]\n", possibilidades);

  return 0;
}

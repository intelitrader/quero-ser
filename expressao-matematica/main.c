#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <ctype.h>
#include <stdbool.h>
#include "ed.h"
#include "parser.h"
#include "solver.h"

void get_input(char* buffer, size_t size) {
  printf("Expressão: ");
  fgets(buffer, size - 1, stdin);

  // remove a quebra de linha deixada por fgets
  char* linefeed = strchr(buffer, '\n');
  if(linefeed)
    *linefeed = '\0';

  // verifica se alguma entrada foi passada
  if(buffer[0] == '\0') {
    fprintf(stderr, "Nenhuma expressão informada!\n");
    exit(EXIT_FAILURE);
  }
}

int main() {

  // buffer que armazena a expressão
  char infix[1024];
  get_input(infix, sizeof(infix));

  // converte a expressão no formato infix, para postfix
  // ex.: (32 - 5) * (77 / 7) = 32 5 - 77 7 / *
  queue_t postfix = {0};
  infix_to_postfix(infix, &postfix);

  // resolve a expressão que agora está no formato postfix
  int result = solve_expression(&postfix);
  printf("Resultado = %d\n", result);

  return EXIT_SUCCESS;

}
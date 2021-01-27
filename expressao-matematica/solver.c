#include <stdlib.h>
#include <stdbool.h>
#include <stdio.h>
#include "solver.h"

static inline void cannot_solve(char* why) {
  puts(why);
  exit(EXIT_FAILURE);
}

static inline bool get_operands(stack_t* s, double* op1, double* op2) {
  // devido uma falha não identificada na etapa de análise da expressão, está faltando os dois operandos
  // necessários para a operação ser realizada
  if(s->size < 2)
    return false;

  /* Como os operando estão numa pilha, o segundo operando está em cima do primeiro,
  logo é necessário retirá-lo primeiro para não comprometer a ordem que foram 
  específicados na expressão */

  *op2 = pop(s).number; // segundo operando
  *op1 = pop(s).number; // primeiro segundo

  return true;
}

/*
  Resolve uma expressão no formato postfix retornando o resultado.

  A resolução da expressão é muito simples justamente por ela estar no formato postfix. Nesse formato os operandos são apresentados
  primeiro que o operador, exemplo: "3 4 +"

  Caso o elemento retirado da fila seja um número (type == NUMBER), ele é empilhado em `result`. Se o elemento for um operador (type == OPERATOR),
  os dois primeiros elementos da pilha são desempilhados e a operação é realizada. Logo em seguida, o resultado dessa operação é empilhado em `result`.
  Se a fila `postfix` esvaziar, todos os elementos foram avaliados, restando no topo de `result` o resultado final da expressão, que é retornado 
*/
double solve_expression(queue_t* postfix) {
  if(postfix->head == NULL)
    return 0;

  stack_t result = {0};
  data_t data = {0};
  double operand1, operand2;

  while(postfix->head != NULL) {
    data = dequeue(postfix);
    // se o dado for um número, é necessário apenas inserí-lo na pilha
    if(data.type == NUMBER)
      push(&result, &data);
    else {
      // Adquire os dois operandos da operação
      if(!get_operands(&result, &operand1, &operand2))
        cannot_solve("Erro: não foi possível resolver a operação, pois falta operandos. Por favor, reveja a expressão!");
      switch (data.operator) {
        case '+':  data.number = operand1 + operand2; break;
        case '-':  data.number = operand1 - operand2; break;
        case '*':  data.number = operand1 * operand2; break;
        case '/':
          if(operand2 == 0)
            cannot_solve("Erro: tentativa de divisão por zero! Por favor, reveja a expressão!");

          data.number = operand1 / operand2;
          break;
      }

      // altera o tipo do dado, que agora contém o resultado de uma operação, para NUMBER, e o insere na pilha
      data.type = NUMBER;
      push(&result, &data);
    }
  }

  return pop(&result).number;
}
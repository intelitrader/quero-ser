#include <stdlib.h>
#include <stdarg.h>
#include <stdbool.h>
#include <string.h>
#include <ctype.h>
#include <stdio.h>
#include "parser.h"
#include "ed.h"

// percorre cada caractere do buffer adquirindo um token/char por vez e armazenando em analyzer.curr_token
static bool get_next_token(char* buffer, analyzer_t* analyzer) {
  analyzer->curr_token = buffer[analyzer->offset];
  if(analyzer->curr_token == '\0')
    return false;
  
  analyzer->offset++;
  return true;
}

// após o analisador identificar um número, adquire todos os seus dígitos e o retorna
static int get_next_number(char* buffer, analyzer_t* analyzer) {
  char* save = NULL;
  int number = strtol(&buffer[analyzer->offset - 1], &save, 10);
  analyzer->offset += (size_t) save - (size_t) &buffer[analyzer->offset];

  return number;
}

static inline bool isoperator(char op) {
  switch(op) {
    case '+': case '-':
    case '*': case '/':
    case '(': case ')':
      return true;
    default:
      return false;
  }
}

static inline int check_precedence(char op) {
  switch(op) {
    case '+': case '-':
      return 1;
    case '*': case '/':
      return 2;
    default:
      return 0;
  }
}

// verifica se o operador atual analisado é esperado pela expressão
static inline bool is_operator_expected(analyzer_t* analyzer) {
  // Evita, por exemplo, 10 + 3 / * 10
  if(analyzer->last_token_type == NUMBER)
    return true;

  return false;
}

// verifica se o número atual analisado é esperado pela expressão
static inline bool is_number_expected(analyzer_t* analyzer) {
  // Evita, por exemplo, 10 10 + 3 * 100
  if(analyzer->last_token_type == NUMBER)
    return false;

  return true;
}

static inline bool check_pharenthesis(char* infix) {
  int open   = 0;
  int closed = 0;
  for(char* ptr = infix; *ptr; ptr++)
    if(*ptr == '(') open++;
    else if(*ptr == ')') closed++;
  
  return open == closed;
}

// desenha as "cobrinhas" em baixo da expressão, colocando em destaque o erro
static void highlight_invalid_symbol(char* infix, analyzer_t* analyzer) {
  printf("\n%s\n", infix);
  for(int i = 0; i < analyzer->offset - 1; i++)
    putchar('~');

  putchar('^');

  for(int i = analyzer->offset; infix[i]; i++)
    putchar('~');
}

// exibe uma mensagem de erro demarcando o local de expressão que possui erro
static void invalid_expression(char* infix, analyzer_t* analyzer, char* err_msg, ...) {
  infix[strlen(infix) - 1] = '\0'; // remove o ')' adicionado no início da análise
  
  va_list args;
  va_start(args, err_msg);

  highlight_invalid_symbol(infix, analyzer);
  putchar(10);
  vfprintf(stderr, err_msg, args);

  va_end(args);

  exit(EXIT_FAILURE);
}

/*
  O código acaba se tornando complexo devido as checagens que fiz para verificar se a expressão é válida ou não.

  Antes de começar:
    ex. de expressão infix: (10 + 2) / 6
    mesma expressão, porém postfix: 10 2 + 6 /

  O formato postfix de uma expressão basicamente deixa ordenado os operandos e operadores, levando em conta a precedência
  destes, para que a expressão possa ser lida da esquerda para a direita e ser avaliada no processo (explico a avaliação da 
  expressão no comentário da função solve_expression do arquivo solver.c). Vale ressaltar que nesse formato, os operandos apa-
  recem primeiro que seus operadores.

  O algoritmo usa uma fila, que conterá o resultado final da expressão no formato postfix, e uma pilha, que armazenará os operadores
  da expressão infix enquanto esta é avaliada. Os operadores só são retirados da pilha(e inseridos na fila) quando:

  a. o operador atual da expressão infix possui precedência menor que o operador no topo da pilha. Dessa forma, como o operador no topo
     da pilha possui maior precedência, ele deve aparecer primeiro no resultado da expressão postfix. O processo de retirada só termina
     quando o operador no topo da pilha tiver precedência menor que o operador atual da expressão infix. Por fim, esse operador atual
     também é enfileirado.

  b. um ')' é encontrado, dessa forma os operadores são removidos da pilha e inseridos na fila até que seja encontrado um '(', isso basica-
     mente é um "flush" dos operadores que fazem parte de uma sub-expressão, isto é, uma expressão que está entre parenteses.

  Caso o simbolo atual da expressão infix seja um número(operando), ele simplesmente é enfileirado na fila que contém o resultado da expressão postfix.

  É isso, para mais detalhes, acesse https://www.free-online-calculator-use.com/infix-to-postfix-converter.html, lá explica certinho como o
  algoritmo funciona. 

*/
void infix_to_postfix(char* infix, queue_t* postfix) {
  // verifica os pares de parenteses, ou seja, se existe um ')' correspondente a um '('
  // tem oportunidade de melhoria nessa verificação de parenteses, como identificar a posição do parentese inválido
  if(!check_pharenthesis(infix)) {
    fprintf(stderr, "Erro: quantidade incompatível de parênteses, verifique a expressão!\n");
    exit(EXIT_FAILURE);
  }

   // analisador que contém informações úteis para fazer o parser da expressão
  analyzer_t analyzer = {0};

  // pilha dos operadores da expressão
  stack_t operators = {0};

  /* 
    Para o algoritmo funcionar corretamente, é necessário envolver toda a expressão entre parênteses, pois os
    parênteses são um chave importante na hora de transferir os operadores que estão na pilha 'operators' para
    a fila 'postfix'. Toda vez que um ')' é encontrado, esse processo de transferência ocorre até que um '(' 
    esteja no topo da pilha.
  */
  data_t data = {'(', OPERATOR};
  push(&operators, &data); // primeiro operador empilhado é o '('
  infix[strlen(infix)] = ')'; // finaliza a expressão com o ')'

  // percorre a expressão até que não haja mais nenhum token(caractere) a ser lido
  while(get_next_token(infix, &analyzer)) {
    if(isspace(analyzer.curr_token))
      continue; // ignoro os espaços
    else if(isdigit(analyzer.curr_token)) {
      // verifica se o número a seguir é esperado na expressão, isso é necessário para evitar
      // uma sequência sem sentido de números, ex: "10 20 + 30"
      if(!is_number_expected(&analyzer))
        invalid_expression(infix, &analyzer, "Erro: operando não esperado!\n");

      analyzer.last_token_type = NUMBER;
      data.value = get_next_number(infix, &analyzer);
      data.type  = NUMBER;
      enqueue(postfix, &data);
    }
    else if(isoperator(analyzer.curr_token)) {
      data.value = analyzer.curr_token;
      data.type = OPERATOR;

      if(analyzer.curr_token == '(')
        push(&operators, &data); // apenas empilho o '(' em `operators`, demarcando o início de uma sub-expressão
      else if(analyzer.curr_token == ')') {

        // verifica se é esperado receber um número, pois não deve ser possível fechar parêntese faltando operando, exemplo "10 + (22 * )" é um erro
        if(is_number_expected(&analyzer))
          invalid_expression(infix, &analyzer, "Erro: esperava-se um operando\n");

        // quanto um ')' é encontrado, enfileira em 'postfix' todos os operadores que estão empilhados em 'operators' até
        // que um '(' seja encontrado. Isso basicamente monta, no formato postfix, os operadores da 'sub-expressão' que
        // estava entre parênteses
        while(operators.top) {
          data = pop(&operators);
          if(data.value != '(')
            enqueue(postfix, &data);
          else
            break;
        }
      }
      // operador diferente de '(' e ')'
      else {
        // verifica se o operador é esperado, isso evita uma sequência sem sentido de operadores, ex.: "10 + * 30" 
        if(!is_operator_expected(&analyzer))
          invalid_expression(infix, &analyzer, "Erro: operador \"%c\" não esperado!\n", analyzer.curr_token);

        analyzer.last_token_type = OPERATOR;

        // adquire a precedência do operador atual
        int curr_op_precedence = check_precedence(analyzer.curr_token);
        
        // esse loop enfileira em 'postfix' os operadores que estão na pilha até que o operador atual tenha
        // maior precedência que eles, isso garante a ordem que os operadores ficarão no formato postfix
        while(operators.top) {
          data = pop(&operators);
          if(check_precedence(data.value) >= curr_op_precedence)
            enqueue(postfix, &data);
          else {
            // se o operador recém desempilhado possuir menor precedência, insiro ele novamente na pilha
            push(&operators, &data);
            break;
          }
        }

        // insiro na pilha o novo operador
        data.value = analyzer.curr_token;
        push(&operators, &data);
      }
    } // end if isoperator
    else
      invalid_expression(infix, &analyzer, "Símbolo \"%c\" não reconhecido!\n", analyzer.curr_token);

  } // end while
}
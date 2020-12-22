#ifndef EXPRESSION_PARSER_H
#define EXPRESSION_PARSER_H

#include <stdlib.h>
#include <stdbool.h>
#include "ed.h"

typedef struct {
  size_t offset;
  char   curr_token;
  symbol_t last_token_type;
} analyzer_t;

// bool get_next_token(char* buffer, analyzer_t* analyzer);
// int get_next_number(char* buffer, analyzer_t* analyzer);
// bool isoperator(char op);
// int check_precedence(char op);

void infix_to_postfix(char* infix, queue_t* postfix);

#endif  // EXPRESSION_PARSER_H
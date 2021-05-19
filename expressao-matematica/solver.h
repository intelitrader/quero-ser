#ifndef EXPRESSION_SOLVER_H
#define EXPRESSION_SOLVER_H

#include "ed.h"

// Recebe a expressão no formato postfix e retorna resultado
double solve_expression(queue_t* postfix);

#endif // EXPRESSION_SOLVER_H
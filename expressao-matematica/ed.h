#ifndef DATA_STRUCTURES_H
#define DATA_STRUCTURES_H

/*
  Estruturas de dados usadas para fazer parser da expressão matemática e resolvê-la
*/

typedef enum {
  OPERATOR = 1,
  NUMBER
} symbol_t;

typedef struct {
  union {
    double number;
    char   operator;
  };
  symbol_t type;
} data_t;

typedef struct node {
  data_t data;
  struct node* next;
} node_t;

typedef struct {
  node_t* head;
  node_t* tail;
} queue_t;

typedef struct {
  node_t* top;
  size_t  size;
} stack_t;

node_t* new_node(data_t* data);

void enqueue(queue_t* queue, data_t* data);
data_t dequeue(queue_t* queue);

void push(stack_t* stack, data_t* data);
data_t pop(stack_t* stack);

#endif // DATA_STRUCTURES_H
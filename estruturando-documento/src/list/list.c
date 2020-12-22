#include <stdlib.h>
#include <stdio.h>
#include "list.h"
#include "../util/util.h"

list_t* new_list() {
  list_t* list = must_calloc(1, sizeof(list_t));
  return list;
}

static inline node_t* new_node(void* data) {
  node_t* node = must_calloc(1, sizeof(node_t));
  node->data = data;
  
  return node;
}

/*
  Insere um conteúdo genérico no final da lista
*/
void push_back(list_t* list, void* data) {
  node_t* node = new_node(data);

  if(list->head == NULL)
    list->head = node;
  else {
    node->prev = list->tail;
    list->tail->next = node;
  }

  list->tail = node;
  list->size++;
}

/*
  Função auxiliar usada por `at` para retornar o nó que está `steps` posições a frente do
  nó passado em `node`
*/
static node_t* look_ahead(node_t* node, size_t steps) {
  for(int i = 0; i < steps; i++)
    node = node->next;
  
  return node;
}

/*
  Função auxiliar usada por `at` para retornar o nó que está `steps` posições atrás do
  nó passado em `node`
*/
static node_t* look_back(node_t* node, size_t steps) {
  for(int i = 0; i < steps; i++)
    node = node->prev;

  return node;
}

/*
  Retorna o conteúdo genérico contido no nó de índice `index` da lista
*/
void* at(list_t* list, int index) {
  if(index < 0 || index > list->size - 1) {
    fprintf(stderr, "Erro: index %d fora dos limites da lista [0, %lu[\n", index, list->size);
    exit(EXIT_FAILURE);
  }

  int middle = list->size / 2;
  node_t* target = NULL;

  if(index > middle)
    target = look_back(list->tail, list->size - index - 1);
  else
    target = look_ahead(list->head, index);

  return target->data;
}
#include <stdlib.h>
#include <stdio.h>
#include "ed.h"

node_t* new_node(data_t* data) {
  node_t* node = calloc(1, sizeof(node_t));
  if(!node) {
    perror("new_node: calloc");
    exit(EXIT_FAILURE);
  }

  node->data = *data;
  return node;
}

void enqueue(queue_t* queue, data_t* data) {
  node_t* node = new_node(data);
  if(queue->head == NULL) {
    queue->head = node;
    queue->tail = node;
  }
  else {
    queue->tail->next = node;
    queue->tail = node;
  }
}

data_t dequeue(queue_t* queue) {
  data_t ret_data = queue->head->data;
  node_t* aux = queue->head;
  queue->head = queue->head->next;

  free(aux);

  return ret_data;
}

void push(stack_t* stack, data_t* data) {
  node_t* node = new_node(data);
  node->next = stack->top;
  stack->top = node;
  stack->size++;
}

data_t pop(stack_t* stack) {
  data_t ret_data = stack->top->data;
  node_t* aux = stack->top;
  stack->top = stack->top->next;
  stack->size--;

  free(aux);

  return ret_data;
}
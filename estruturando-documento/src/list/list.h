#ifndef HACKERRANK_LIST_H
#define HACKERRANK_LIST_H

#include <stdlib.h>

typedef struct node {
  void* data;
  struct node* next;
  struct node* prev;
} node_t;

typedef struct {
  node_t* head;
  node_t* tail;
  size_t  size;
} list_t;

list_t* new_list();
void push_back(list_t* list, void* data);
void* at(list_t* list, int index);

#endif // HACKERRANK_LIST_H
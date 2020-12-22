#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include "util.h"

void* must_calloc(size_t num_elements, size_t size) {
  void* ptr = calloc(num_elements, size);
  if(ptr == NULL) {
    perror("must_calloc: calloc");
    exit(EXIT_FAILURE);
  }

  return ptr;
}

char* dup_string(const char* str) {
  size_t length = strlen(str) + 1;
  char* copy = must_calloc(length, sizeof(char));

  memcpy(copy, str, length);
  return copy;
}

char* get_input() {	
  char* input = must_calloc(MAX_CHARACTERS, sizeof(char));
  size_t offset = 0;

  int num_paragraphs = 0;
  scanf("%d", &num_paragraphs);
  getchar();

  while(num_paragraphs) {
    fgets(&input[offset], MAX_CHARACTERS, stdin);
    offset += strlen(&input[offset]);

    num_paragraphs--;
  }

  return input;
}
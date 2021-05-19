#ifndef HACKERRANK_UTIL_H
#define HACKERRANK_UTIL_H

#include <stdlib.h>

#define MAX_CHARACTERS 1005

void* must_calloc(size_t num_elements, size_t size);
char* dup_string(const char* str);
char* get_input();

#endif // HACKERRANK_UTIL_H
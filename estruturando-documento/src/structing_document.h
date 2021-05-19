#ifndef STRUCT_DOCUMENT_H
#define STRUCT_DOCUMENT_H

#include <stdlib.h>
#include "list/list.h"

/*
  Exemplo de estrutura:
                               +---------------------+
                               |      DOCUMENTO      | document_t = lista de parágrafos
                               +----+-----------+----+
                                    |           |
                           +--------+           +--------+
                           |                             |
                           |                             |
                     +-----+-----+                 +-----+-----+
                     | PARÁGRAFO |                 | PARÁGRAFO | paragraph_t = lista de frases
                     +--+-----+--+                 +--+-----+--+
                        |     |                       |     |           
                  +-----+     +-----+           +-----+     +-----+     
                  |                 |           |                 |     
             +----+----+       +----+----+ +----+----+       +----+----+
             |  FRASE  |       |  FRASE  | |  FRASE  |       |  FRASE  | sentence_t = lista de palavras
             +--+---+--+       +--+---+--+ +--+---+--+       +--+---+--+
                |   |             |   |       |   |             |   |
            palavra |         palavra |   palavra |         palavra |    word_t = vetor de caracteres
                    |                 |           |                 |
                 palavra           palavra     palavra           palavra
*/

/* syntax-sugars */
typedef char* word_t;
typedef list_t sentence_t;  // uma sentança é uma lista de `word_t`
typedef list_t paragraph_t; // um parágrafo é uma lista de `sentence_t`
typedef list_t document_t;  // um documento é uma lista de `paragraph_t`

#define word_sep      (" ")
#define sentence_sep  (".")
#define paragraph_sep ("\n")

void get_document(document_t* doc, char* text);
void destroy_document(document_t* doc);

/*                FUNÇÕES SUGERIDAS PELO DESAFIO NO HACKERRANK                  */

word_t kth_word_in_mth_sentence_of_nth_paragraph(document_t* doc, int k, int m, int n);
sentence_t* kth_sentence_in_mth_paragraph(document_t* doc, int k, int m);
paragraph_t* kth_paragraph(document_t* doc, int k);

void print_paragraph(paragraph_t* paragraph);
void print_sentence(sentence_t* sentence);

#endif // STRUCT_DOCUMENT_H
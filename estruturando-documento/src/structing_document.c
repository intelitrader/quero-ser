#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include "structing_document.h"
#include "list/list.h"
#include "util/util.h"

/*
  Monta a estrutura do documento
  A montagem é feita da seguinte forma:
    - monta uma frase a partir de palavras
    - monta um parágrafo a partir de frases montadas anteriormente
    - monta o documento a partir de parágrafos montados anteriormente
*/
void get_document(document_t* doc, char* text) {
  // ponteiros para serem usados em strtok_r
  char* paragraph_save = NULL,
      * sentence_save  = NULL,
      * word_save      = NULL;

  // listas que serão manipuladas ao longo da análise do texto.
  list_t* sentence  = NULL, // será constituída de palavras
        * paragraph = NULL; // será constituída de sentenças
  
  // adquire cada parágrafo do texto
  char* token = strtok_r(text, paragraph_sep, &paragraph_save);
  while(token) {
    paragraph = new_list(); // novo parágrafo

    // adquire cada frase do parágrafo
    token = strtok_r(token, sentence_sep, &sentence_save);
    while(token) {
      sentence = new_list();
      // adquire cada palavra da frase
      token = strtok_r(token, word_sep, &word_save);
      while(token) {
        // adiciona uma palavra à frase atual
        push_back(sentence, dup_string(token));
        token = strtok_r(NULL, word_sep, &word_save);
      }

      // adiciona uma frase ao parágrafo atual
      push_back(paragraph, sentence);
      token = strtok_r(NULL, sentence_sep, &sentence_save);
    }

    // adiciona um parágrafo ao documento
    push_back(doc, paragraph);
    token = strtok_r(NULL, paragraph_sep, &paragraph_save);
  }
}

// libera memória de uma frase
static void destroy_sentence(sentence_t* s) {
  node_t* w_aux     = s->head,
        * save_next = NULL;
  
  while(w_aux) {
    save_next = w_aux->next;

    word_t* w = w_aux->data;
    free(w);
    free(w_aux);

    w_aux = save_next;
  }
  free(s);
}

// libera memória de um parágrafo
static void destroy_paragraph(paragraph_t* p) {
  node_t* s_aux     = p->head,
        * save_next = NULL;
  
  while(s_aux) {
    save_next = s_aux->next;

    sentence_t* s = s_aux->data;
    destroy_sentence(s);
    free(s_aux);

    s_aux = save_next;
  }
  free(p);
}

// libera memória de todo o documento
void destroy_document(document_t* doc) {
  node_t* d_aux     = doc->head,
        * save_next = NULL;

  while(d_aux) {
    save_next = d_aux->next;

    paragraph_t* p = d_aux->data;
    destroy_paragraph(p);
    free(d_aux);

    d_aux = save_next;
  }
}

/*                 FUNÇÕES SUGERIDAS PELO DESAFIO NO HACKERRANK                */
word_t kth_word_in_mth_sentence_of_nth_paragraph(document_t* doc, int k, int m, int n) {
  sentence_t* s = kth_sentence_in_mth_paragraph(doc, m, n);
  return at(s, k);
}

sentence_t* kth_sentence_in_mth_paragraph(document_t* doc, int k, int m) { 
  paragraph_t* p = kth_paragraph(doc, m);
  return at(p, k);
}

paragraph_t* kth_paragraph(document_t* doc, int k) {
  return at(doc, k);
}

void print_paragraph(paragraph_t* paragraph) {
  for(node_t* aux = paragraph->head; aux; aux = aux->next) {
    print_sentence(aux->data);
    putchar('.');
  }
}

void print_sentence(sentence_t* sentence) {
  for(node_t* aux = sentence->head; aux; aux = aux->next) {
    printf("%s", (char*) aux->data);
    if(aux->next != NULL)
      putchar(' ');
  }
}
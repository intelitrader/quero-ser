#include <stdlib.h>
#include <stdio.h>
#include "src/structing_document.h"
#include "src/list/list.h"
#include "src/util/util.h"

int main(int argc, char* argv[]) {

  char* input = get_input();

  document_t doc = {0};
  get_document(&doc, input);

  int queries;
  scanf("%d", &queries);

  while(queries--) {
    int query_type, k = 0, m = 0, n = 0;

    scanf("%d", &query_type);
  

    switch(query_type) {
      case 1:
        scanf("%d", &k);
        
        paragraph_t* paragraph = kth_paragraph(&doc, k-1);
        print_paragraph(paragraph);
        break;
      case 2:
        scanf("%d %d", &k, &m);
        
        sentence_t* sentence = kth_sentence_in_mth_paragraph(&doc, k-1, m-1);
        print_sentence(sentence);
        break;
      case 3:
        scanf("%d %d %d", &k, &m, &n);
        
        word_t word = kth_word_in_mth_sentence_of_nth_paragraph(&doc, k-1, m-1, n-1);
        printf("%s", word);
        break;
    }

    putchar(10);
  }

  destroy_document(&doc);
  free(input);

  return EXIT_SUCCESS;
}
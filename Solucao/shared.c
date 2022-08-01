#include "shared.h"

int isFileNotOpen (FILE * openedFile, char * filesName) {
    if (!openedFile) {
        puts ("Could not open a file! Is the file's name correct?");
        printf ("Current file's name: %s\n", filesName);
        return 1;
    }
    return 0;
}
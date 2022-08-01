#include <stdio.h>
#include <stdlib.h>
#include "transfer.h"
#include "shared.h"
#include "divergence.h"
#include "channels.h"

int main () {

    FILE * pointerToProductsFile = NULL, * pointerToSellsFile = NULL;

    pointerToProductsFile = fopen (PRODUCTS_FILE, "r");
    pointerToSellsFile = fopen (SELLS_FILE, "r");
    if (isFileNotOpen (pointerToProductsFile, PRODUCTS_FILE) || isFileNotOpen (pointerToSellsFile, SELLS_FILE))
        return EXIT_FAILURE;
        
    if (generateTransferReport (pointerToProductsFile, pointerToSellsFile)) {
        puts ("Could not generate the tranfer's report file!");
        return EXIT_FAILURE;
    }

    if (generateDivergenceReport (pointerToProductsFile, pointerToSellsFile)) {
        puts ("Could not generate the divergence's file!");
        return EXIT_FAILURE;
    }

    if (generateChannelsReport (pointerToSellsFile)) {
        puts ("Could not generate the channel's report file!");
        return EXIT_FAILURE;
    }

    fclose (pointerToProductsFile);
    fclose (pointerToSellsFile);

    return EXIT_SUCCESS;
}
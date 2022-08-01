#include "divergence.h"

int qntdProductsRegistered (FILE *);
int analyzeDivergences (int **, int, FILE *, FILE *);

int generateDivergenceReport (FILE * products, FILE * sells) {
    FILE * report = fopen (DIVERGENCE_FILE, "w");
    if (isFileNotOpen (report, DIVERGENCE_FILE))
        return -1;

    int qntdProducts = qntdProductsRegistered (products);
    int ** productsCodes = calloc (qntdProducts, sizeof (int *));

    for (int i = 0; i < qntdProducts; i++)
        productsCodes[i] = malloc (sizeof (int));

    for (int i = 0; i < qntdProducts; i++) {
        int productsCode, operationalCenterQuantity, operacionalCenterMinimumStock;
        fscanf (products, "%d;%d;%d\n", &productsCode, &operationalCenterQuantity, &operacionalCenterMinimumStock);
        *productsCodes[i] = productsCode;
    }

    if (!analyzeDivergences (productsCodes, qntdProducts, sells, report))
        return 0;

    for (int i = 0; i < qntdProducts; i++)
        free (productsCodes[i]);

    free (productsCodes);
    fclose (report);
    fseek (products, 0, SEEK_SET);
    printf ("Reported file generated! File's name: %s\n", DIVERGENCE_FILE);
    return 0;
}

int analyzeDivergences (int ** products, int qntdProducts, FILE * sells, FILE * report) {

    int row = 0;
    while (!feof (sells)) {
        int sellsProductsCode, sellsQuantity, sellsState, sellsPlatform;
        fscanf (sells, "%d;%d;%d;%d\n", &sellsProductsCode, &sellsQuantity, &sellsState, &sellsPlatform);
        switch (sellsState) {
            case CANCELLED:
                fprintf (report, "LINHA %2d - Venda cancelada\n", row + 1); break;
            case NOT_FINISHED:
                fprintf (report, "LINHA %2d - Venda não finalizada\n", row + 1); break;
            case UNDEFINED_ERROR:
                fprintf (report, "LINHA %2d - Error desconhecido. Acionar equipe de TI\n", row + 1);
        }
        int found = 0;
        for (int i = 0; i < qntdProducts; i++) {
            if (*products[i] == sellsProductsCode) {
                found = 1;
                break;
            }
        }
        if (!found)
            fprintf (report, "Linha %2d - Código de produto não encontrado %2d\n", row + 1, sellsProductsCode);
        row++;
    }

    fseek (sells, 0, SEEK_SET);
    return -1;
}

int qntdProductsRegistered (FILE * products) {
    int i = 0;
    while (!feof (products)) {
        int productsCode, operationalCenterQuantity, operacionalCenterMinimumStock;
        fscanf (products, "%d;%d;%d\n", &productsCode, &operationalCenterQuantity, &operacionalCenterMinimumStock);
        i++;
    }
    fseek (products, 0, SEEK_SET);
    return i + 1;
}
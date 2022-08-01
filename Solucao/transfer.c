#include "transfer.h"

#define ABS(number) (number >= 0) ? number : -number

int calculateRequiredTransfer (int);
int calculateTransferQntd (int);

int generateTransferReport (FILE * products, FILE * sells) {
    FILE * report = NULL;

    report = fopen (TRANSFERS_FILE, "w");
    if (isFileNotOpen (report, TRANSFERS_FILE))
        return -1;

    fprintf (report, "Necessidade de Transferência Armazém para CO\n\nProduto  QtCO  QtMin  QtVendas  Estq.após  Necess.  Transf. de\n\t\t\t\t   Vendas\t     Arm p/ CO\n");
    while (!feof (products)) {
        int productsCode, operationalCenterQuantity, operacionalCenterMinimumStock;
        fscanf (products, "%d;%d;%d\n", &productsCode, &operationalCenterQuantity, &operacionalCenterMinimumStock);
        analyzeSells (sells, report, productsCode, operationalCenterQuantity, operacionalCenterMinimumStock);
    }
    
    fclose (report);
    fseek (products, 0, SEEK_SET);
    printf ("Reported file generated! File's name: %s\n", TRANSFERS_FILE);
    return 0;
}

void analyzeSells (FILE * sells, FILE * report, int productsCode, int OCQntd, int OCMinStock) {
    int sumSellsQuantity = 0;
    while (!feof (sells)) {
        int sellsProductsCode, sellsQuantity, sellsState, sellsPlatform;
        fscanf (sells, "%d;%d;%d;%d\n", &sellsProductsCode, &sellsQuantity, &sellsState, &sellsPlatform);
        if (productsCode == sellsProductsCode && (sellsState == CONFIRMED_PAID || sellsState == CONFIRMED_NOT_PAID)) 
            sumSellsQuantity += sellsQuantity;
    }

    int stockAfterSells = OCQntd - sumSellsQuantity;
    int transferQntd = stockAfterSells - OCMinStock;
    fprintf (report, "%d\t %d\t%d\t%d\t%d\t   %d\t\t%d\n", productsCode, OCQntd, OCMinStock, sumSellsQuantity, stockAfterSells, calculateRequiredTransfer (transferQntd), calculateTransferQntd (transferQntd));
    fseek (sells, 0, SEEK_SET);
}

int calculateRequiredTransfer (int transferQntd) {
    return transferQntd >= 0 ? 0 : ABS(transferQntd);
}

int calculateTransferQntd (int transferQntd) {
    int requiredQntd = calculateRequiredTransfer (transferQntd);
    if (requiredQntd > 1 && requiredQntd < 10)
        return 10;
    return requiredQntd;
}
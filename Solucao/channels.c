#include "channels.h"

int generateChannelsReport (FILE * sells) {
    FILE * report = NULL;
    report = fopen (CHANNELS_FILE, "w");

    if (isFileNotOpen (report, CHANNELS_FILE))
        return -1;

    int agentsSells, siteSells, androidSells, iosSells;
    agentsSells = siteSells = androidSells = iosSells = 0;

    while (!feof (sells)) {
        int sellsProductsCode, sellsQuantity, sellsState, sellsPlatform;
        fscanf (sells, "%d;%d;%d;%d\n", &sellsProductsCode, &sellsQuantity, &sellsState, &sellsPlatform);
        if (sellsState == CONFIRMED_PAID || sellsState == CONFIRMED_NOT_PAID)
            switch (sellsPlatform) {
                case AGENT: agentsSells += sellsQuantity; break;
                case SITE: siteSells += sellsQuantity; break;
                case ANDROID: androidSells += sellsQuantity; break;
                case IOS: iosSells += sellsQuantity;
            }
    }

    fprintf (report, "Quantidades de Vendas por canal\n\n1 - Representantes\t\t\t%3d\n2 - Website\t\t\t\t    %3d\n3 - App móvel Android\t\t%3d\n4 - App móvel iPhone\t\t%3d\n", agentsSells, siteSells, androidSells, iosSells);

    fclose (report);
    fseek (sells, 0, SEEK_SET);
    printf ("Reported file generated! File's name: %s\n", CHANNELS_FILE);
    return 0;
}
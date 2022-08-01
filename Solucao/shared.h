#include <stdio.h>

#ifndef _METADATA_H
#define _METADATA_H

#define PRODUCTS_FILE "PRODUTOS.TXT"
#define SELLS_FILE "VENDAS.TXT"
#define TRANSFERS_FILE "TRANSFERE.TXT"
#define DIVERGENCE_FILE "DIVERGENCIAS.TXT"
#define CHANNELS_FILE "TOTCANAIS.TXT"

#define CONFIRMED_PAID 100
#define CONFIRMED_NOT_PAID 102
#define CANCELLED 135
#define NOT_FINISHED 190
#define UNDEFINED_ERROR 999

#define AGENT 1
#define SITE 2
#define ANDROID 3
#define IOS 4

int isFileNotOpen (FILE *, char *);

#endif
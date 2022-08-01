#include <stdio.h>
#include "shared.h"

#ifndef _TRANSFER_H
#define _TRANSFER_H

int generateTransferReport (FILE *, FILE *);
void analyzeSells (FILE *, FILE *, int, int, int);

#endif
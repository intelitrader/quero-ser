import { fileReader } from "./utils.js";
import { transfereWriterFile } from "./transfereWriterFile.js";
import { divergencesWriterFile } from "./divergencesWriterFile.js";
import { totSalesPerChannelWriterFile } from "./totSalesPerChannelWriterFile.js";

/**
 *  PATH OF THE FILE THAT WILL BE READED
 */
export const productsData = fileReader("./Caso de teste 2/c2_produtos.txt");
export const salesData = fileReader("./Caso de teste 2/c2_vendas.txt");

/**
 * TRANSFERE,DIVERGENCIAS AND TOTCANAIS TXT CREATED
 * FUNCTION ARGUMENTS ARE THE NAME OF THE FILE THAT WILL BE CREATED
 */
transfereWriterFile("transfere.txt");
divergencesWriterFile("Divergencias.txt");
totSalesPerChannelWriterFile("Totcanais.txt");

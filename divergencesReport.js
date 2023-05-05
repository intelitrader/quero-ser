import fs from "node:fs"
import { productsArrayResult } from "./readingFiles.js";
import { salesArrayResult } from "./readingFiles.js";

const sales = salesArrayResult
const products = productsArrayResult

const divergences = [];

for (const [line, sale] of Object.entries(sales)){
    if (!products[sale.productCode]){
        divergences.push(`Linha ${line} - Código do produto não encontrado ${sale.productCode}`)
    }
    if (sale.sellSituation === '135') {
        divergences.push(`Linha ${line} - Venda cancelada`);
      }
    if (sale.sellSituation === '190') {
        divergences.push(`Linha ${line} - Venda não finalizada`);
      }
    if (sale.sellSituation === '999') {
        divergences.push(`Linha ${line} - Erro desconhecido. Acionar equipe de TI.`);
      }
}

fs.writeFileSync("DIVERGENCIAS.TXT", divergences.join("\n"), "utf-8")
console.log(divergences)
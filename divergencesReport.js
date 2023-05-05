import fs from "node:fs"
import { productsArrayResult } from "./readingFiles.js";
import { salesArrayResult } from "./readingFiles.js";

const sales = salesArrayResult;
const products = productsArrayResult

const divergences = [];

for (const [line, sale] of Object.entries(sales)){
  if (!products[sales.productCode]){
      divergences.push(`Linha ${line} - Código do produto não encontrado ${sale.productCode}`)
  }
  if (sales.sellSituation === '135') {
      divergences.push(`Linha ${line} - Venda cancelada`);
    }
  if (sales.sellSituation === '190') {
      divergences.push(`Linha ${line} - Venda não finalizada`);
    }
  if (sales.sellSituation === '999') {
      divergences.push(`Linha ${line} - Erro desconhecido. Acionar equipe de TI.`);
    }
}

fs.writeFileSync("DIVERGENCIAS.TXT", divergences.join("\n"), "utf-8")
console.log(divergences)
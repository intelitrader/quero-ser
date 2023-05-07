import fs from "node:fs";
import { salesArrayResult } from "./readingFiles.js";

const sales = salesArrayResult

const confirmedSalesFiltered = sales.filter((sale) => sale.sellSituation === '100' || sale.sellSituation === '102')

const repSales = confirmedSalesFiltered.filter((sale) => sale.channel === '1').length;
const websiteSales = confirmedSalesFiltered.filter((sale) => sale.channel === '2').length;
const androidSales = confirmedSalesFiltered.filter((sale) => sale.channel === '3').length;
const iphoneSales = confirmedSalesFiltered.filter((sale) => sale.channel === '4').length; 


const content = 
`Quantitdade de vendas por canal\n\n1 - Representantes = ${repSales}\n2 - Website = ${websiteSales}\n3 - App móvel Android = ${androidSales}\n4 - App móvel iPhone = ${iphoneSales}`;

fs.writeFileSync("TOTCANAIS.TXT", content, "utf-8");

console.log(content);

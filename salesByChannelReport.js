import fs from "node:fs";

const salesFile = fs.readFileSync(
  "./Desafio/Caso de teste 1/c1_vendas.txt",
  "utf-8"
);
const salesArray = salesFile.split("\r\n");
const salesArrayResult = [];

salesArray.forEach((line, index) => {
  const [productCode, QtSales, sellSituation, channel] = line.split(";");
  if (sellSituation === '100' || sellSituation === '102'){
    salesArrayResult[index] = {
      productCode,
      QtSales: QtSales || 0,
      sellSituation,
      channel,
    };
  }
  return salesArrayResult;
});

let repCount = 0;
let websiteCount = 0;
let androidCount = 0;
let iphoneCount = 0;

for (let i = 0; i < salesArrayResult.length; i++) {
  if(salesArrayResult[i].channel === '1'){
    repCount++;
  }
  if (salesArrayResult[i].channel === '2'){
    websiteCount++
  }
  if (salesArrayResult[i].channel === '3'){
    androidCount++
  }
  if (salesArrayResult[i].channel === '4'){
    iphoneCount++
  }
}

const content = `Quantitdade de vendas por canal\n\n1 - Representantes = ${repCount}\n2 - Website = ${websiteCount}\n3 - App móvel Android = ${androidCount}\n4 - App móvel iPhone = ${iphoneCount}`;

fs.writeFileSync("TOTCANAIS.TXT", content, "utf-8");

console.log(salesArrayResult)
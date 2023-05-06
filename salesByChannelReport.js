import fs from "node:fs";

const salesFile = fs.readFileSync(
  "./Desafio/Caso de teste 1/c1_vendas.txt",
  "utf-8"
);
const salesArray = salesFile.split("\r\n");

const salesArrayResult = salesArray.reduce((result, line) => {
  const [productCode, QtSales, sellSituation, channel] = line.split(";");
  if (sellSituation === "100" || sellSituation === "102") {
    result.push({
      productCode,
      QtSales: QtSales || 0,
      sellSituation,
      channel,
    });
  }
  return result;
}, []);

const repSales = salesArrayResult.filter((sale) => sale.channel === '1').length;
const websiteSales = salesArrayResult.filter((sale) => sale.channel === '2').length;
const androidSales = salesArrayResult.filter((sale) => sale.channel === '3').length;
const iphoneSales = salesArrayResult.filter((sale) => sale.channel === '4').length; 


const content = 
`Quantitdade de vendas por canal\n\n1 - Representantes = ${repSales}\n2 - Website = ${websiteSales}\n3 - App móvel Android = ${androidSales}\n4 - App móvel iPhone = ${iphoneSales}`;

fs.writeFileSync("TOTCANAIS.TXT", content, "utf-8");

console.log(salesArrayResult);

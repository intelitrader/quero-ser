import fs from "node:fs"

const productsFile = fs.readFileSync("./Desafio/Caso de teste 1/c1_produtos.txt", "utf8");
const productsArray = productsFile.split("\r\n");

export const productsArrayResult = [];

productsArray.forEach((line, index) => {
    const [productCode, QtCO, QtMin] = line.split(";")
    productsArrayResult[index + 1] = {productCode, QtCO, QtMin}
    return productsArrayResult
})

const salesFile = fs.readFileSync('./Desafio/Caso de teste 1/c1_vendas.txt', 'utf-8');
const salesArray = salesFile.split('\r\n');

export const salesArrayResult = [];

salesArray.forEach((line, index) => {
  const [productCode, QtSales, sellSituation, channel] = line.split(";");
  if (sellSituation === '100' || sellSituation === '102') {
    salesArrayResult[index + 1] = { productCode, QtSales, sellSituation, channel };
  }
  return salesArrayResult
});


console.log(salesArrayResult)
console.log(productsArrayResult)
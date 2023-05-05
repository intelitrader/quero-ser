import fs from "node:fs"

const productsFile = fs.readFileSync("./Desafio/Caso de teste 1/c1_produtos.txt", "utf8");
const productsArray = productsFile.split("\n");

export const productsArrayResult = {};

productsArray.forEach((line) => {
    const [productCode, QtCO, QtMin] = line.split(";")
    productsArrayResult[productCode] = {QtCO, QtMin}
    
})

console.log(productsArrayResult)

const salesFile = fs.readFileSync('./Desafio/Caso de teste 1/c1_vendas.txt', 'utf-8');
const salesArray = salesFile.split('\n');

export const sales = {};

salesArray.forEach((line, index) => {
  const [productCode, QtSales, sellSituation, channel] = line.split(";");
  if (sellSituation === '100' || sellSituation === '102') {
    sales[index + 1] = { productCode, QtSales, sellSituation, channel };
  }
});

console.log(sales);

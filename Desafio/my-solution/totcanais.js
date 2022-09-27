const { readFileSync, writeFileSync } = require("fs");
const productsData = readFileSync("./data/c1_produtos.txt", "utf8");
const salesData = readFileSync("./data/c1_vendas.txt", "utf8");

//Converts a string of data into an array, separating it with "\n" and ";"...
const convertStringDataToArray = (stringData) => {
  const dataArray = stringData.split("\n");
  return dataArray.map((data) => data.split(";"));
};
productsDataArray = convertStringDataToArray(productsData);

// Generating an array with only the product codes.
const productCodesArray = [];
productsDataArray.forEach((product) => {
  productCodesArray.push(Number(product[0]));
});

//Converting string data of the sales into array
salesDataInfo = convertStringDataToArray(salesData);

let sellerSales = 0;
let websiteSales = 0;
let androidAppSales = 0;
let iphoneAppSales = 0;

for (const sale of salesDataInfo) {
  if (sale[2] === "100" || sale[2] === "102") {
    if (sale[3] === "1") {
      sellerSales += Number(sale[1]);
      continue;
    }
    if (sale[3] === "2") {
      websiteSales += Number(sale[1]);
      continue;
    }
    if (sale[3] === "3") {
      androidAppSales += Number(sale[1]);
      continue;
    } else {
      iphoneAppSales += Number(sale[1]);
    }
  }
}

const totCanaisInfo = `Quantidade de vendas por canal\n
1 - Representantes             ${sellerSales}
2 - Website                    ${websiteSales}
3 - App móvel Android          ${androidAppSales}
4 - App móvel iPhone           ${iphoneAppSales}`;

writeFileSync("output/totcanais.txt", totCanaisInfo);

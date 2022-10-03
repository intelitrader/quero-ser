import { readFileSync, writeFileSync } from "fs";
const productsData = readFileSync("./data/c1_produtos.txt", "utf8");
const salesData = readFileSync("./data/c1_vendas.txt", "utf8");

//Converts a string of data into an array, separating it with "\n" and ";"...
const convertStringDataToArray = (stringData) => {
  const dataArray = stringData.split("\n");
  return dataArray.map((data) => data.split(";"));
};

let productsDataInfo = convertStringDataToArray(productsData);

// Generating an array with only the product codes.
const productCodesArray = [];
productsDataInfo.forEach((product) => {
  productCodesArray.push(Number(product[0]));
});

//Converting string data of the sales into array
let salesDataInfo = convertStringDataToArray(salesData);

let divergencesInfo = "";

for (const sale of salesDataInfo) {
  //Test to identify non-existent code in the product list.
  if (!productCodesArray.includes(Number(sale[0]))) {
    divergencesInfo += `Linha ${
      salesDataInfo.indexOf(sale) + 1
    } - Código de produto não encontrado ${sale[0]}\n`;
  } else {
    // Test to identify canceled sale
    if (sale[2] === "135") {
      divergencesInfo += `Linha ${
        salesDataInfo.indexOf(sale) + 1
      } - Venda cancelada\n`;
      continue;
    }
    // Test to identify unfineshed sale
    if (sale[2] === "190") {
      divergencesInfo += `Linha ${
        salesDataInfo.indexOf(sale) + 1
      } - Venda não finalizada\n`;
      continue;
    }
    // Test to identify unknown error.
    if (sale[2] === "999") {
      divergencesInfo += `Linha ${
        salesDataInfo.indexOf(sale) + 1
      } - Erro desconhecido. Acionar equipe de TI\n`;
    }
  }
}

//Generating "divergencias" file
writeFileSync("output/divergencias.txt", divergencesInfo);

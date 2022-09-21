const { readFileSync } = require("fs");
const productsData = readFileSync("./data/c1_produtos.txt","utf8");
const salesData = readFileSync("./data/c1_vendas.txt","utf8");

// Converts a string of data into an array, separating it with "\n" and ";"...
const convertStringDataToArray = (stringData) => {
    const dataArray = stringData.split("\n");
    return dataArray.map(data => data.split(";"));
}

salesDataArray = convertStringDataToArray(salesData);

salesDataArray.map( sale => console.log(sale));


import { table } from "table";
import { readFileSync, writeFileSync } from "fs";
const productsData = readFileSync("./data/c1_produtos.txt", "utf8");
const salesData = readFileSync("./data/c1_vendas.txt", "utf8");

//Converts a string of data into an array, separating it with "\n" and ";"...
const convertStringDataToArray = (stringData) => {
  const dataArray = stringData.split("\n");
  return dataArray.map((data) => data.split(";"));
};

let transferInfo = "";
let productsDataInfo = [];
let salesDataInfo = [];

//Converting string data of the products into array
productsDataInfo = convertStringDataToArray(productsData);

//Converting string data of the sales into array
salesDataInfo = convertStringDataToArray(salesData);

let infoSaleByProduct = [
  [
    "Produto",
    "QtCO",
    "QtMin",
    "QtVendas",
    "Estq. após vendas",
    "Necess Repo",
    "Transf. Arm p/ CO",
  ],
];

for (const infoProduct of productsDataInfo) {
  let quantSale = 0;
  let inventoryAfterSales = 0;
  let stockNeedReplenishment = 0;
  let quantTransferToWarehouse = 0;

  for (const infoSale of salesDataInfo) {
    if (
      infoProduct[0] === infoSale[0] &&
      (infoSale[2] === "100" || infoSale[2] === "102")
    ) {
      quantSale += Number(infoSale[1]);
    }
  }
  inventoryAfterSales = Number(infoProduct[1] - quantSale);

  if (inventoryAfterSales < Number(infoProduct[2])) {
    stockNeedReplenishment = Number(infoProduct[2]) - inventoryAfterSales;
  }

  if (stockNeedReplenishment > 1 && stockNeedReplenishment < 10) {
    quantTransferToWarehouse = 10;
  } else {
    quantTransferToWarehouse = stockNeedReplenishment;
  }

  infoSaleByProduct.push([
    ...infoProduct,
    quantSale,
    inventoryAfterSales,
    stockNeedReplenishment,
    quantTransferToWarehouse,
  ]);
}

transferInfo = table(infoSaleByProduct);

// Generating "transfere" file
writeFileSync(
  "output/transfere.txt",
  `Necessidade de transferência - Armazém para CO\n\n`
);
writeFileSync("output/transfere.txt", transferInfo, { flag: "a" });

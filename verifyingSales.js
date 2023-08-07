import fs from "node:fs";
import { productsArrayResult } from "./readingFiles.js";
import { salesArrayResult } from "./readingFiles.js";

const products = productsArrayResult;
const sales = salesArrayResult;

// grouping sales by productCode
const salesByProduct = sales.reduce((acc, sale) => {
  const productCode = sale.productCode;
  const qtSales = parseInt(sale.QtSales);
  if (acc[productCode]) {
    acc[productCode] += qtSales;
  } else {
    acc[productCode] = qtSales;
  }
  return acc;
}, {});

const transferProducts = products.map((product) => {
  const qtSales = salesByProduct[product.productCode] || 0;
  const afterSaleInventory = product.QtCO - qtSales;
  const need = product.QtMin - afterSaleInventory;
  const transfer = (need > 1 && need < 10) ? 10 : 0;
  return {
    productCode: product.productCode,
    QtCO: product.QtCO,
    QtMin: product.QtMin,
    QtSales: qtSales,
    afterSaleInventory,
    need,
    transfer,
  };
});


const header =
  "Necessidade de Transferência Armazém para CO\n\nProduto - QtCO - QtMin - QtVendas - Estq. após venda - Necess. - Transf. de Arm p/ Co\n\n";
const rows = transferProducts.map(
  (product) =>
    `${product.productCode}\t - ${product.QtCO}\t - ${product.QtMin}\t - ${product.QtSales}\t - ${product.afterSaleInventory}\t\t - ${product.need}\t\t - ${product.transfer}\t\t\n`
);

fs.writeFileSync("TRANSFERE.txt", header + rows.join(""));

import fs from "node:fs";
import { productsArrayResult } from "./readingFiles.js";
import { salesArrayResult } from "./readingFiles.js";

const products = productsArrayResult;
const sales = salesArrayResult;

// calculating the need to transfer products
const transferProducts = products.map((product) => {
  const QtSales = sales[product.productCode] || 0;
  const afterSaleInventory = product.QtCO - QtSales;
  const need = Math.max(product.QtMin - afterSaleInventory, 0);
  const transfer = Math.min(need, afterSaleInventory);

  return {
    productCode: product.productCode,
    QtCO: product.QtCO,
    QtMin: product.QtMin,
    QtSales,
    afterSaleInventory,
    need,
    transfer,
  };
});

// writing results on "transfere.txt" file
const header =
  "Necessidade de Transferência Armazém para CO\n\nProduto - QtCO - QtMin - QtVendas - Estq. após venda - Necess. - Transf. de Arm p/ Co\n\n";
const rows = transferProducts.map(
  (product) =>
    `${product.productCode}\t - ${product.QtCO}\t - ${product.QtMin}\t - ${product.QtSales}\t - ${product.afterSaleInventory}\t\t - ${product.need}\t\t - ${product.transfer}\t\t\n`
);

fs.writeFileSync("TRANSFERE.txt", header + rows.join(" "));

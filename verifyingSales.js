import fs from "node:fs";

class Products {
  productCode;
  quantitie;
  QtMin;
  QtSales;
  need;
  transfer;

  constructor(p_productCode, p_quantitie, p_QtMin) {
    this.productCode = p_productCode;
    this.quantitie = p_quantitie;
    this.QtMin = p_QtMin;
    this.QtSales = 0;
    this.need = 0;
    this.transfer = 0;
  }
}

class Sales {
  productCode;
  QtSales;
  sellSituation;
  channel;

  constructor(s_productCode, s_QtSales, s_sellSituation, s_channel) {
    this.productCode = s_productCode;
    this.QtSales = s_QtSales;
    this.sellSituation = s_sellSituation;
    this.channel = s_channel;
  }
}

// reading "PRODUTOS.TXT"
const products = fs
  .readFileSync("./Desafio/Caso de teste 1/c1_produtos.txt", "utf-8", (err, data) => {
    if (err) throw err;
  })
  .trim()
  .split("\n")
  .map((line) => {
    const [productCode, QtCO, QtMin] = line.split(";");

    return { productCode, QtCO: parseInt(QtCO), QtMin: parseInt(QtMin) };
  });

// reading "vendas.txt" and calculating confirmed sales
const sales = fs
  .readFileSync("./Desafio/Caso de teste 1/c1_vendas.txt", "utf-8", (err, data) => {
    if (err) throw err;
  })
  .trim()
  .split("\n")
  .reduce((acc, line) => {
    const [productCode, QtSales, sellSituation] = line.split(" ");
    if (sellSituation === "100" || sellSituation === "102") {
      acc[productCode] = (acc[productCode] || 0) + parseInt(QtSales);
    }
    return acc;
  }, {});

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
  "Produto - QtCO - QtMin - QtVendas - Estq. após venda - Necess. - Transf. de Arm p/ Co\n";
const rows = transferProducts.map(
  (product) =>
    `${product.productCode}\t - ${product.QtCO}\t - ${product.QtMin}\t - ${product.QtSales}\t - ${product.afterSaleInventory}\t - ${product.need}\t\t - ${product.transfer}\t\t\n`
);

fs.writeFileSync("TRANSFERE.txt", header + rows.join(" "));
import fs from "node:fs";

const salesFile = fs.readFileSync(
  "./Desafio/Caso de teste 1/c1_vendas.txt",
  "utf-8"
);
const salesArray = salesFile.split("\r\n");

const salesArrayResult = [];

salesArray.forEach((line, index) => {
  const [productCode, QtSales, sellSituation, channel] = line.split(";");
  if (
    sellSituation === "100" ||
    sellSituation === "102" ||
    sellSituation === "135" ||
    sellSituation === "190" ||
    sellSituation === "999"
  ) {
    salesArrayResult[index + 1] = {
      productCode,
      QtSales,
      sellSituation,
      channel,
    };
  }
  return salesArrayResult;
});

const productsFile = fs.readFileSync(
  "./Desafio/Caso de teste 1/c1_produtos.txt",
  "utf8"
);
const productsArray = productsFile.split("\r\n");
const productsArrayResult = [];

productsArray.forEach((line, index) => {
  const [productCode, QtCO, QtMin] = line.split(";");
  productsArrayResult[index + 1] = { productCode, QtCO, QtMin };
  return productsArrayResult;
});

const sales = salesArrayResult;
const products = productsArrayResult;

const divergences = [];

for (const [line, sale] of Object.entries(sales)) {
  if (!products[sale.productCode]) {
    divergences.push();
  }
  if (sale.sellSituation === "135") {
    divergences.push(`Linha ${line} - Venda cancelada`);
  }
  if (sale.sellSituation === "190") {
    divergences.push(`Linha ${line} - Venda não finalizada`);
  }
  if (sale.sellSituation === "999") {
    divergences.push(
      `Linha ${line} - Erro desconhecido. Acionar equipe de TI.`
    );
  }
}

fs.writeFileSync("DIVERGENCIAS.TXT", divergences.join("\n"), "utf-8");
console.log(divergences);

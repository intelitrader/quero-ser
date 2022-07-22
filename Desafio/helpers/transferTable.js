const { table } = require('table');
const fs = require('fs/promises');
const parsedEntities = require('./parser');

// filtra vendas confirmadas
const confirmedSales = async (salesFile, productsFile) => {
  const { sales } = await parsedEntities(salesFile, productsFile);
  const confirmed = sales.filter((sale) => sale.situacao === '100' || sale.situacao === '102');
  return confirmed;
};

// itera sobre cada venda, somando o número de vendas relacionado a determinado produto,
// retorna um objeto onde a chave é o código do produto e o valor o numero de vendas
const totalSalesByProduct = async (salesFile, productsFile) => {
  const sales = await confirmedSales(salesFile, productsFile);
  const salesByProduct = {};
  sales.forEach((sale) => {
    salesByProduct[sale.produto] = (!salesByProduct[sale.produto])
      ? Number(sale.vendas)
      : salesByProduct[sale.produto] + Number(sale.vendas);
  });
  return salesByProduct;
};

// retorna um array de objetos, contedo suas informaçoes somado as vendas e o stock após vendas
const stockAfterSales = async (salesFile, productsFile) => {
  const sales = await totalSalesByProduct(salesFile, productsFile);
  const { products } = await parsedEntities(salesFile, productsFile);
  const stock = products.map((prod) => ({
    ...prod,
    qtVendas: sales[prod.produto],
    stockAfter: Number(prod.qtCO) - Number(sales[prod.produto]),
  }));
  return stock;
};

// retorna o array anterior, com informaçoes sobre a necessiade de transferencia e suas quantidades
const transfer = async (salesFile, productsFile) => {
  const sheet = await stockAfterSales(salesFile, productsFile);
  return sheet.map((item) => {
    const isNecessary = (Number(item.stockAfter) - Number(item.qtMin) < 0);
    const absNum = Math.abs(Number(item.stockAfter) - Number(item.qtMin));
    const value = (absNum < 10) ? 10 : absNum;
    return {
      ...item,
      necess: isNecessary ? absNum : 0,
      transf: isNecessary ? value : 0,
    };
  });
};

// configurações da lib table
const config = {
  header: {
    alignment: 'center',
    content: 'Necessidade de Transferência Armazém para CO',
  },
};

async function generateTransferTable(fileName, salesFile, productsFile) {
  const values = (await transfer(salesFile, productsFile)).map((prod) => Object.values(prod));
  const data = [['Produto', 'QtCO', 'QtMin', 'QtVendas', 'Estq.após Vendas', 'Necess', 'Transf. de ARrm p/ CO'], ...values];
  const out = table(data, config);
  await fs.writeFile(fileName, out, 'utf-8');
}

module.exports = generateTransferTable;

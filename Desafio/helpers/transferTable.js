const table = require('table').table;
const fs = require('fs/promises');
const parsedEntities = require('./parser');

const confirmedSales = async (salesFile, productsFile) => {
  const { sales } = await parsedEntities(salesFile, productsFile);
  // console.log("🚀 ~ file: index.js ~ line 37 ~ confirmedSales ~  sales",  sales.length)
  const confirmed = sales.filter((sale) => sale.situacao === '100' || sale.situacao === '102')
  // console.log("🚀 ~ file: index.js ~ line 39 ~ confirmedSales ~ confirmed", confirmed.length);
  return confirmed;
};

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

const stockAfterSales = async (salesFile, productsFile) => {
  const sales = await totalSalesByProduct(salesFile, productsFile);
  const { products } = await parsedEntities(salesFile, productsFile);
  const stock = products.map((prod, index) => {
    return {
      ...prod,
      qtVendas: sales[prod.produto],
      stockAfter: Number(prod.qtCO) - Number(sales[prod.produto]),
    }
  })
  return stock;
}

const transfer = async (salesFile, productsFile) => {
  const sheet = await stockAfterSales(salesFile, productsFile);
  return sheet.map((item) => {
    const isNecessary = (Number(item.stockAfter)- Number(item.qtMin) < 0);
    const absNum = Math.abs(Number(item.stockAfter)- Number(item.qtMin));
    const value = (absNum < 10) ? 10 : absNum;
    return {
      ...item,
      necess: isNecessary ? absNum : 0,
      transf: isNecessary ? value : 0,
    }
  })
};

async function generateTransferTable(fileName, salesFile, productsFile) {
  const values = (await transfer(salesFile, productsFile)).map((prod) => Object.values(prod));
  const data = [['Produto', 'QtCO', 'QtMin', 'QtVendas', 'Estq.após Vendas', 'Necess', 'Transf. de ARrm p/ CO'], ...values];
  const out = table(data);
  console.log('entrouu')
  await fs.writeFile(fileName, out, 'utf-8');
}

module.exports = generateTransferTable;
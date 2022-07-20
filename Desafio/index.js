const table = require('table').table;
const fs = require('fs/promises');

const readFile = async (file) => {
  const content = await fs.readFile(file, { encoding: "utf-8"})
  return content;
}
const productSerialize = (product) => {
  const key = product.split(';');
  return {
    'produto': key[0],
    'qtCO': key[1],
    'qtMin': key[2],
  };
};
const parseTxt = async (file, serializer) => {
  const txt = await readFile(file);
  const array = txt.split('\n').map(serializer);
  return array
};

const salesSerialize = (product) => {
  const key = product.split(';');
  return {
    'produto': key[0],
    'vendas': key[1],
    'situacao': key[2],
    'canal': key[3],
  };
};
const parsedEntities =  async (salesFile, productsFile) => ({
  products: await parseTxt(productsFile, productSerialize),
  sales: await parseTxt(salesFile, salesSerialize)
});

const confirmedSales = async (salesFile, productsFile) => {
  const { sales } = await parsedEntities(salesFile, productsFile);
  // console.log("🚀 ~ file: index.js ~ line 37 ~ confirmedSales ~  sales",  sales.length)
  const confirmed = sales.filter((sale) => sale.situacao === '100' ||sale.situacao === '102')
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
  // console.log("🚀 ~ file: index.js ~ line 56 ~ stockAfterSales ~ sales", sales);
  const { products } = await parsedEntities(salesFile, productsFile);
  const stock = products.map((prod, index) => {
    return {
      ...prod,
      qtVendas: sales[prod.produto],
      stockAfter: Number(prod.qtCO) - Number(sales[prod.produto]),
    }
  })
  return stock;
  // console.log("🚀 ~ file: index.js ~ line 65 ~ stock ~ stock", stock)
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
  await fs.writeFile(fileName, out, 'utf-8')
}
generateTransferTable(__dirname + '/resultados/c1_transfere.txt', 'Desafio/Caso de teste 1/c1_vendas.txt', 'Desafio/Caso de teste 1/c1_produtos.txt');
generateTransferTable(__dirname + '/resultados/c2_transfere.txt', 'Desafio/Caso de teste 2/c2_vendas.txt', 'Desafio/Caso de teste 2/c2_produtos.txt');


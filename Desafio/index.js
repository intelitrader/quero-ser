const fs = require('fs/promises');

const readFile = async (file) => {
  const content = await fs.readFile(file, { encoding: 'utf-8'})
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
const parsedEntities =  async () => ({
  products: await parseTxt('Desafio/Caso de teste 1/c1_produtos.txt', productSerialize),
  sales: await parseTxt('Desafio/Caso de teste 1/c1_vendas.txt', salesSerialize)
});

const confirmedSales = async () => {
  const { sales } = await parsedEntities();
  // console.log("🚀 ~ file: index.js ~ line 37 ~ confirmedSales ~  sales",  sales.length)
  const confirmed = sales.filter((sale) => sale.situacao === '100' ||sale.situacao === '102')
  // console.log("🚀 ~ file: index.js ~ line 39 ~ confirmedSales ~ confirmed", confirmed.length);
  return confirmed;
};

const totalSalesByProduct = async () => {
  const sales = await confirmedSales();
  console.log("🚀 ~ file: index.js ~ line 45 ~ totalSalesByProdutct ~ sales", sales);
  const salesByProduct = {};
  sales.forEach((sale) => {
    salesByProduct[sale.produto] = (!salesByProduct[sale.produto]) 
      ? Number(sale.vendas) 
      : salesByProduct[sale.produto] + Number(sale.vendas);
  });
  return salesByProduct.
}


totalSalesByProduct();
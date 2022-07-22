const fs = require('fs/promises');

const readFile = async (file) => {
  const content = await fs.readFile(file, { encoding: 'utf-8' });
  return content;
};

// retorna um array de ojetos
const parseTxt = async (file, serializer) => {
  const txt = await readFile(file);
  const array = txt.split('\n').map(serializer);
  return array;
};

// serializa os produtos no formato adequado
const productSerialize = (product) => {
  const key = product.split(';');
  return {
    produto: key[0],
    qtCO: key[1],
    qtMin: key[2],
  };
};

// serializa as vendas no formato adequado
const salesSerialize = (product) => {
  const key = product.split(';');
  return {
    produto: key[0],
    vendas: key[1],
    situacao: key[2],
    canal: key[3],
  };
};
// retorna os dados de vendas e produtos em um objeto;
const parsedEntities = async (salesFile, productsFile) => ({
  products: await parseTxt(productsFile, productSerialize),
  sales: await parseTxt(salesFile, salesSerialize),
});

module.exports = parsedEntities;

const { table } = require('table');
const fs = require('fs/promises');
const parsedEntities = require('./parser');

const divergeType = {
  135: 'Venda cancelada',
  190: 'Venda não finalizada',
  999: 'Erro desconhecido. Acionar equipe de TI',
};
//
const divergeMessage = (array) => array.map((item) => ({
  line: `Linha ${item.line}`,
  message: divergeType[item.situacao],
}));

const divergeSales = async (salesFile, productsFile) => {
  const { sales, products } = await parsedEntities(salesFile, productsFile);
  const salesWithLine = sales.map((sale, i) => ({ line: i + 1, ...sale }));
  const productCodes = products.map((prod) => prod.produto);

  const productNotFound = salesWithLine.filter((sale) => !(productCodes.includes(sale.produto)))
    .map((item) => ({
      line: `Linha ${item.line}`,
      message: `Código de Produto não encontrado ${item.produto}`,
    }));

  const filteredByCode = salesWithLine
    .filter((sale) => (sale.situacao === '135'
      || sale.situacao === '999'
      || sale.situacao === '190'));
  const list = divergeMessage(filteredByCode);
  const diverged = [...list, ...productNotFound];
  return diverged.sort((a, b) => a.line.length - b.line.length);
};

const generateDivergeTable = async (fileName, salesFile, productsFile) => {
  const array = (await divergeSales(salesFile, productsFile)).map((prod) => Object.values(prod));
  const out = table(array);
  await fs.writeFile(fileName, out, 'utf-8');
};

module.exports = generateDivergeTable;

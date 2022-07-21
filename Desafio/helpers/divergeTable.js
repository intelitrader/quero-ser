const parsedEntities = require("./parser");
const table = require('table').table;
const fs = require('fs/promises');

const divergeType = {
  '135': 'Venda cancelada',
  '190': 'Venda não finalizada',
  '999': 'Erro desconhecido. Acionar equipe de TI'
};
const divergeCode = (array) => {
  return array.map((item) => {
    return {
      line: `Linha ${item.line}`,
      message: divergeType[item.situacao]
    };
  });
};

const divergeSales = async (salesFile, productsFile) => {
  const { sales, products } = await parsedEntities(salesFile, productsFile);
  const salesWhLine = sales.map((sale, i) => {
    return { line: i + 1 , ...sale }
  });
  const productCodes = products.map((prod) => {
    return prod.produto;
  });
  const productNotFound = salesWhLine.filter((sale) => {
    return !(productCodes.includes(sale.produto))
  })
    .map((item) => {
    return {
      line: `Linha ${item.line}`,
      message: `Código de Produto não encontrado ${item.produto}`
    }
  });
  const divergeByCode = salesWhLine
    .filter((sale) => (sale.situacao === '135' 
      || sale.situacao === '999' 
      || sale.situacao === '190'));
  const divergedList = divergeCode(divergeByCode);
  const diverged = [...divergedList, ...productNotFound].sort((a, b) => a.line - b.line);
  return diverged;
};

const generateDivergeTable = async (fileName, salesFile, productsFile) => {
  const array = (await divergeSales(salesFile, productsFile)).map((prod) => Object.values(prod));
  const out = table(array);
  await fs.writeFile(fileName, out, 'utf-8');
};



module.exports = generateDivergeTable;
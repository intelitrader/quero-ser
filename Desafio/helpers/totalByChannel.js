const { table } = require('table');
const fs = require('fs/promises');
const parsedEntities = require('./parser');

const channels = ['Representantes', 'Website', 'App móvel Android', 'App móvel iPhone'];

// filtra vendas confirmadas
const confirmedSales = async (salesFile, productsFile) => {
  const { sales } = await parsedEntities(salesFile, productsFile);
  const confirmed = sales.filter((sale) => sale.situacao === '100' || sale.situacao === '102');
  return confirmed;
};

// itera sobre cada canal e soma as vendas,
// retornando um array de objetos de informaçoes de cada canal
const totalByChannel = async (salesFile, productsFile) => {
  const sales = await confirmedSales(salesFile, productsFile);
  const salesByChannel = {};
  sales.forEach((sale) => {
    salesByChannel[sale.canal] = (!salesByChannel[sale.canal])
      ? Number(sale.vendas)
      : salesByChannel[sale.canal] + Number(sale.vendas);
  });
  return channels.map((item, index) => ({
    code: index + 1,
    channel: item,
    vendas: salesByChannel[index + 1],
  }));
};
// configurações da lib table
const config = {
  header: {
    alignment: 'center',
    content: 'Quantidade de Vendas por canal',
  },
};

const createTable = async (fileName, salesFile, productsFile) => {
  const data = (await totalByChannel(salesFile, productsFile))
    .map((prod) => Object.values(prod));
  const out = table(data, config);
  await fs.writeFile(fileName, out, 'utf-8');
};
module.exports = createTable;

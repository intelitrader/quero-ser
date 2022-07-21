const table = require('table').table;
const fs = require('fs/promises');
const parsedEntities = require('./parser');


const channels = ['Representantes', 'Website', 'App móvel Android', 'App móvel iPhone']
const confirmedSales = async (salesFile, productsFile) => {
  const { sales } = await parsedEntities(salesFile, productsFile);
  // console.log("🚀 ~ file: index.js ~ line 37 ~ confirmedSales ~  sales",  sales.length)
  const confirmed = sales.filter((sale) => sale.situacao === '100' || sale.situacao === '102')
  // console.log("🚀 ~ file: index.js ~ line 39 ~ confirmedSales ~ confirmed", confirmed.length);
  return confirmed;
};

const totalByChannel = async (salesFile, productsFile) => {
  const sales  = await confirmedSales(salesFile, productsFile);
  const salesByChannel = {};
  sales.forEach((sale) => {
    salesByChannel[sale.canal] = (!salesByChannel[sale.canal]) 
      ? Number(sale.vendas) 
      : salesByChannel[sale.canal] + Number(sale.vendas);
  });
  return channels.map((item, index) => {
    return {
      code: index + 1,
      channel: item,
      vendas: salesByChannel[index + 1]
    }
  });
};

const config = {
  header: {
    alignment: 'center',
    content: 'Quantidade de Vendas por canal',
  },
}
const createTable = async (fileName, salesFile, productsFile) => {
  const data = (await totalByChannel(salesFile, productsFile)).map((prod) => Object.values(prod));
  const out = table(data, config);
  await fs.writeFile(fileName, out, 'utf-8');
}
  

module.exports = createTable;
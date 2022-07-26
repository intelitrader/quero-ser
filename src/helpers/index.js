import { saveAs } from "file-saver";

const verifyCodes = (string, code, index) => {
  if(code === 135) string += `Linha ${index + 1} - Venda cancelada\n`;
  if(code === 190) string += `Linha ${index + 1} - Venda não finalizada\n`;
  if(code === 999) string += `Linha ${index + 1} - Erro desconhecido. Acionar equipe de TI\n`;
  return string;
}

const alignStrings = (string, space) => {
  let transformedString = string.toString();
  if(transformedString.length <= space) {
    for(let index = transformedString.length; index < space; index++){
      transformedString += ' ';
    }
  }
  return transformedString;
};

export const makeChannelsFile = (list) => {
  const saleList = channelRelatory(list)
  let channelString = `Quantidades de Vendas por canal\n\n`;
  console.log(saleList);
  saleList.map(({id, channel, totalSales}) => {
    channelString += `${id} - ${alignStrings(channel, 30)}${totalSales}\n`
  });
  return channelString;
};

export const makeTransferFile = (tableList) => {
  let saleFile = 'Necessidade de Transferência Armazém para CO\n\nProduto   QtCO   QtMin   QtVendas   Estq.após Vendas   Necess.     Transf. de Arm p/ CO\n';
  tableList.map(({ productCode, qtdCO, qtdMin, qtdSold, stock, nessToRepo, qtdToTransfer }) => {
    saleFile += `${productCode}     ${alignStrings(qtdCO, 6)}  ${alignStrings(qtdMin, 6)}   ${alignStrings(qtdSold, 6)}      ${alignStrings(stock, 6)}              ${alignStrings(nessToRepo, 6)}       ${alignStrings(qtdToTransfer, 6)}\n`;
  });
  return saleFile;
};

const channelRelatory = (saleList) => {
  const relatories = [
    {
      id: 1, 
      channel: 'Representantes', 
      totalSales: saleList.filter((sale) => sale.sellChannel === '1')
        .reduce((acc, curr) => {return acc + Number(curr.qtdSold)}, 0)
  },
  {
      id: 2, 
      channel: 'Website', 
      totalSales: saleList.filter((sale) => sale.sellChannel === '2')
        .reduce((acc, curr) => {return acc + Number(curr.qtdSold)}, 0)
  },
  {
      id: 3, 
      channel: 'Aplicativo móvel Android', 
      totalSales: saleList.filter((sale) => sale.sellChannel === '3')
        .reduce((acc, curr) => {return acc + Number(curr.qtdSold)}, 0)
  },
  {
      id: 4, 
      channel: 'Aplicativo móvel iPhone', 
      totalSales: saleList.filter((sale) => sale.sellChannel === '4')
        .reduce((acc, curr) => {return acc + Number(curr.qtdSold)}, 0)
  }
  ];
  return relatories;
}

const makeTable = (saleList, setFiltredSales, productList) => {
  let tableList = [];
  productList.forEach((item) => {
    const qtdSales = saleList.filter(({ productCode }) => productCode === item.productCode).reduce((acc, curr) => { 
      return acc + Number(curr.qtdSold);
    }, 0);
    const qtdNess = item.qtdToStayInStock - (item.qtdInStock - qtdSales);
    const qtdToRepo = qtdNess > 0 ? qtdNess : 0;
    const listObj = {
      productCode: item.productCode, 
      qtdCO: item.qtdInStock, 
      qtdMin: item.qtdToStayInStock, 
      qtdSold: qtdSales, 
      stock: item.qtdInStock - qtdSales, 
      nessToRepo: qtdToRepo, 
      qtdToTransfer: (qtdToRepo > 1 && qtdNess < 10) ? 10 : qtdToRepo
    }
    tableList.push(listObj);
  });
  setFiltredSales(tableList);
};

export function verifySales(salesTxtList, productCodeList, setDivergencyFile, setFiltredSales, productList) {
  const divergencyCodes = [135, 190, 999];
  let divergencyString = '';
  salesTxtList.forEach(({ productCode, salesCode }, index) => {
    if(!productCodeList.includes(productCode)) {
      divergencyString += `Linha ${index + 1} - Código de Produto não encontrado ${productCode}\n`;
      delete salesTxtList[index];
    };
    if(divergencyCodes.includes(Number(salesCode))) {
      divergencyString = verifyCodes(divergencyString, Number(salesCode), index);
      delete salesTxtList[index];
    };
  });
  setDivergencyFile(divergencyString);
  const newArray = salesTxtList.filter((item) => item !== null);
  makeTable(newArray, setFiltredSales, productList);
};

export function downloadFile(fileContent, title) {
  let blob = new Blob([fileContent],
    {
      type: 'text/plain;charset=utf-8'
    });
  saveAs(blob, `${title}.txt`)
};

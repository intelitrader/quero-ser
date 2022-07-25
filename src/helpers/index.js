import { saveAs } from "file-saver";

const verifyCodes = (string, code, index) => {
  if(code === 135) string += `Linha ${index + 1} - Venda cancelada\n`;
  if(code === 190) string += `Linha ${index + 1} - Venda não finalizada\n`;
  if(code === 999) string += `Linha ${index + 1} - Erro desconhecido. Acionar equipe de TI\n`;
  return string;
}

const makeTable = (saleList, setFiltredSales, productList) => {
  let tableList = [];
  productList.forEach((item) => {
    const qtdSales = saleList.filter(({ productCode }) => productCode === item.productCode).reduce((acc, curr) => { 
      return acc + Number(curr.qtdSold);
    }, 0);
    const qtdNess = item.qtdToStayInStock - (item.qtdInStock - qtdSales);
    console.log(qtdNess);
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
}

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

export const makeSalesFile = (tableList) => {
  let saleFile = 'Produto	  QtCO	  QtMin  	QtVendas	  Estq.após Vendas Necess.   Transf. de Vendas Arm p/ CO\n';
  tableList.forEach(({ productCode, qtdCO, qtdMin, qtdSold, stock, nessToRepo, qtdToTransfer }) => {
    saleFile += `${productCode}   ${qtdCO}   ${qtdMin}  ${qtdSold}   ${stock}   ${nessToRepo}   ${qtdToTransfer}\n`
  });
  console.log(saleFile);
};

export function downloadFile(fileContent, title) {
  let blob = new Blob([fileContent],
    {
      type: 'text/plain;charset=utf-8'
    });
  saveAs(blob, `${title}.txt`)
};

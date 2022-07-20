import { table } from "table";
import { productsData, salesData } from "./app.js";
import { config, writeFileTxt } from "./utils.js";

export const transfereWriterFile = (filename) => {
  const regexSemiColon = /\s*;\s*/;
  const productWithAllFiedsFilled = addOnProductsListArray(
    productsData.map((prod) => prod.split(regexSemiColon)),
    regexSemiColon
  );
  const data = outputHeaderData(
    [
      "Produto",
      "QtCO",
      "QtMin",
      "QtVendas",
      "Estq. após vendas",
      "Necess",
      "Transf. de Arm p/ CO",
    ],
    productWithAllFiedsFilled
  );

  const configTable = config(
    "norc",
    { paddingLeft: 0, width: 10, alignment: "center" },
    {
      alignment: "left",
      paddingLeft: 0,
      content: "Necessidade de Transferência Armazém para CO",
    }
  );
  const output = {
    tableInfo: table(data, configTable),
    message: "The TRANSFERE.TXT file was saved!",
  };
  writeFileTxt(filename, output);
};

const outputHeaderData = (columns, row) => [[...columns], ...row];

const stockAfterSale = (qtCO, qtSales) => qtCO - qtSales;

const isNeedToReplenishStock = (qtCO, qtMin, qtSales, stockAfterSales) =>
  qtCO - qtSales < qtMin ? qtMin - stockAfterSales : 0;

const isNeedTransferFromTheWarehouseToTheCO = (necessTransference) =>
  necessTransference > 1 && necessTransference < 10 ? 10 : necessTransference;

const sumAllProductsConfirmedSales = (regexSemiColon) => {
  const allSalesConfirmed = salesData.filter(
    (prodSale) => prodSale.includes("100") || prodSale.includes("102")
  );
  const productsCode = productsData.map(
    (item) => item.split(regexSemiColon)[0]
  );
  return productsCode.map((_item, index) =>
    allSalesConfirmed
      .filter((prod) => prod.split(regexSemiColon)[0] === productsCode[index])
      .map((prod) => parseInt(prod.split(regexSemiColon)[1]))
      .reduce((accumulator, item) => accumulator + item, 0)
  );
};

const addOnProductsListArray = (productListToBeAddedInfo, regexSemiColon) => {
  productListToBeAddedInfo.forEach((_prod, index) => {
    productListToBeAddedInfo[index].push(
      sumAllProductsConfirmedSales(regexSemiColon)[index]
    );
    productListToBeAddedInfo[index].push(
      stockAfterSale(
        parseInt(productListToBeAddedInfo[index][1]),
        parseInt(productListToBeAddedInfo[index][3])
      )
    );
    productListToBeAddedInfo[index].push(
      isNeedToReplenishStock(
        parseInt(productListToBeAddedInfo[index][1]),
        parseInt(productListToBeAddedInfo[index][2]),
        parseInt(productListToBeAddedInfo[index][3]),
        parseInt(productListToBeAddedInfo[index][4])
      )
    );
    productListToBeAddedInfo[index].push(
      isNeedTransferFromTheWarehouseToTheCO(
        parseInt(productListToBeAddedInfo[index][5])
      )
    );
  });
  return productListToBeAddedInfo;
};

import { table } from "table";
import { salesData, productsData } from "./app.js";
import { config, writeFileTxt } from "./utils.js";

export const divergencesWriterFile = (filename) => {
  const regexSemiColon = /\s*;\s*/;
  const productsID = productsData.map((item) =>
    parseInt(item.split(regexSemiColon)[0])
  );

  const salesID = salesData.map((item) =>
    parseInt(item.split(regexSemiColon)[0])
  );
  const codeNotFounded = noProductCodeSimilarOnSales(salesID, productsID);
  const saleSituationCode135 = saleSituationByIdCode("135");
  const saleSituationCode190 = saleSituationByIdCode("190");
  const saleSituationCode999 = saleSituationByIdCode("999");

  const dataTable = [
    ...valuesForDataTable(saleSituationCode190),
    ...valuesForDataTable(saleSituationCode135),
    ...valuesForDataTable(saleSituationCode999),
    ...valuesForDataTable(codeNotFounded),
  ];

  const configTable = config("norc", { paddingLeft: 0, paddingRight: 1 });

  let output = {
    tableInfo: table(dataTable, configTable),
    message: "The DIVERGENCIAS.TXT file was saved!",
  };
  writeFileTxt(filename, output);
};

const valuesForDataTable = (arrayOfInfoForDataTable) => {
  const dataTableArrayValues = arrayOfInfoForDataTable.map(Object.values);
  dataTableArrayValues.forEach((item, index) => {
    dataTableArrayValues[index].push(
      `Linha ${item[0]} - ${item[1]} ${item[2] ? item[2] : ""}`
    );
    dataTableArrayValues[index] = dataTableArrayValues[index].slice(-1);
  });

  return dataTableArrayValues;
};

const noProductCodeSimilarOnSales = (salesId, productsId) => {
  const regexSemiColon = /\s*;\s*/;
  const salesOnArrayDataFormat = salesData.map((item) =>
    item.split(regexSemiColon)
  );
  const noCodeOnProductAndSaleArray = salesId.filter(
    (item) => !productsId.includes(item)
  );

  const info = [];
  salesOnArrayDataFormat.forEach((item, index) => {
    let isValue = item.some((itemSale) =>
      noCodeOnProductAndSaleArray
        .map((dataToString) => dataToString.toString())
        .includes(itemSale)
    );

    if (isValue) {
      info.push({
        line: index + 1,
        message: "Código de Produto não encontrado",
        dataCode: parseInt(item),
      });
    }
  });

  return info;
};

const saleSituationByIdCode = (situationCode) => {
  const regexSemiColon = /\s*;\s*/;
  const salesSituations = salesData.map(
    (item) => item.split(regexSemiColon)[2]
  );

  const situationsFiltered = salesSituations.filter(
    (situation) => situation === situationCode
  );

  let info = [];
  salesSituations.forEach((item, index) => {
    if (situationsFiltered.includes(item)) {
      info.push({ line: index + 1 });
    }
  });
  if (situationCode == "135")
    info.map((item) => (item.message = "Venda Cancelada"));
  if (situationCode === "190")
    info.map((item) => (item.message = "Venda não finalizada"));
  if (situationCode === "999")
    info.map(
      (item) => (item.message = "Erro desconhecido. Acionar equipe de TI")
    );

  return info;
};

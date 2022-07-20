import { table } from "table";
import { salesData } from "./app.js";
import { config, writeFileTxt } from "./utils.js";

export const totSalesPerChannelWriterFile = (filename) => {
  const regexSemiColon = /\s*;\s*/;
  const allProductSalesConfirmed = salesData.filter(
    (c) => c.includes("100") || c.includes("102")
  );
  const salesChannelOptions = [
    "Representantes",
    "Website",
    "App móvel Android",
    "App móvel iPhone",
  ];

  const sumTotalPerSalesChannel = (salesChannel) => {
    const sumTotal = allProductSalesConfirmed
      .map((b) => b.split(regexSemiColon))
      .filter((item) => parseInt(item[3]) === salesChannel)
      .map((item) => parseInt(item[1]))
      .reduce((acc, item) => acc + item, 0);

    return setSumPerChannelOptions(salesChannelOptions, salesChannel, sumTotal);
  };

  const dataTable = [
    ...salesChannelOptions.map((_element, index) =>
      sumTotalPerSalesChannel(++index)
    ),
  ];

  const configTable = config(
    "norc",
    { paddingLeft: 0, paddingRight: 10 },
    {
      alignment: "left",
      paddingLeft: 0,
      content: "Quantidades de Vendas por canal",
    }
  );

  let output = {
    tableInfo: table(dataTable, configTable),
    message: "The TOTCANAIS.TXT  file was saved!",
  };
  writeFileTxt(filename, output);
};

const setSumPerChannelOptions = (
  salesChannelType,
  salesChannel,
  sumPerChannel
) => {
  const arrayOfSalesPerChannelInfo = [];

  salesChannelType.forEach((item, index) => {
    if (salesChannel === ++index) {
      arrayOfSalesPerChannelInfo.push(
        `${index} -  ${item} ->   ${sumPerChannel}`
      );
    }
  });

  return arrayOfSalesPerChannelInfo;
};

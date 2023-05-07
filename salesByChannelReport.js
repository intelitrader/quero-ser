import fs from "node:fs"

const salesFile = fs.readFileSync(
  "./Desafio/Caso de teste 1/c1_vendas.txt",
  "utf-8"
);
const salesArray = salesFile.split("\r\n");

const filteredSalesArray = salesArray.filter((line) => {
  const [, , sellSituation, channel] = line.split(";");
  return sellSituation === "100" || sellSituation === "102";
});

const groupedSalesByChannel = filteredSalesArray.reduce((result, line) => {
  const [, QtSales, , channel] = line.split(";");
  if (!result[channel]) {
    result[channel] = 0;
  }
  result[channel] += Number(QtSales) || 0;
  return result;
}, {});

function getChannelName(channel) {
  switch (channel) {
    case '1':
      return "Representantes";
      
    case '2':
      return "Website";
      
    case '3':
      return "App móvel Android";
      
    case '4':
      return "App móvel iPhone";
      
    default:
      break
  }
}
const header = `Quantidades de Vendas por canal\n\n`
const output = Object.entries(groupedSalesByChannel)
  .map(([channel, qtSales], index) => {
    const channelName = getChannelName(channel);
    const rowNumber = index + 1;
    const paddedChannelName = channelName.padEnd(20);
    return `${rowNumber} - ${paddedChannelName} = ${qtSales}`;
  })
  .join("\n");

fs.writeFileSync("totcanais.txt", header + output, "utf-8");

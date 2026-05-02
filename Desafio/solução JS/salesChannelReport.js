import writeChannelReport from "./writeChannelReport.js"

const generateSalesChannelReport = (data) => {
  const { vendas } = data

  const vendasPorCanal = vendas.reduce((acc, venda) => {
    const { CanalVenda, QtVendas } = venda
    if (acc[CanalVenda]) {
      acc[CanalVenda] += parseInt(QtVendas)
    } else {
      acc[CanalVenda] = parseInt(QtVendas)
    }
    return acc
  }, {})

  const channelReportString =
    String.raw`Quantidades de Vendas por canal

1 -  Representantes         ${vendasPorCanal['1']}
2 -  WebSite                ${vendasPorCanal['2']}
3 -  App móvel Android      ${vendasPorCanal['3']}
4 -  App móvel iPhone       ${vendasPorCanal['4']}`;

  writeChannelReport(channelReportString)

  return data
}


export default generateSalesChannelReport
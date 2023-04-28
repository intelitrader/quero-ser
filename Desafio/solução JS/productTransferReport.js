import printTable from "./formatTable.js"
import writeTransferReport from "./writeTransferReport.js"

const getProductInfos = (data) => {
  const produtos = data.produtos
  const vendas = data.vendas

  const qtdVendas = vendas.reduce((acc, venda) => {
    const { Produto, QtVendas } = venda
    if (acc[Produto]) {
      acc[Produto] += parseInt(QtVendas)
    } else {
      acc[Produto] = parseInt(QtVendas)
    }
    return acc
  }, {})

  const estqAposVendas = (produto) => {
    const { Produto, QtCO } = produto
    const QtVendas = qtdVendas[Produto]
    return QtCO - QtVendas
  }

  const necess = (produto) => {
    const { QtMin } = produto
    const QtEstqAposVendas = estqAposVendas(produto)
    const Necess = QtMin - QtEstqAposVendas
    if (Necess > 0)
      return Necess
    else return 0
  }

  const necessTransf = (necess) => {
    if (necess > 0 && necess < 10)
      return 10
    else return necess
  }

  const transferReportData = [
    ['Produto', 'QtCO', 'QtMin', 'QtdVendas', 'EstqAposVendas', 'Necess', 'NecessTransf'],
    ...produtos.map(produto => {
      const { Produto, QtCO, QtMin } = produto
      return [Produto, QtCO, QtMin, qtdVendas[Produto], estqAposVendas(produto), necess(produto), necessTransf(necess(produto))];
    })
  ];

  const table = printTable(transferReportData);

  const transferReportString =
    String.raw`Necessidade de Transferência Armazém para CO
  ${table}`

  writeTransferReport(transferReportString)
  return data
}

export default getProductInfos
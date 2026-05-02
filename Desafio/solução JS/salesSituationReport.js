import saleSituationDivergencyReport from "./saleSituationDivergencyReport.js"
import verifyProductExists from "./verifyProductExists.js"

const salesSituationReport = (data) => {
  const produtos = data.produtos
  const vendas = data.vendas
  const vendasConfirmadas = []

  vendas.forEach((venda, index) => {
    const line = index + 1
    verifyProductExists(produtos, venda, line)
    const divergencyOnSale = saleSituationDivergencyReport(venda, line)
    if (!divergencyOnSale) {
      vendasConfirmadas.push(venda)
    }
  })
  return { produtos, vendas: vendasConfirmadas }
}

export default salesSituationReport
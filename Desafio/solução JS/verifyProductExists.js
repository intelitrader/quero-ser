import writeDivergency from "./writeDivergencyReport.js"

const verifyProductExists = (produtos, venda, line) => {
  const { Produto } = venda
  const produtoCadastrado = produtos.find((produto) => produto.Produto === Produto)
  if (!produtoCadastrado) {
    const text = `Linha ${line} - Código de Produto não encontrado ${Produto}`
    writeDivergency(text)
  }
  else return true
}

export default verifyProductExists
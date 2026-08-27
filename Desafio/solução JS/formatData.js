const formatData = (data) => {
  const produtos = data.produtos
  const vendas = data.vendas

  const produtosInfos = produtos.map((produto) => {
    const [Produto, QtCO, QtMin] = produto.split(';')
    return { Produto, QtCO, QtMin }
  })

  const vendasInfos = vendas.map((venda) => {
    if (venda === '') return
    const [Produto, QtVendas, Situacao, CanalVenda] = venda.split(';')
    return { Produto, QtVendas,  Situacao, CanalVenda }
  })

  return { produtos: produtosInfos, vendas: vendasInfos }
}

export default formatData
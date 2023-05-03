import criaDivergencia from "../criaArquivo/criaDivergencia.js";

export default function somaVendas(ArrayProdutos, ArrayVendas, cn) {
  const produtosVendidos = {};
  const divergencias = [];

  // inicia cada posição com 0
  ArrayProdutos.forEach((produto) => {
    produtosVendidos[produto.codigo] = 0;
  });

  // para saber a linha da divergencia
  let count = 0;

  ArrayVendas.forEach((venda) => {
    const codigoVenda = venda.codigoProduto;
    const quantidade = venda.quantidade;

    const vendaProduto = ArrayProdutos.find(
      (produto) => produto.codigo == codigoVenda
    );

    count++;

    // se caso o find nao retornar algo
    if (vendaProduto) {
      // chega a situacao da venda
      switch (venda.situacao) {
        case 100:
        case 102:
          produtosVendidos[codigoVenda] += quantidade;
          break;
        case 135:
          divergencias.push("Linha " + count + " - Venda cancelada");
          break;
        case 190:
          divergencias.push("Linha " + count + " - Venda não finalizada");
          break;
        default:
          divergencias.push(
            "Linha " + count + " - Erro desconhecido. Acionar equipe de TI"
          );
          break;
      }
    } else {
      if (!isNaN(venda.codigoProduto)) {
        // mostra a linha com o erro
        divergencias.push(
          "Linha " +
            count +
            " - Código de Produto não encontrado " +
            venda.codigoProduto
        );
      }
    }
  });

  criaDivergencia(divergencias, cn);

  return produtosVendidos;
}

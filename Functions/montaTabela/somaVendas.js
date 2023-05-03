import criaDivergencia from "../criaArquivo/criaDivergencia.js";

export default function somaVendas(ArrayProdutos, ArrayVendas, cn) {
  const produtosVendidos = {};
  const divergencias = [];

  // inicia cada posição com 0
  ArrayProdutos.forEach((produto) => {
    produtosVendidos[produto.codigo] = 0;
  });

  // para saber a linha da divergencia
  let contPagina = 0;

  ArrayVendas.forEach((venda) => {
    const codigoVenda = venda.codigoProduto;
    const quantidade = venda.quantidade;

    const vendaProduto = ArrayProdutos.find(
      (produto) => produto.codigo == codigoVenda
    );

    contPagina++;

    // essa condicao so existe para o arquivo de saida ficar igual ao exemplo
    // originalmente primeiro verifica se o codigo de produto existe e depois se a situacao e 999
    // dando o erro 'codigo inexistente' e nao 'erro nao identificado'
    if (venda.situacao !== 999) {
      // se caso o find nao retornar algo
      if (vendaProduto) {
        // chega a situacao da venda
        switch (venda.situacao) {
          case 100:
          case 102:
            produtosVendidos[codigoVenda] += quantidade;
            break;
          case 135:
            divergencias.push("Linha " + contPagina + " - Venda cancelada");
            break;
          case 190:
            divergencias.push(
              "Linha " + contPagina + " - Venda não finalizada"
            );
            break;
          default:
            divergencias.push(
              "Linha " +
                contPagina +
                " - Erro desconhecido. Acionar equipe de TI"
            );
            break;
        }
      } else {
        // linhas vazias no arquivo entrada de venda
        if (!isNaN(venda.codigoProduto)) {
          // mostra a linha com o erro
          divergencias.push(
            "Linha " +
              contPagina +
              " - Código de Produto não encontrado " +
              venda.codigoProduto
          );
        }
      }
    } else {
      divergencias.push(
        "Linha " + contPagina + " - Erro desconhecido. Acionar equipe de TI"
      );
    }
  });

  criaDivergencia(divergencias, cn);

  return produtosVendidos;
}

import montaProduto from "../Tratamento/montaProduto.js";
import montaVenda from "../Tratamento/montaVenda.js";

export default function montaTransfere() {
  const ArrayProdutos = montaProduto("./Entrada/c1_produtos.txt");
  const ArrayVendas = montaVenda("./Entrada/c1_vendas.txt");

  const produtosVendidos = {};

  // inicia cada posição com 0
  ArrayProdutos.forEach((produto) => {
    produtosVendidos[produto.codigo] = 0;
  });

  let count = 0;

  ArrayVendas.forEach((venda) => {
    const codigoVenda = parseInt(venda.codigoProduto, 10);
    const quantidade = parseInt(venda.quantidade, 10);

    const teste = ArrayProdutos.find(
      (produto) => produto.codigo == codigoVenda
    );

    count++;

    // se caso o .txt tiver alguma linha como undefined
    if (teste) {
      // chega a situacao da venda
      if (venda.situacao == 100 || venda.situacao == 120) {
        produtosVendidos[codigoVenda] += quantidade;
      }
    } else {
      console.log(teste);
      console.log(count);
    }
  });

//   console.log(produtosVendidos);
}

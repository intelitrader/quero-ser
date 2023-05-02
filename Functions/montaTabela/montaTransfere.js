import montaProduto from "../Tratamento/montaProduto.js";
import montaVenda from "../Tratamento/montaVenda.js";

function somaVendas(ArrayProdutos, ArrayVendas) {
  const produtosVendidos = {};

  // inicia cada posição com 0
  ArrayProdutos.forEach((produto) => {
    produtosVendidos[produto.codigo] = 0;
  });

  let count = 0;

  ArrayVendas.forEach((venda) => {
    const codigoVenda = venda.codigoProduto;
    const quantidade = venda.quantidade;

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
      // mostra a linha com o erro
      // console.log(teste);
      // console.log(count);
    }
  });

  //   console.log(produtosVendidos);
  return produtosVendidos;
}

export default function montaTransfere() {
  const ArrayProdutos = montaProduto("./Entrada/c2_produtos.txt");
  const ArrayVendas = montaVenda("./Entrada/c2_vendas.txt");

  const produtosVendidos = somaVendas(ArrayProdutos, ArrayVendas);
  //   console.log(vendidos);

  for (const total in produtosVendidos) {
    // index do produto que tem o codigo igual a posicao do array de vendas
    const busca = ArrayProdutos.findIndex((produto) => produto.codigo == total);
    // 0, 1, 2, 3...
    if (busca !== -1) {
      ArrayProdutos[busca].vendas = produtosVendidos[total];
    }

    const quantidade = ArrayProdutos[busca].quantidade;
    const quantidadeMinima = ArrayProdutos[busca].quantidadeMinima;

    // calculo para estoque apos vendas
    const estoqueAtual = quantidade - ArrayProdutos[busca].vendas;
    ArrayProdutos[busca].estoque = estoqueAtual;

    // se estoque atual for menor que o minimo
    if (estoqueAtual < quantidadeMinima) {
      const necessario = quantidadeMinima - estoqueAtual;
      ArrayProdutos[busca].necessidade = necessario;
      // se a necessidade estiver entre 1 e 10
      if (necessario > 1 && necessario < 10) {
        ArrayProdutos[busca].transferencia = 10;
      } else {
        ArrayProdutos[busca].transferencia = necessario;
      }
    } else {
      ArrayProdutos[busca].necessidade = 0;
      ArrayProdutos[busca].transferencia = 0;
    }
  }

  console.log(ArrayProdutos);

  const transfere = {
    Produto: ArrayProdutos[0].codigo,
    Quantidade: ArrayProdutos[0].quantidade,
    QuantidadeMinima: ArrayProdutos[0].quantidadeMinima,
    Vendas: ArrayProdutos[0].vendas,
    Estoque: ArrayProdutos[0].estoque,
    // Necessario: ArrayProdutos[0].necessario,
    // Transferencia: ArrayProdutos[0].transferencia
  };

  //   console.log(transfere);
}

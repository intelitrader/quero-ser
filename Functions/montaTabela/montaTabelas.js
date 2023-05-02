import montaProduto from "../Tratamento/montaProduto.js";
import montaVenda from "../Tratamento/montaVenda.js";
import criaRelatorio from "../criaArquivo/criaRelatorio.js";
import criaTransfere from "../criaArquivo/criaTransfere.js";

function somaVendas(ArrayProdutos, ArrayVendas, cn) {
  const produtosVendidos = {};

  const divergencias = [];

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
      if (venda.situacao == 100 || venda.situacao == 102) {
        produtosVendidos[codigoVenda] += quantidade;
      } else if (venda.situacao == 135) {
        divergencias.push("Linha " + count + " - Venda cancelada");
      } else if (venda.situacao == 190) {
        divergencias.push("Linha " + count + " - Venda não finalizada");
      } else {
        divergencias.push(
          "Linha " + count + " - Erro desconhecido. Acionar equipe de TI"
        );
      }
    } else {
      // mostra a linha com o erro
      divergencias.push(
        "Linha " +
          count +
          " - Código de Produto não encontrado " +
          venda.codigoProduto
      );
    }
  });

  criaRelatorio(divergencias, cn);

  return produtosVendidos;
}

export default function montaTabelas(cn) {
  const ArrayProdutos = montaProduto("./Entrada/" + cn + "_produtos.txt");
  const ArrayVendas = montaVenda("./Entrada/" + cn + "_vendas.txt");

  const produtosVendidos = somaVendas(ArrayProdutos, ArrayVendas, cn);
  //   console.log(vendidos);

  for (const codigoVendas in produtosVendidos) {
    // index do produto que tem o codigo igual a posicao do array de vendas
    const index = ArrayProdutos.findIndex(
      (produto) => produto.codigo == codigoVendas
    );
    // 0, 1, 2, 3...
    if (index !== -1) {
      ArrayProdutos[index].vendas = produtosVendidos[codigoVendas];
    }

    const quantidade = ArrayProdutos[index].quantidade;
    const quantidadeMinima = ArrayProdutos[index].quantidadeMinima;

    // calculo para estoque apos vendas
    const estoqueAtual = quantidade - ArrayProdutos[index].vendas;
    ArrayProdutos[index].estoque = estoqueAtual;

    // se estoque atual for menor que o minimo
    if (estoqueAtual < quantidadeMinima) {
      const necessario = quantidadeMinima - estoqueAtual;
      ArrayProdutos[index].necessidade = necessario;
      // se a necessidade estiver entre 1 e 10
      if (necessario > 1 && necessario < 10) {
        ArrayProdutos[index].transferencia = 10;
      } else {
        ArrayProdutos[index].transferencia = necessario;
      }
    } else {
      // se nao for menor, fica tudo 0
      ArrayProdutos[index].necessidade = 0;
      ArrayProdutos[index].transferencia = 0;
    }
  }

  // criaTransfere(ArrayProdutos, cn);
}

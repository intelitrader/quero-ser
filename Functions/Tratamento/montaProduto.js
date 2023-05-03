// import { produtosC1 } from "../Read/readProdutos";
import Produto from "../../Class/Produto.js";
import lerArquivo from "../lerArquivo/lerArquivo.js";

export default function montaProduto(url) {
  const rawProdutos = lerArquivo(url);

  const produtosTratados = rawProdutos.split("\r\n");

  const linhaProdutos = produtosTratados.map((produto) => {
    const [
      codigo,
      quantidade,
      quantidadeMinima
    ] = produto.split(";");
    return new Produto(
      parseInt(codigo, 10),
      parseInt(quantidade, 10),
      parseInt(quantidadeMinima, 10)
    );
  });

  // const linhaProdutos = [];

  // for (let i = 0; i < produtosTratados.length; i++) {
  //   const linha = [];
  //   linha[i] = produtosTratados[i].split(";");
  //   linhaProdutos[i] = new Produto(
  //     parseInt(dssdada, 10),
  //     parseInt(linha[i][1], 10),
  //     parseInt(linha[i][2], 10)
  //   );
  // }

  return linhaProdutos;
}

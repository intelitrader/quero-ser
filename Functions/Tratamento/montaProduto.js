// import { produtosC1 } from "../Read/readProdutos";
import Produto from "../../Class/Produto.js";
import readTxt from "../Read/readTxt.js";

export default function montaProduto(url) {
  const rawProdutos = readTxt(url);

  const produtosTratados = rawProdutos.split("\r\n");

  let linhaProdutos = [];

  for (let i = 0; i < produtosTratados.length; i++) {
    let linha = [];
    linha[i] = produtosTratados[i].split(";");
    linhaProdutos[i] = new Produto(
      parseInt(linha[i][0], 10),
      parseInt(linha[i][1], 10),
      parseInt(linha[i][2], 10)
    );
  }

  return linhaProdutos;
}

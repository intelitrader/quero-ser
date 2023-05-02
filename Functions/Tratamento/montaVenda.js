// import { produtosC1 } from "../Read/readProdutos";
import Venda from "../../Class/Venda.js";
import readTxt from "../Read/readTxt.js";

export default function montaVenda(url) {
  const rawVendas = readTxt(url);

  const vendasTratadas = rawVendas.split("\r\n");

  let linhaVendas = [];

  for (let i = 0; i < vendasTratadas.length; i++) {
    let linha = [];
    linha[i] = vendasTratadas[i].split(";");
    linhaVendas[i] = new Venda(
      parseInt(linha[i][0], 10),
      parseInt(linha[i][1], 10),
      parseInt(linha[i][2], 10),
      parseInt(linha[i][3], 10)
    );
  }

  return linhaVendas;
}

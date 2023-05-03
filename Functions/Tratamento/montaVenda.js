// import { produtosC1 } from "../Read/readProdutos";
import Venda from "../../Class/Venda.js";
import lerArquivo from "../lerArquivo/lerArquivo.js";

export default function montaVenda(url) {
  const rawVendas = lerArquivo(url);

  const vendasTratadas = rawVendas.split("\r\n");

  const linhaVendas = vendasTratadas.map((linha) => {
    const [codigo, quantidade, situacao, canal] = linha.split(";");
    return new Venda(
      parseInt(codigo, 10),
      parseInt(quantidade, 10),
      parseInt(situacao, 10),
      parseInt(canal, 10)
    );
  });

  return linhaVendas;
}

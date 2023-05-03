// import { produtosC1 } from "../Read/readProdutos";
import Canal from "../../Class/Canal.js";
import lerArquivo from "../lerArquivo/lerArquivo.js";

export default function montaCanal(url) {
  const rawCanal = lerArquivo(url);

  const canalTratadas = rawCanal.split("\r\n");

  const linhaCanal = canalTratadas.map((canal) => {
    const [codigo, quantidade, situacao, canal] = canal.split(";");
    return new Venda(
      parseInt(codigo, 10),
      parseInt(quantidade, 10)
    );
  });

  return linhaCanal;
}

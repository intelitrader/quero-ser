import fs from "fs";
import EasyTable from "easy-table";

export default function criaTransfere(transfere, cn) {
  var tabela = new EasyTable();

  transfere.forEach(function (dado) {
    tabela.cell("Produto", dado.codigo);
    tabela.cell("Quantidade Atual", dado.quantidade);
    tabela.cell("Quantidade Minima", dado.quantidadeMinima);
    tabela.cell("Vendas", dado.vendas);
    tabela.cell("Estoque", dado.estoque);
    tabela.cell("Necessidade", dado.necessidade);
    tabela.cell("Transferencia", dado.transferencia);
    tabela.newRow();
  });

  const tabelaTransfere = tabela.toString();

  fs.writeFileSync("./Saida/" + cn + "_transfere.txt", tabelaTransfere);
}

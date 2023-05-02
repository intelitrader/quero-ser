import fs from "fs";
import EasyTable from "easy-table";

export default function criaTransfere(transfere) {
  var t = new EasyTable();

  transfere.forEach(function (dado) {
    t.cell("Produto", dado.codigo);
    t.cell("Quantidade Atual", dado.quantidade);
    t.cell("Quantidade Minima", dado.quantidadeMinima);
    t.cell("Vendas", dado.vendas);
    t.cell("Estoque", dado.estoque);
    t.cell("Necessidade", dado.necessidade);
    t.cell("Transferencia", dado.transferencia);
    t.newRow();
  });

  console.log(t.toString());

  const tabelaTransfere = t.toString();

  fs.writeFileSync("./Saida/c1_Transfere.txt", tabelaTransfere);
}

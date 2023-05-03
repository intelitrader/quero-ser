import fs from "fs";
import EasyTable from "easy-table";

export default function criaDivergencia(divergencias, cn) {
  var tabela = new EasyTable();

  divergencias.forEach(function (dado) {
    tabela.cell("Divergências", dado);
    tabela.newRow();
  });

  const tabelaDivergencias = tabela.toString();

  fs.writeFileSync(
    "./Saida/" + cn + "/" + cn + "_divergencias.txt",
    tabelaDivergencias
  );
}

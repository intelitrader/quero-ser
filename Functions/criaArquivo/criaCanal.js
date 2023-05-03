import fs from "fs";
import EasyTable from "easy-table";

export default function criaCanal(Canal, cn) {
    var tabela = new EasyTable();

    Canal.forEach(function (canal) {
      tabela.cell("Canal", canal.nome);
      tabela.cell("Total", canal.total);
      tabela.newRow();
    });
  
    const tabelaCanais = tabela.toString();
  
    fs.writeFileSync("./Saida/"+ cn +"/" + cn + "_totcanal.txt", tabelaCanais);
}
class Divergencia{
  constructor(message){
    this.message = message
  }
}

const {produtos} = require('./arrayGenerator');
const {vendas} = require('./arrayGenerator');

let divergencias = []

for(let i = 0; i < vendas.length; i++){
  //Checagem se o erro for desconhecido

  if(vendas[i].sitVenda === 999){
    divergencias.push(new Divergencia('Linha ' + (i + 1) + ' - Erro desconhecido, acionar equipe de TI'))
    continue;
  }

  //Checagem se a venda for cancelada

  if(vendas[i].sitVenda === 135){
    divergencias.push(new Divergencia('Linha ' + (i + 1) + ' - Venda cancelada'))
    continue;
  }

  //Checagem se a venda não foi finalizada

  if(vendas[i].sitVenda === 190){
    divergencias.push(new Divergencia('Linha ' + (i + 1) + ' - Venda não finalizada'));
    continue;
  }
  //Checagem de erro produto não encontrado
  let produtoExists = produtos.some(element => element.codProd === vendas[i].codProd);

  if(!produtoExists){
    divergencias.push(new Divergencia('Linha ' + (i + 1) + ' - Código de produto não encontrado ' + (vendas[i].codProd)));
    continue;
  }
}

module.exports.divergencias = divergencias;



const fs = require('fs');

class Produto {
  constructor(codProd, qtEstoque, qtMin){
    this.codProd = codProd,
    this.qtEstoque = qtEstoque,
    this.qtMin = qtMin
  }
}

class Venda {
  constructor(codProd, qtVendida, sitVenda, canalVenda){
    this.codProd = codProd,
    this.qtVendida = qtVendida,
    this.sitVenda = sitVenda,
    this.canalVenda = canalVenda
  }
}

let produtos = [];
let vendas = [];

let produtosArray = [];
let vendasArray = [];

//Recebendo as string dos arquivos txt de produtos e vendas

const dataProdutos = fs.readFileSync('txtFiles/produtos.txt', 'utf8');
const dataVendas = fs.readFileSync('txtFiles/vendas.txt', 'utf8');

//Transformando as strings em arrays

produtosArray = dataProdutos.replace(/[\r\n]/gm, ';').split(';');
vendasArray = dataVendas.replace(/[\r\n]/gm, ';').split(';');


produtosArray = produtosArray.filter(string => string.length > 0);
vendasArray = vendasArray.filter(string => string.length > 0);

//Transformando as strings dos arrays em numbers

produtosArray = produtosArray.map(string => (Number(string)));
vendasArray = vendasArray.map(string => (Number(string)));

let count = 0;

//Criando 2 arrays de objetos para armazenar as vendas e os produtos

for(let i = 0; i < produtosArray.length; i++){
  if(count == 2){
    produtos.push(new Produto(produtosArray[i - 2], produtosArray[i - 1], produtosArray[i]));
    count = -1;
  };
  count++;
}

count = 0;

for(let i = 0; i < vendasArray.length; i++){
  if(count == 3){
    vendas.push(new Venda(vendasArray[i - 3], vendasArray[i - 2], vendasArray[i - 1], vendasArray[i]));
    count = -1;
  };
  count++;
}

module.exports.vendas = vendas;
module.exports.produtos = produtos;
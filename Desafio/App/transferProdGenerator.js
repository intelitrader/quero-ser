class Transferido{
  constructor(codProd, qtCo, qtMin){
    this.codProd = codProd,
    this.qtCo = qtCo,
    this.qtMin = qtMin,
    this.qtVendida = 0,
    this.estoqPosVenda = 0,
    this.necessario = 0,
    this.transfArmazemPCo = 0
  }

  set adicionarVenda(nVenda){
    this.qtVendida += nVenda
  }

  set setterEstoquePosVenda(x){
    this.estoqPosVenda = this.qtCo - this.qtVendida
  }

  set setterNecessario(x){
    this.necessario = (this.qtMin > this.estoqPosVenda) ? (this.qtMin - this.estoqPosVenda) : 0
  }

  set setterTransfArmazemPCo(x){
    this.transfArmazemPCo = (this.necessario > 1) && (this.necessario < 10) ? 10 : this.necessario
  }
}

const {produtos} = require('./arrayGenerator');
const {vendas} = require('./arrayGenerator');

transferArray = [];

for(let i = 0; i < vendas.length; i++){

  //Checagem se a venda está confirmada
  if(vendas[i].sitVenda >= 100 && vendas[i].sitVenda <= 102){
    let produtoExists = produtos.some(element => element.codProd === vendas[i].codProd);

    //Checagem se o produto existe na lista de produtos e na lista de vendas
    if(produtoExists){
      let transferenciaExists = transferArray.some(element => element.codProd === vendas[i].codProd);
      //Checagem se o produto existe no array de transferencia
      if(transferenciaExists){
        continue;
      }else{
        //Criação do produto na lista de transferencias caso o mesmo não exista
        let produto = produtos.find(element => element.codProd === vendas[i].codProd);
        transferArray.push(new Transferido(produto.codProd, produto.qtEstoque, produto.qtMin));
      }
    }
  };
}

//for para adicionar as vendas nos objetos da lista de transferencias

for(let i = 0; i < transferArray.length; i++){

  for(let j = 0; j < vendas.length; j++){
    if(vendas[j].codProd === transferArray[i].codProd && vendas[j].sitVenda >= 100 && vendas[j].sitVenda <= 102){
      transferArray[i].adicionarVenda = vendas[j].qtVendida
    }
  }
}

//for para adicionar as propriedades restantes nos objetos da lista transferencia

for(let i = 0; i < transferArray.length; i++){
  transferArray[i].setterEstoquePosVenda = 0;
  transferArray[i].setterNecessario = 0;
  transferArray[i].setterTransfArmazemPCo = 0;
}

module.exports.transferArray = transferArray;











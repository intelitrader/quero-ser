const {produtos} = require('./arrayGenerator');
const {vendas} = require('./arrayGenerator');

let representante = 0;
let website = 0;
let appAndroid = 0;
let appIphone = 0;

for(let i = 0; i < vendas.length; i++){
  if(vendas[i].sitVenda === 100 || vendas[i].sitVenda === 102){
    let n = vendas[i].qtVendida
    switch (vendas[i].canalVenda){
      case 1:
        representante += n;
        break;
      case 2:
        website += n;
        break;
      case 3:
        appAndroid += n;
        break;
      case 4:
        appIphone += n;
        break;
      default:
        console.log('Codigo de canal de venda não encontrado')
  }
  }
  
}

let totalCanal = [representante, website, appAndroid, appIphone];

module.exports.totalCanal = totalCanal;
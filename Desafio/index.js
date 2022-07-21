const divergeTable = require('./helpers/divergeTable');
const totalSalesByProduct = require('./helpers/totalByChannel');
const generateTransferTable = require('./helpers/transferTable');

const caso1Dir = {
  vendas:'Caso de teste 1/c1_vendas.txt',
  produtos: 'Caso de teste 1/c1_produtos.txt'
};

const caso2Dir = {
  vendas:'Caso de teste 2/c2_vendas.txt',
  produtos: 'Caso de teste 2/c2_produtos.txt'
};
//caso 1
generateTransferTable(__dirname + '/resultados/c1_transfere.txt', caso1Dir.vendas, caso1Dir.produtos);
divergeTable(__dirname + '/resultados/c1_divergencias.txt', caso1Dir.vendas, caso1Dir.produtos);
totalSalesByProduct(__dirname + '/resultados/c1_totcanal.txt', caso1Dir.vendas, caso1Dir.produtos);

//caso 2
generateTransferTable(__dirname + '/resultados/c2_transfere.txt', caso2Dir.vendas, caso2Dir.produtos);
divergeTable(__dirname + '/resultados/c2_divergencias.txt', caso2Dir.vendas, caso2Dir.produtos);
totalSalesByProduct(__dirname + '/resultados/c2_totcanal.txt', caso2Dir.vendas, caso2Dir.produtos);


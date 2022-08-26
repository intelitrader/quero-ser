'use strict';
const Helper = require('./controllers/helper.js');
const Relatorio = require('./controllers/relatorio.js');

//se não for possível encontrar os 2 argumentos passados na inicialização
//mostrar informações de como usar o programa
if(process.argv.slice(2).length != 2){
    console.log('\nModo de usar: node EstoqueOperacional.js <arquivo vendas> <arquivo produtos>');
    console.log('Exemplo 1: node EstoqueOperacional.js "..\\dados\\c1_vendas.txt" "..\\dados\\c1_produtos.txt"');
    console.log('Exemplo 2: node EstoqueOperacional.js "C:\\users\\intelitrader\\dados\\c1_vendas.txt" "C:\\users\\intelitrader\\dados\\c1_produtos.txt"');
    process.exit(0);
}

//path para o primeiro argumento passado, arquivo de vendas
const vendasPath = process.argv.slice(2)[0];
//path para o segundo argumento passado, arquivo de produtos
const produtosPath = process.argv.slice(2)[1];

const helper = new Helper();
(async () => {
    //criando array vendas
    let vendas = await helper.vendasToArray(vendasPath, 'vendas');
    //criando objeto produtos
    let produtos = await helper.produtosToObj(produtosPath, 'produtos');

    //gera objeto vendasConfirmadas { codigo: {qtCO, qtMin, qtVendas, estoqueApos, necessario, armazemParaCO}, ... } 
    //gera array divergencias ['divergencia 1', 'divergencia 2', ...]
    const [vendasConfirmadas, divergencias] = helper.gerarRelatorioDeVendas(produtos, vendas);
    //gera objeto vendasPorCanal contendo a soma dos produtos vendidos por canala
    const vendasPorCanal = helper.gerarRelatorioDeVendasPorCanal(vendas);

    //escrevendo relatorios em txt
    const relatorio = new Relatorio();
    relatorio.writeTransfere(vendasConfirmadas);
    relatorio.writeDivergencias(divergencias);
    relatorio.writeTotCanais(vendasPorCanal);
})();

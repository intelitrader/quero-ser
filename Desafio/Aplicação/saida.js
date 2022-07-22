const fs = require('fs');

// // // Main

// extrai os dados da lista de produtos e formata
function relatorioTransf(lista) {
    let texto = `Necessidade de Transferência Armazém para CO
    
Produto     QtCO        QtMin       QtVendas        Estq.após       Necess.     Transf. de
                                                    Vendas                      Arm p/ CO
`
    
    lista.forEach(produto => {

        texto += `${space(produto.Codigo)}       ${space(produto.QtCO)}       ${space(produto.QtMin)}       ${space(produto.QtVendas)}           ${space(produto.EstqPosVendas)}           ${space(produto.Necess)}       ${space(produto.TransfArmParaCO)}
`
    });
    
    saida('transfere.txt', texto)
}

function relatorioDivergencias(lista) {
    let texto = ""
    
    lista.forEach(linha => {
        texto += `${linha}
`
    });
    
    saida('divergencias.txt', texto)
}

function relatorioCanais(lista) {
    let texto = `Quantidades de Vendas por canal

Canal                      QtVendas
1 - Representantes         ${lista.Representantes}
2 - Website                ${lista.Website}
3 - App móvel Android      ${lista.AppAndroid}
4 - App móvel iPhone       ${lista.AppIphone}
    `
    
    
    saida('totcanal.txt', texto)
}




// // // trechos

// salvar arquivo
function saida(arquivo, string) {
    fs.writeFileSync(arquivo, string);
}

// Ajuste de espaçamento para melhorar a legibilidade
function space(numero) {
    texto = String(numero)
    while (texto.length < 5) {
        texto = texto + " "
    }
    return texto
}



module.exports = { relatorioTransf, relatorioDivergencias, relatorioCanais }
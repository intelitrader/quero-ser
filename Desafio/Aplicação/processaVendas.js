const { leituraProdutos, leituraVendas } = require("./leitura.js");
const { relatorioTransf, relatorioDivergencias, relatorioCanais } = require("./saida.js");

const arquivos = process.argv.slice(2);
if (arquivos == 0) {
    console.log('Arquivos não especificados.');
    console.log('ex.: "../Caso de teste 1/c1_vendas.txt ../Caso\ de teste 1/vendas.txt" ');
    return
}

let vendasLista = leituraVendas(arquivos[0])
let produtosLista = leituraProdutos(arquivos[1])

let divergencias = []
let canais = {
    Representantes: 0,
    Website: 0,
    AppAndroid: 0,
    AppIphone: 0
}


// // // Main
main()
function main() {
    formataLista(produtosLista)

    // Trata dados de vendas e transfere para a lista produtos
    vendasLista.forEach((venda, index) => {
        let indexProduto = procuraProduto(venda.Codigo)
        if (!verificaCodigo(venda, index, indexProduto) || !verificaStatus(venda, index)) {
            return
        }
        produtosLista[indexProduto].QtVendas += venda.QtVendas
        verificaCanal(venda)
    })


    // Trata dados da lista produtos
    produtosLista.forEach(produto => {
        produto.EstqPosVendas = produto.QtCO - produto.QtVendas;

        // Cálculo de transferencia
        if (produto.EstqPosVendas < produto.QtMin) {
            produto.Necess = produto.QtMin - produto.EstqPosVendas
        }

        // Quantidade mínima de transferencia
        if (produto.Necess > 0 && produto.Necess < 10) {
            produto.TransfArmParaCO = 10
        }
        else if (produto.Necess > 10) {
            produto.TransfArmParaCO = produto.Necess;
        }
        else {
            produto.TransfArmParaCO = 0
        }
    })

    relatorioTransf(produtosLista)
    relatorioDivergencias(divergencias)
    relatorioCanais(canais)
    console.table(produtosLista);
    console.log(divergencias)
    console.log(canais);

}


// // // trechos

// Adiciona novos campos na lista
function formataLista(lista) {
    lista.forEach(produto => {
        produto.QtVendas = 0;
        produto.EstqPosVendas = 0;
        produto.Necess = 0;
        produto.TransfArmParaCO = 0;
    })
}

// Confere se o codigo de venda existe na lista produtos e retorna com o index
function procuraProduto(codigo) {
    let indexProduto = 'Produto não encontrado'
    produtosLista.forEach((produto, index) => {
        if (produto.Codigo == codigo) {
            indexProduto = index
        }
    })
    return indexProduto
}


// Verifica o tipo de código
function verificaCodigo(venda, index, indexProduto) {
    if (indexProduto == 'Produto não encontrado') {
        divergencias.push(`Linha ${index + 1} – Código de Produto não encontrado ${venda.Codigo}`)
        //console.log('Produto com erro de código -', index)
        return false
    }
    return true
}

// Verifica status da venda
function verificaStatus(venda, index) {
    if (venda.Status == 100 || venda.Status == 102) {
        return true
    }
    else if (venda.Status == 135) {
        divergencias.push(`Linha ${index + 1} – Venda cancelada`)
        return false
    }
    else if (venda.Status == 190) {
        divergencias.push(`Linha ${index + 1} – Venda não finalizada`)
        return false
    }
    else if (venda.Status == 999) {
        divergencias.push(`Linha ${index + 1} – Erro desconhecido. Acionar equipe de TI`)
        return false
    }
}

function verificaCanal(venda) {
    if (venda.Canal == 1) {
        canais.Representantes++
    }
    else if (venda.Canal == 2) {
        canais.Website++
    }
    else if (venda.Canal == 3) {
        canais.AppAndroid++
    }
    else if (venda.Canal == 4) {
        canais.AppIphone++
    }
}


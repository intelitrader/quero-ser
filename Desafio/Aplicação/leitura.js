// import {readFileSync, promises as fsPromises} from 'fs';
const { readFileSync, promises: fsPromises } = require('fs');

// // // Main

// lê e formata dados do arquivo de produtos
function leituraProdutos(caminho) {
    // guardando retorno da leitura em uma var
    let arquivoLido = leituraArquivo(caminho);
    
    let produtosLista = []
    // tratando linha a linha
    arquivoLido.forEach(linha => {
        if (linha == '') {
            return
        }

        let linhaOriginal = linha.split(';')
        let linhaTratada = {
            Codigo: Number(linhaOriginal[0]),   //  Código do produto
            QtCO: Number(linhaOriginal[1]),     //  Quantidade em estoque no centro operacional 
            QtMin: Number(linhaOriginal[2]),    //  Quantidade mínima que deve ser mantida
        }
        produtosLista.push(linhaTratada)
    })
    

    return produtosLista

}


// lê e formata dados do arquivo de vendas
function leituraVendas(caminho) {
    let arquivoLido = leituraArquivo(caminho);
    
    let vendasLista = []
    // tratando linha a linha
    arquivoLido.forEach(linha => {
        if (linha == '') {
            return
        }

        let linhaOriginal = linha.split(';')
        let linhaTratada = {
            Codigo: Number(linhaOriginal[0]),   //  Código do produto
            QtVendas: Number(linhaOriginal[1]),     //  Quantidade em estoque no centro operacional 
            Status: Number(linhaOriginal[2]),    //  Quantidade mínima que deve ser mantida
            Canal: Number(linhaOriginal[3])
        }
        vendasLista.push(linhaTratada)
    })
    
    // obj dividido
    return vendasLista
}


// // // trechos

// leitura arquivo
function leituraArquivo(caminho) {
    const contents = readFileSync(caminho, 'utf-8');
    
    const arr = contents.split(/\r?\n/);
    
    return arr;
}

module.exports = { leituraProdutos, leituraVendas}
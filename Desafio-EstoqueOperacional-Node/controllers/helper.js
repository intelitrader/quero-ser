const fs = require('fs');
const readline = require('readline');

class Helper {

    /**
     * Transforma o arquivo vendas em um array:
     * @param {path} <string> -> caminho para o arquivo vendas.txt
     * @returns {array} -> [ {codigo<string>, qtVendas<int>, situacaoDaVenda<int>, canalDeVenda<int>}, ... ]
     */
    vendasToArray(path) {
        let result = [];
        return new Promise((resolve,reject) => {
            let fileStream = fs.createReadStream(path, 'utf8');
            const rl = readline.createInterface({
                input: fileStream,
                crlfDelay: Infinity
            });
            rl.on('line', function(line) {
                const [ codigoProduto, qtVendas, situacaoDaVenda, canalDeVenda ] = line.split(';');
                result.push({
                    'codigo': codigoProduto, 
                    'qtVendas': Number(qtVendas), 
                    'situacaoDaVenda': Number(situacaoDaVenda), 
                    'canalDeVenda': Number(canalDeVenda)
                });
            });
            rl.on('close', function() {
                resolve(result);
            });
            rl.on('error', function(err) {
                console.error("Arquivo não encontrado", err.path);
                process.exit(0);
            });
        });
    }

    /**
     * Transforma o arquivo produtos em um objeto:
     * @param {path} <string> -> caminho para o arquivo produtos.txt
     * @returns {object} ->  { codigo<string>: {qtCO<int>, qtMin<int>}, ... }
     */
    produtosToObj(path) {
        let result = {};
        return new Promise((resolve,reject) => {
            let fileStream = fs.createReadStream(path, 'utf8');
            const rl = readline.createInterface({
                input: fileStream,
                crlfDelay: Infinity
            });
            rl.on('line', function(line) {
                const [ codigoProduto, qtCO, qtMin ] = line.split(';');
                result[codigoProduto] = {
                    'qtCO': Number(qtCO), 
                    'qtMin': Number(qtMin)
                };
            });
            rl.on('close', function() {
                resolve(result);
            });
            rl.on('error', function(err) {
                console.error("Arquivo não encontrado", err.path);
                process.exit(0);
            });
        });
    }

    /**
     * Recebe um objeto produtos, e um array vendas. Verifica a situação de cada venda.
     * Se a situação da venda for 135, 190, 999, ou o produto não for encontrado,
     * adiciona uma divergencia em um array divergencias.
     * Caso contrário, soma todas as vendas de um mesmo produto, e o adiciona em um 
     * objeto vendasConfirmadas, apenas se ainda não existir o produto neste objeto, onde o
     * as chaves deste objeto são os códigos dos produtos, e seus valores, um objeto contendo
     * qtCO, qtMin, qtVendas, estoqueApos, necessario, armazemParaCO
     * @param {produtos} <object> -> objeto contendo os produtos no seguinte formato 
     *                               { codigo<string>: {qtCO<int>, qtMin<int>}, ... }
     * @param {vendas} <array> -> array contendo as vendas no seguinte formato
     *                            [ {codigo<string>, qtVendas<int>, situacaoDaVenda<int>, canalDeVenda<int>}, ... ]
     * @returns {array} [object, array] -> Retorna um array, no índice 0, o objeto vendasConfirmadas é adicionado.
     *                                     E no índice 1, o array divergencias é adicionado.
     */
    gerarRelatorioDeVendas(produtos, vendas){
        const vendasConfirmadas = {};
        const divergencias = [];
        for(let i = 0; i < vendas.length; i++){
            const codigo = vendas[i].codigo;
            const situacao = vendas[i].situacaoDaVenda;

            if([135, 190, 999].includes(situacao)){
                divergencias.push( this.escreverDivergencia(situacao, codigo, i) );
                continue;
            }
            if(produtos.hasOwnProperty(codigo)){
                if(!vendasConfirmadas.hasOwnProperty(codigo)){
                    let qtVendas = this.qtdVendasPorCodigo(codigo, vendas);
                    let estoqueApos = produtos[codigo].qtCO - qtVendas;
                    let necessario = estoqueApos >= produtos[codigo].qtMin ? 0 : produtos[codigo].qtMin - estoqueApos;
                    let armazemParaCO = necessario >= 1 && necessario <= 9 ? 10 : necessario;
                    vendasConfirmadas[codigo] = {
                        'qtCO': produtos[codigo].qtCO,
                        'qtMin': produtos[codigo].qtMin,
                        'qtVendas': qtVendas,
                        'estoqueApos': estoqueApos,
                        'necessario': necessario,
                        'armazemParaCO': armazemParaCO
                    }
                }
            } else {
                divergencias.push( this.escreverDivergencia(0, codigo, i) );
            }
        }
        return [vendasConfirmadas, divergencias];
    }

    /**
     * Gera um objeto onde as chaves são os códigos do canal de venda, e o valor é 
     * a quantidade de vendas de um canal, apenas se a situação da venda for código 100 ou 102.
     * @param {vendas} <array> -> array contendo as vendas no seguinte formato
     *                            [ {codigo<string>, qtVendas<int>, situacaoDaVenda<int>, canalDeVenda<int>}, ... ]
     * @returns {object} -> Retorna um objeto, com a quantidade de vendas por canal, onde cada chave do objeto
     *                      é o código do canal, e seu valor é quantidade de vendas em si. 
     *                      1 - Representantes | 2 - Website | 3 - App móvel Android | 4 - App móvel iPhone
     */
    gerarRelatorioDeVendasPorCanal(vendas){
        const vendasPorCanal = {'1': 0, '2': 0, '3': 0, '4': 0};
        for(let i = 0; i < vendas.length; i++){
            if(this.pagamentOk(vendas[i].situacaoDaVenda)){
                if(vendas[i].canalDeVenda === 1) vendasPorCanal['1'] += vendas[i].qtVendas;
                else if(vendas[i].canalDeVenda === 2) vendasPorCanal['2'] += vendas[i].qtVendas;
                else if(vendas[i].canalDeVenda === 3) vendasPorCanal['3'] += vendas[i].qtVendas;
                else if(vendas[i].canalDeVenda === 4) vendasPorCanal['4'] += vendas[i].qtVendas;
            }
        }
        return vendasPorCanal;
    }

    /**
     * Faz uma busca no array vendas, somando a quantidade de vendas de um produto com,
     * o mesmo código, apenas se a situação da venda for 100 ou 102, ou seja, ok.
     * @param {codigo} <string> -> String com o código do produto
     * @param {vendas} <array> -> array contendo as vendas no seguinte formato
     *                            [ {codigo<string>, qtVendas<int>, situacaoDaVenda<int>, canalDeVenda<int>}, ... ]
     * @returns {int} -> Retorna a quantidade de vendas com um mesmo código de produto.
     */
    qtdVendasPorCodigo(codigo, vendas){
        let qtTotal = 0;
        for(let i = 0; i < vendas.length; i++) {
            const qtVenda = vendas[i].qtVendas;
            const situacao = vendas[i].situacaoDaVenda;
            if(vendas[i].codigo === codigo){
                if(this.pagamentOk(situacao)) qtTotal += qtVenda;
            }
        }
        return qtTotal;
    }

    /**
     * Gera uma string de divergencia com o erro.
     * @param {situacao} <int> -> código de situação da venda
     * @param {codigo} <string> -> String com o código do produto
     * @param {indiceVenda} <int> -> O índice da venda no array vendas.
     * @returns {int} -> Retorna uma string com o erro.
     */
    escreverDivergencia(situacao, codigo, indiceVenda){
        switch(situacao){
            case 0:
                return `Linha ${indiceVenda+1} – Código de Produto não encontrado ${codigo}`;
            case 135:
                return `Linha ${indiceVenda+1} – Venda cancelada`;
            case 190:
                return `Linha ${indiceVenda+1} – Venda não finalizada`;
            case 999:
                return `Linha ${indiceVenda+1} – Erro desconhecido. Acionar equipe de TI`;
        }
    }

    /**
     * Verifica se uma venda esta com situação de pagamento ok.
     * @param {situacao} <int> -> código de situação da venda
     * @returns {int} -> Retorna true se a venda estiver ok.
     */
    pagamentOk(situacao){
        if(situacao === 100 || situacao === 102) return true;
        return false;
    }

}

module.exports = Helper;
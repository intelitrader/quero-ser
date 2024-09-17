export function definirVendasConfirmadas(produtos, vendas){
    let listaVendas = vendas.filter(venda => venda.situacaoVenda === 100 || venda.situacaoVenda === 102);
    let lista = [];

    produtos.forEach(produto => {      
        let qtdVendas = (listaVendas.filter(x => x.codigoProduto === produto.codigoProduto))
                        .reduce((soma, atual) => { 
                            return soma + atual.qtdVendas;
                        }, 0);
        let calculoNecessidade = produto.qtdMinima - (produto.qtdEstoque - qtdVendas);
        let necessidadeRepo = calculoNecessidade < 0 ? 0 : calculoNecessidade;

        lista.push({
            produto: produto.codigoProduto, 
            qtdco: produto.qtdEstoque, 
            qtdMin: produto.qtdMinima, 
            qtdVendas: qtdVendas, 
            estoque: produto.qtdEstoque - qtdVendas, 
            necessidadeRepo: necessidadeRepo, 
            qtdTransferida: necessidadeRepo > 1 && necessidadeRepo < 10 ? 10 : necessidadeRepo
        });
    });

    return lista;
}

function checarCodigoProduto(produtos, venda){   
    for(var i = 0; i < produtos.length; i++){
        if(produtos[i].codigoProduto === venda.codigoProduto)
            return {codigo: 0, resposta: true};
    }

    return {codigo: venda.codigoProduto, resposta: false};
}

export function definirDivegencias(produtos, vendas){
    let lista = [];

    for(var i = 0; i < vendas.length; i++){
        let verificacaoCodigoProduto = checarCodigoProduto(produtos, vendas[i]);

        if(verificacaoCodigoProduto.resposta === false) 
            lista.push(`Linha ${i+1} - Código de Produto não encontrado ${verificacaoCodigoProduto.codigo}`);
        if(vendas[i].situacaoVenda === 135)
            lista.push(`Linha ${i+1} - Venda cancelada`);
        if(vendas[i].situacaoVenda === 190)
            lista.push(`Linha ${i+1} - Venda não finalizada`);
        if(vendas[i].situacaoVenda === 999)
            lista.push(`Linha ${i+1} - Erro desconhecido. Acionar equipe de TI`);
    }

    return lista;
}

export function definirRelatorioCanais(vendas){
    let listaVendas = vendas.filter(venda => venda.situacaoVenda === 100 || venda.situacaoVenda === 102);

    let relatorioCanais = [
        {
            id: 1, 
            canal: 'Representantes', 
            totalVendas: listaVendas.filter(venda => venda.canalVenda === 1)
                        .reduce((soma, atual) => {return soma + atual.qtdVendas}, 0)
        },
        {
            id: 2, 
            canal: 'Website', 
            totalVendas: listaVendas.filter(venda => venda.canalVenda === 2)
                        .reduce((soma, atual) => {return soma + atual.qtdVendas}, 0)
        },
        {
            id: 3, 
            canal: 'Aplicativo móvel Android', 
            totalVendas: listaVendas.filter(venda => venda.canalVenda === 3)
                        .reduce((soma, atual) => {return soma + atual.qtdVendas}, 0)
        },
        {
            id: 4, 
            canal: 'Aplicativo móvel iPhone', 
            totalVendas: listaVendas.filter(venda => venda.canalVenda === 4)
                        .reduce((soma, atual) => {return soma + atual.qtdVendas}, 0)
        }
    ];
    
    return relatorioCanais;
}

function ajustarString(string, tamanho){
    let novaString = string.toString();

    if(novaString.length <= tamanho){
        for(var i = novaString.length; i < tamanho; i++){
            novaString += ' ';
        }
    }

   return novaString;
}

export function gerarArquivoVendas(lista, btn){
    let conteudo = 'Necessidade de Transferência Armazém para CO\n\nProduto   QtCO   QtMin   QtVendas   Estq.após Vendas   Necess.     Transf. de Arm p/ CO\n';

    for(var i = 0; i < lista.length; i++){
        conteudo += `${lista[i].produto}     ${ajustarString(lista[i].qtdco, 5)}  ${ajustarString(lista[i].qtdMin, 5)}   ${ajustarString(lista[i].qtdVendas, 5)}      ${ajustarString(lista[i].estoque, 5)}              ${ajustarString(lista[i].necessidadeRepo, 5)}       ${ajustarString(lista[i].qtdTransferida, 5)}\n`;
    }

    btn.current.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(conteudo));
    btn.current.setAttribute('download', 'transfere.txt');
}

export function gerarArquivoDivergencias(lista, btn){
    let conteudo = '';

    for(var i = 0; i < lista.length; i++){
        conteudo += `${lista[i]}\n`
    }

    btn.current.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(conteudo));
    btn.current.setAttribute('download', 'divergencias.txt');
}

export function gerarArquivoRelatorio(lista, btn){
    let conteudo = `Quantidades de Vendas por canal\n\n${ajustarString("Canal", 34)}QtdVendas\n`;

    for(var i = 0; i < lista.length; i++){
        conteudo += `${lista[i].id} - ${ajustarString(lista[i].canal, 30)}${lista[i].totalVendas}\n`
    }

    btn.current.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(conteudo));
    btn.current.setAttribute('download', 'totcanais.txt');
}
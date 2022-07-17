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

    //console.log(lista);

    return lista;
}
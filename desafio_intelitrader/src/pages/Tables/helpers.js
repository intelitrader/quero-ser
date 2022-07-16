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
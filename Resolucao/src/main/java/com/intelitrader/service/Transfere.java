package com.intelitrader.service;

import com.intelitrader.entity.balanco.Balanco;
import com.intelitrader.entity.produto.Produto;
import com.intelitrader.entity.venda.Venda;
import com.intelitrader.repository.Write;
import com.intelitrader.valueObject.status.SituacaoVenda;

import java.util.Collection;
import java.util.stream.Collectors;

public class Transfere implements Processo{
    private Collection<Produto> produtos;
    private Collection<Venda> vendas;
    private Write<Balanco> repository;

    public Transfere(Collection<Produto> produtos, Collection<Venda> vendas, Write<Balanco> repository){
        this.produtos = produtos;
        this.vendas = vendas;
        this.repository = repository;
    }

    @Override
    public void processa(){
        Collection<Balanco> balancos = this.produtos.stream()
                .map(produto -> makeBalanco(produto))
                .collect(Collectors.toList());

        this.repository.saveAll(balancos);
    }

    private Balanco makeBalanco(Produto produto){
        Collection<Venda> vendasDoProduto = this.vendas
                .stream()
                .filter(venda -> venda.codigoProduto() == produto.codigo())
                .filter(venda -> (venda.situacao() == SituacaoVenda.CONFIRMADA) || (venda.situacao() == SituacaoVenda.CONFIRMADA_E_PAGA))
                .collect(Collectors.toList());

        return new Balanco(produto, vendasDoProduto);
    }
}

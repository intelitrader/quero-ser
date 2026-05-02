package com.intelitrader.service;

import com.intelitrader.entity.conflito.Conflito;
import com.intelitrader.entity.produto.Produto;
import com.intelitrader.entity.venda.Venda;
import com.intelitrader.repository.Write;
import com.intelitrader.valueObject.conflito.TipoConflito;
import com.intelitrader.valueObject.status.SituacaoVenda;

import java.util.*;

public class Divergencia implements Processo{
    private Collection<Produto> produtos;
    private List<Venda> vendas;
    private Write<Conflito> repository;
    private Map<Long, Produto> cache;

    public Divergencia(Collection<Produto> produtos, List<Venda> vendas, Write<Conflito> repository){
        this.produtos = produtos;
        this.vendas = vendas;
        this.repository = repository;
        this.cache = new HashMap<>();
    }

    @Override
    public void processa() {
        Collection<Conflito> conflitos = new ArrayList<>();

        for(int i = 0; i < this.vendas.size(); i++){
            Venda venda = this.vendas.get(i);

            Conflito conflito = verificaProduto(venda, i+1);
            if(conflito != null) conflitos.add(conflito);

            conflito = verificaStatus(venda, i+1);
            if(conflito != null) conflitos.add(conflito);
        }

        this.repository.saveAll(conflitos);
    }

    private Conflito verificaProduto(Venda venda, int linha){
        Produto produto = encontraProduto(venda.codigoProduto());

        if(produto == null){
            return new Conflito(linha, TipoConflito.CODIGO_NAO_ENCONTRADO.getTexto()
                    +" "
                    +String.valueOf(venda.codigoProduto())
            );
        }

        return null;
    }

    private Conflito verificaStatus(Venda venda, int linha){
        if(venda.situacao() == SituacaoVenda.CANCELADA)
            return new Conflito(linha, TipoConflito.VENDA_CANCELADA.getTexto());

        if(venda.situacao() == SituacaoVenda.NAO_FINALIZADA)
            return new Conflito(linha, TipoConflito.VENDA_NAO_FINALIZADA.getTexto());

        if(venda.situacao() == SituacaoVenda.ERRO_NAO_IDENTIFICADO)
            return new Conflito(linha, TipoConflito.ERRO_DESCONHECIDO.getTexto());

        return null;
    }

    private Produto encontraProduto(Long codigo){
        Produto produto = this.cache.get(codigo);
        if(null != produto)
            return produto;

        try{
            produto = this.produtos.stream()
                    .filter(p -> p.codigo() == codigo)
                    .findFirst()
                    .orElseThrow();

            this.cache.put(produto.codigo(), produto);
        }catch (NoSuchElementException e){
            produto = null;
        }

        return produto;
    }
}

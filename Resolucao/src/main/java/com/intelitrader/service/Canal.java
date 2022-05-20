package com.intelitrader.service;

import com.intelitrader.entity.canal.MetaCanal;
import com.intelitrader.entity.venda.Venda;
import com.intelitrader.repository.Write;
import com.intelitrader.valueObject.canal.CanalVenda;
import com.intelitrader.valueObject.status.SituacaoVenda;

import java.util.Arrays;
import java.util.Collection;
import java.util.List;
import java.util.stream.Collectors;

public class Canal implements Processo{
    private List<Venda> vendas;
    private Write<MetaCanal> repository;

    public Canal(List<Venda> vendas, Write<MetaCanal> repository){
        this.vendas = vendas;
        this.repository = repository;
    }

    @Override
    public void processa() {
        Collection<Venda> vendas = this.vendas.stream()
                .filter(venda -> venda.situacao() == SituacaoVenda.CONFIRMADA || venda.situacao() == SituacaoVenda.CONFIRMADA_E_PAGA)
                .collect(Collectors.toList());

        Collection<MetaCanal> infos = Arrays.stream(CanalVenda.values())
                .map(canal ->  extractInfo(canal, vendas))
                .collect(Collectors.toList());

        this.repository.saveAll(infos);
    }

    private MetaCanal extractInfo(CanalVenda canal, Collection<Venda> vendas){
        long total = vendas.stream()
                .filter(venda -> venda.canal() == canal)
                .map(Venda::quantidadeVendida)
                .reduce(0L, Long::sum);

        return new MetaCanal(canal, total);
    }
}

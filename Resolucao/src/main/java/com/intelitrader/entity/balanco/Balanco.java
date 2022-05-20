package com.intelitrader.entity.balanco;

import com.intelitrader.entity.produto.Produto;
import com.intelitrader.entity.venda.Venda;

import java.util.Collection;

public record Balanco(Produto produto,
                      Collection<Venda> vendas
) {
    public long totalVendido(){
        return vendas.stream()
                .map(Venda::quantidadeVendida)
                .reduce(0L, Long::sum);
    }

    public long estoqueRestante(){
        long totalVendido = totalVendido();
        return produto.quantidadeEstocada() - totalVendido;
    }

    public long necessidadeReposicao(){
        long quantidade = this.produto.quantidadeMinima() - estoqueRestante();
        return (quantidade < 0) ? 0 : quantidade;
    }

    public long quantidadeAhTransferir(){
        long quantidade = necessidadeReposicao();
        return quantidade > 1 && quantidade < 10? 10 : quantidade;
    }
}

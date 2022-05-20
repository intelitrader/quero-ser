package com.intelitrader.entity.balanco;

import com.intelitrader.entity.produto.Produto;
import com.intelitrader.entity.venda.Venda;
import com.intelitrader.valueObject.canal.CanalVenda;
import com.intelitrader.valueObject.status.SituacaoVenda;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.TestInstance;

import java.util.Collection;
import java.util.List;

@TestInstance(TestInstance.Lifecycle.PER_CLASS)
public class BalancoTest {
    private Balanco balanco;

    @BeforeAll
    public void iniciador(){
        Produto produto = new Produto(11111, 30, 15);
        Collection<Venda> vendas = List.of(
            new Venda(produto.codigo(), 3, SituacaoVenda.CONFIRMADA, CanalVenda.REPRESENTANTE_COMERCIAL),
            new Venda(produto.codigo(), 9, SituacaoVenda.CONFIRMADA_E_PAGA, CanalVenda.WEBSITE),
            new Venda(produto.codigo(), 4, SituacaoVenda.CONFIRMADA, CanalVenda.APLICATIVO_MOVEL_ANDROID),
            new Venda(produto.codigo(), 2, SituacaoVenda.CONFIRMADA_E_PAGA, CanalVenda.APLICATIVO_MOVEL_IPHONE)
        );

        this.balanco = new Balanco(produto, vendas);
    }

    @Test
    public void totalVendidoTest(){
        Assertions.assertEquals(18, balanco.totalVendido());
    }

    @Test
    public void estoqueRestanteTest(){
        Assertions.assertEquals(12, balanco.estoqueRestante());
    }

    @Test
    public void necessidadeReposicaoTest(){
        Assertions.assertEquals(3, balanco.necessidadeReposicao());
    }

    @Test
    public void quantidadeAhTranferirTest(){
        Assertions.assertEquals(10, balanco.quantidadeAhTransferir());
    }
}

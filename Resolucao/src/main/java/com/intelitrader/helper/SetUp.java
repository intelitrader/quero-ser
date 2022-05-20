package com.intelitrader.helper;

import com.intelitrader.entity.produto.Produto;
import com.intelitrader.entity.venda.Venda;
import com.intelitrader.repository.balanco.BalancoRepository;
import com.intelitrader.repository.canal.MetaCanalRepository;
import com.intelitrader.repository.conflito.ConflitoRepository;
import com.intelitrader.repository.produto.ProdutoRepository;
import com.intelitrader.repository.venda.VendaRepository;
import com.intelitrader.service.Canal;
import com.intelitrader.service.Divergencia;
import com.intelitrader.service.Pipeline;
import com.intelitrader.service.Transfere;

import java.io.IOException;
import java.util.Collection;
import java.util.List;

public class SetUp {
    public static Pipeline initializer(String produtoFile, String vendaFile) throws IOException {
        Collection<Produto> produtos = extractProdutos(produtoFile);
        List<Venda> vendas = extractVendas(vendaFile);

        return makePipeline(vendas, produtos);
    }

    private static Collection<Produto> extractProdutos(String produtoFile){
        ProdutoRepository produtoRepository = new ProdutoRepository(produtoFile);
        return produtoRepository.getAll();
    }

    private static List<Venda> extractVendas(String vendaFile){
        VendaRepository vendaRepository = new VendaRepository(vendaFile);
        return vendaRepository.getAll();
    }

    private static Pipeline makePipeline(List<Venda> vendas, Collection<Produto> produtos) throws IOException {
        Pipeline pipeline = new Pipeline();
        pipeline.addProcesso(new Canal(vendas, new MetaCanalRepository()));
        pipeline.addProcesso(new Divergencia(produtos, vendas, new ConflitoRepository()));
        pipeline.addProcesso(new Transfere(produtos, vendas, new BalancoRepository()));
        return pipeline;
    }
}

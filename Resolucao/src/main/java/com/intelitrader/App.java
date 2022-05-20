package com.intelitrader;

import com.intelitrader.helper.SetUp;
import com.intelitrader.repository.produto.ProdutoRepository;
import com.intelitrader.repository.venda.VendaRepository;
import com.intelitrader.service.Pipeline;

import java.io.IOException;

/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args ) throws IOException {
        Pipeline pipe = SetUp.initializer(args[0], args[1]);
        pipe.processa();
    }
}

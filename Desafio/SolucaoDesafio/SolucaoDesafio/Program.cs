using System;
using System.Collections.Generic;
using Desafio.Entidades;

namespace Desafio
{
    class Program
    {
        const string caminhoArquivoProduto = @"C:\Projects\quero-ser\Desafio\SolucaoDesafio\SolucaoDesafio\Arquivos\c1_produtos.txt";
        const string caminhoArquivoVendas = @"C:\Projects\quero-ser\Desafio\SolucaoDesafio\SolucaoDesafio\Arquivos\c1_vendas.txt";
        static void Main(string[] args)
        {
            ProdutoRepositorio respositorioProduto = new ProdutoRepositorio();
            List<Produto> listaDeProdutos = new List<Produto>();

            VendasRepositorio repositorioVendas = new VendasRepositorio();
            List<Vendas> listaDeVendas = new List<Vendas>();

            listaDeProdutos = respositorioProduto.Lista(caminhoArquivoProduto);
            listaDeVendas = repositorioVendas.Lista(caminhoArquivoVendas);

            Transfere transfere = new Transfere();
            transfere.ArquivoTransfere(listaDeProdutos, listaDeVendas);

            RelatorioDivergencias.ArquivoDivergencias(listaDeProdutos, listaDeVendas);

            RelatorioCanais relatorioVendas = new RelatorioCanais();
            relatorioVendas.ArquivoTotCanais(listaDeVendas);
        }
    }
}

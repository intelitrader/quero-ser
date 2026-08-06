using DesafioIntelitrader.Enums;
using DesafioIntelitrader.Models;
using DesafioIntelitrader.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DesafioIntelitrader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pathBase = System.IO.Path.GetFullPath(@"..\..\..\");


            var produtos = CarregaProdutos(pathBase);
            var vendas   = CarregaVendas(pathBase, produtos);
            
            var vendasConfirmadas = RelatoriosService.Relatorio01_VendasConfirmadas(produtos, vendas);
            var vendasDivergentes = RelatoriosService.Relatorio02_Divergencias(vendas);
            var totalCanais       = RelatoriosService.Relatorio03_QtVendasPorCanal(vendas);

            ExportService.ExportarTXTVendasConfirmadas(pathBase, vendasConfirmadas);
            ExportService.ExportarTXTVendasDivergentes(pathBase, vendasDivergentes);
            ExportService.ExportarTXTVendaTotalCanais(pathBase, totalCanais);
        }
        
        private static List<Produto> CarregaProdutos(string path)
        {
            string pathArquivoProdutos = System.IO.Path.Combine(path, "arquivos\\c1_produtos.txt");
            List<Produto> produtos = new List<Produto>();

            string[] txtProdutos = System.IO.File.ReadAllLines(pathArquivoProdutos);
            foreach (string line in txtProdutos)
            {
                var produto = new Produto();
                var colunas = line.Split(';');
                produto.CodigoProduto = colunas[0];
                produto.Quantidade = Convert.ToInt32(colunas[1]);
                produto.QuantidadeMinimaCO = Convert.ToInt32(colunas[2]);
                produtos.Add(produto);
            }
            return produtos;
        }

        private static List<Venda> CarregaVendas(string path, List<Produto> produtos)
        {
            string pathArquivoVendas = System.IO.Path.Combine(path, "arquivos\\c1_vendas.txt");
            List<Venda> vendas = new List<Venda>();

            string[] txtVendas = System.IO.File.ReadAllLines(pathArquivoVendas);
            for (int linha = 0; linha < txtVendas.Length; linha++)
            {                
                var colunas = txtVendas[linha].Split(';');

                var venda = new Venda(
                    colunas[0],
                    Convert.ToInt32(colunas[1]),
                    Convert.ToInt32(colunas[2]), 
                    Convert.ToInt32(colunas[3]),
                    linha+1,
                    produtos.FirstOrDefault(p => p.CodigoProduto == colunas[0])
                    );                          

                vendas.Add(venda);
            }
            return vendas;
        }
       
        

    }
}

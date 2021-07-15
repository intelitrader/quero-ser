using System;
using System.Collections.Generic;
using System.IO;
using EstoqueOperacional.Models;

namespace EstoqueOperacional
{
    class Program
    {
        static void Main(string[] args)
        {
            // Coleta cada uma das linhas de vendas passadas no arquivo
            List<Venda> vendas = VendasEmLinhasParaListaDeProdutos(File.ReadAllLines(args[0]));

            // Coleta cada uma das linhas de produtos passados no arquivo
            List<Produto> produtos = ProdutosEmLinhasParaListaDeProdutos(File.ReadAllLines(args[1]));

            
        }

        // Transforma linhas de produtos tiradas do arquivo para uma lista do tipo Produto
        public static List<Produto> ProdutosEmLinhasParaListaDeProdutos(string[] linhasDosProdutos)
        {
            List<Produto> listaDeProdutos = new List<Produto>();

            for(int count = 0; count < linhasDosProdutos.Length; count++)
            {
                string[] dadosDoProduto = linhasDosProdutos[count].Split(";");

                Produto produto = new Produto(
                    int.Parse(
                        dadosDoProduto[0]
                    ),
                    int.Parse(
                        dadosDoProduto[1]
                    ),
                    int.Parse(
                        dadosDoProduto[2]
                    )
                );

                listaDeProdutos.Add(produto);
            }
            
            return listaDeProdutos;
        }

        // Transforma linhas de vendas tiradas do arquivo para uma lista do tipo Vendas
        public static List<Venda> VendasEmLinhasParaListaDeProdutos(string[] linhasDasVendas)
        {
            List<Venda> listaDeVendas = new List<Venda>();

            for(int count = 0; count < linhasDasVendas.Length; count++)
            {
                string[] dadosDaVenda = linhasDasVendas[count].Split(";");

                Venda venda = new Venda(
                    int.Parse(
                        dadosDaVenda[0]
                    ),
                    int.Parse(
                        dadosDaVenda[1]
                    ),
                    int.Parse(
                        dadosDaVenda[2]
                    ),
                    
                    int.Parse(
                        dadosDaVenda[3]
                    )
                );

                listaDeVendas.Add(venda);
            }
            
            return listaDeVendas;
        }
    }
}

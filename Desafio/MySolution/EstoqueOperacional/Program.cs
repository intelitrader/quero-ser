using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EstoqueOperacional.Models;
using EstoqueOperacional.Structs;

namespace EstoqueOperacional
{
    class Program
    {
        static void Main(string[] args)
        {
            // Coleta as linhas das vendas passadas no arquivo e transforma em uma lista do tipo "Venda"
            List<Venda> vendas = VendasEmLinhasParaListaDeVenda(File.ReadAllLines(args[0]));

            // Coleta as linhas dos produtos passados no arquivo e transforma em uma lista do tipo "Produto"
            List<Produto> produtos = ProdutosEmLinhasParaListaDeProdutos(File.ReadAllLines(args[1]));

            // Gera as vendas do relatório "transfere"
            List<VendaRelatorioTransfere> vendasRelatorioTransfere = GerarVendasRelatorioTransfere(vendas, produtos);

            // Cria o arquivo e coloca os dados do relatório "transfere".
            GerarRelatorioTransfere(vendasRelatorioTransfere);
        }

        // Transforma linhas de produtos tiradas do arquivo para uma lista do tipo "Produto".
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

        // Transforma linhas de vendas tiradas do arquivo para uma lista do tipo "Venda".
        public static List<Venda> VendasEmLinhasParaListaDeVenda(string[] linhasDasVendas)
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

        public static List<VendaRelatorioTransfere> GerarVendasRelatorioTransfere(List<Venda> vendas, List<Produto> produtos)
        {
            // Agrupa a soma das quantidades vendidas de cada produto
            var somaQtdVendidasAgrupadas = 
                from venda in vendas
                where venda.situacao == 100 || venda.situacao == 102
                group venda by venda.codProduto into vendasConfirmadas
                select new { codProduto = vendasConfirmadas.Key, qtdVendida = vendasConfirmadas.Sum(x => x.qtdVendida) };

            // Gera as vendas do relatório "transfere".
            var vendasRelatorioTransfere = 
                from venda in somaQtdVendidasAgrupadas
                join produto in produtos on venda.codProduto equals produto.codigo
                select new VendaRelatorioTransfere
                (
                    produto.codigo,
                    produto.qtdEstoque,
                    produto.qtdMinCO,
                    venda.qtdVendida,
                    produto.qtdEstoque - venda.qtdVendida,
                    (produto.qtdEstoque - venda.qtdVendida) < produto.qtdMinCO ? produto.qtdMinCO - (produto.qtdEstoque - venda.qtdVendida) : 0,
                    produto.qtdMinCO - (produto.qtdEstoque - venda.qtdVendida) > 10 ? produto.qtdMinCO - (produto.qtdEstoque - venda.qtdVendida) : produto.qtdMinCO - (produto.qtdEstoque - venda.qtdVendida) > 1 ? 10 : 0
                );

            return vendasRelatorioTransfere.ToList();
        }

        // Cria o arquivo e coloca os dados do relatório "transfere".
        public static void GerarRelatorioTransfere(List<VendaRelatorioTransfere> vendasRelatorioTransfere)
        {
            if (File.Exists("./transfere"))
            {
                File.Delete("./transfere");
            }

            File.AppendAllText("./transfere", "Necessidade de Transferência Armazém para CO\n\n");

            File.AppendAllText("./transfere", "Produto\t\tQtCO\t\tQtMin\t\tQtVendas\tEstq. após Vendas\tNecessidade\t\tTransf. de Arm p/ CO\n");
            
            foreach(var produto in vendasRelatorioTransfere)
            {
                File.AppendAllText("./transfere", $"{produto.produto}\t\t{produto.qtCO}\t\t{produto.qtMin}\t\t{produto.qtVendas}\t\t{produto.estqAposVendas}\t\t\t{produto.necessidade}\t\t\t{produto.transArmzParaCO}\n");
            }
        }
    }
}

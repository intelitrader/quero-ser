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
            // Coleta cada uma das linhas de vendas passadas no arquivo.
            List<Venda> vendas = VendasEmLinhasParaListaDeProdutos(File.ReadAllLines(args[0]));

            // Coleta cada uma das linhas de produtos passados no arquivo.
            List<Produto> produtos = ProdutosEmLinhasParaListaDeProdutos(File.ReadAllLines(args[1]));

            // Gera os dados do relatório "transfere".
            List<DadosRelatorioTransfere> dadosRelatorioTransfere = GerarDadosRelatorioTransfere(vendas, produtos);

            // Cria o arquivo e coloca os dados do relatório "transfere".
            GerarRelatorioTransfere(dadosRelatorioTransfere);
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

        // Transforma linhas de vendas tiradas do arquivo para uma lista do tipo "Vendas".
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

        // Gera os dados do relatório "transfere".
        public static List<DadosRelatorioTransfere> GerarDadosRelatorioTransfere(List<Venda> vendas, List<Produto> produtos)
        {
            // Agrupa as vendas pelo código do produto onde a situação for "venda confirmada e com pagamento ok" ou "venda confirmada, mas com pagamento pendente".
            var vendasConfirmadas = 
                from venda in vendas
                where venda.situacao == 100 || venda.situacao == 102
                group venda by venda.codProduto;

            var resumoVendas = new List<ResumoVendas>();
            
            // Coleta a soma das quantidades vendidas de cada produto e as coloca na lista "resumoVendas".
            foreach(var vendaConfirmada in vendasConfirmadas)
            {
                resumoVendas.Add
                (
                    new ResumoVendas
                    (
                        vendaConfirmada.Key,
                        vendaConfirmada.Sum(x => x.qtdVendida)
                    )
                );
            }

            // Gera os dados finais do relatório "transfere".
            var relatorioTransfere = 
                from venda in resumoVendas
                join produto in produtos on venda.codProduto equals produto.codigo
                select new DadosRelatorioTransfere
                (
                    produto.codigo,
                    produto.qtdEstoque,
                    produto.qtdMinCO,
                    venda.qtdVendida,
                    produto.qtdEstoque - venda.qtdVendida,
                    (produto.qtdEstoque - venda.qtdVendida) < produto.qtdMinCO ? produto.qtdMinCO - (produto.qtdEstoque - venda.qtdVendida) : 0,
                    produto.qtdMinCO - (produto.qtdEstoque - venda.qtdVendida) > 10 ? produto.qtdMinCO - (produto.qtdEstoque - venda.qtdVendida) : produto.qtdMinCO - (produto.qtdEstoque - venda.qtdVendida) > 1 ? 10 : 0
                );

            return relatorioTransfere.ToList();
        }

        // Cria o arquivo e coloca os dados do relatório "transfere".
        public static void GerarRelatorioTransfere(List<DadosRelatorioTransfere> dadosRelatorioTransfere)
        {
            if (File.Exists("./transfere"))
            {
                File.Delete("./transfere");
            }

            File.AppendAllText("./transfere", "Necessidade de Transferência Armazém para CO\n\n");

            File.AppendAllText("./transfere", "Produto\t\tQtCO\t\tQtMin\t\tQtVendas\tEstq. após Vendas\tNecessidade\t\tTransf. de Arm p/ CO\n");
            
            foreach(var produto in dadosRelatorioTransfere)
            {
                File.AppendAllText("./transfere", $"{produto.produto}\t\t{produto.qtCO}\t\t{produto.qtMin}\t\t{produto.qtVendas}\t\t{produto.estqAposVendas}\t\t\t{produto.necessidade}\t\t\t{produto.transArmzParaCO}\n");
            }
        }
    }
}

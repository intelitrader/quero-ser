using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EstoqueOperacional.Models;

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
            List<VendaRelatorioTransfere> vendasRelatorioTransfere = GeraVendasRelatorioTransfere(vendas, produtos);

            int[] vendasCanceladas = GeraVendasCanceladas(vendas);

            int[] vendasNaoFinalizadas = GeraVendasNaoFinalizadas(vendas);

            // Coleta as vendas onde a propriedade "situacao" é igual a "999"
            int[] vendasComErro = GeraVendasComErro(vendas);

            List<(int linha, int codProduto)> vendasCodigoProdutoInexistente = GeraVendasCodigoProdutoInexistente(vendas, produtos, vendasCanceladas, vendasNaoFinalizadas, vendasComErro);

            List<(int canal, int qtdVendida)> dadosRelatorioTotCanais = GeraDadosRelatorioTotCanais(vendas);

            // Cria e coloca os dados do relatório "transfere"
            GeraRelatorioTransfere(vendasRelatorioTransfere);

            // Cria e coloca os dados do relatório "divergencias"
            GeraRelatorioDivergencia(vendasCanceladas, vendasNaoFinalizadas, vendasComErro, vendasCodigoProdutoInexistente);

            GeraRelatorioTotCanais(dadosRelatorioTotCanais);
        }

        // Transforma linhas de produtos tiradas do arquivo para uma lista do tipo "Produto".
        public static List<Produto> ProdutosEmLinhasParaListaDeProdutos(string[] linhasDosProdutos)
        {
            List<Produto> listaDeProdutos = new List<Produto>();

            for(int count = 0; count < linhasDosProdutos.Length; count++)
            {
                string[] dadosDoProduto = linhasDosProdutos[count].Split(";");

                Produto produto = new Produto
                    (
                        int.Parse(dadosDoProduto[0]),
                        int.Parse(dadosDoProduto[1]),
                        int.Parse(dadosDoProduto[2])
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

                Venda venda = new Venda
                    (
                        int.Parse(dadosDaVenda[0]),
                        int.Parse(dadosDaVenda[1]),
                        int.Parse(dadosDaVenda[2]),
                        int.Parse(dadosDaVenda[3])
                    );

                listaDeVendas.Add(venda);
            }
            
            return listaDeVendas;
        }

        public static List<VendaRelatorioTransfere> GeraVendasRelatorioTransfere(List<Venda> vendas, List<Produto> produtos)
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

        public static int[] GeraVendasCanceladas(List<Venda> vendas)
        {
            return (from venda in vendas where venda.situacao == 135 select vendas.IndexOf(venda) + 1).ToArray();
        }

        public static int[] GeraVendasNaoFinalizadas(List<Venda> vendas)
        {
            return (from venda in vendas where venda.situacao == 190 select vendas.IndexOf(venda) + 1).ToArray();
        }

        public static int[] GeraVendasComErro(List<Venda> vendas)
        {
            return (from venda in vendas where venda.situacao == 999 select vendas.IndexOf(venda) + 1).ToArray();
        }

        public static List<(int linha, int codProduto)> GeraVendasCodigoProdutoInexistente(List<Venda> vendas, List<Produto> produtos, int[] vendasCanceladas, int[] vendasNaoFinalizadas, int[] vendasComErro)
        {
            return
            (
                from venda in vendas
                where !(from produto in produtos select produto.codigo).Contains(venda.codProduto)
                where !vendasCanceladas.Contains(vendas.IndexOf(venda) + 1)
                where !vendasNaoFinalizadas.Contains(vendas.IndexOf(venda) + 1)
                where !vendasComErro.Contains(vendas.IndexOf(venda) + 1)
                select (vendas.IndexOf(venda) + 1, venda.codProduto)
            )
            .ToList();
        }

        public static List<(int, int)> GeraDadosRelatorioTotCanais(List<Venda> vendas)
        {
            var dadosRelatorioTotCanais = (from venda in vendas where venda.situacao == 100 || venda.situacao == 102 group venda by venda.canal into vendasConfirmadas select (vendasConfirmadas.Key, vendasConfirmadas.Sum(x => x.qtdVendida))).ToList();
            dadosRelatorioTotCanais.Sort();
            return dadosRelatorioTotCanais;
        }

        // Cria o arquivo e coloca os dados do relatório "transfere".
        public static void GeraRelatorioTransfere(List<VendaRelatorioTransfere> vendasRelatorioTransfere)
        {
            if (File.Exists("./transfere.txt"))
            {
                File.Delete("./transfere.txt");
            }

            File.AppendAllText("./transfere.txt", "Necessidade de Transferência Armazém para CO\n\n");

            File.AppendAllText("./transfere.txt", "Produto\t\tQtCO\t\tQtMin\t\tQtVendas\tEstq. após Vendas\tNecessidade\t\tTransf. de Arm p/ CO\n");
            
            foreach(var produto in vendasRelatorioTransfere)
            {
                File.AppendAllText("./transfere.txt", $"{produto.produto}\t\t{produto.qtCO}\t\t{produto.qtMin}\t\t{produto.qtVendas}\t\t{produto.estqAposVendas}\t\t\t{produto.necessidade}\t\t\t{produto.transArmzParaCO}\n");
            }
        }

        // Cria o arquivo e coloca os dados do relatório "divergencia".
        public static void GeraRelatorioDivergencia(int[] vendasCanceladas, int[] vendasNaoFinalizadas, int[] vendasComErro, List<(int linha, int codProduto)> vendasCodigoProdutoInexistente)
        {
            if (File.Exists("./divergencias.txt"))
            {
                File.Delete("./divergencias.txt");
            }

            foreach(int linha in vendasCanceladas)
            {
                File.AppendAllText("./divergencias.txt", $"Linha {linha} - Venda cancelada\n");
            }

            foreach(int linha in vendasNaoFinalizadas)
            {
                File.AppendAllText("./divergencias.txt", $"Linha {linha} - Venda não finalizada\n");
            }

            foreach(int linha in vendasComErro)
            {
                File.AppendAllText("./divergencias.txt", $"Linha {linha} - Erro desconhecido. Acionar equipe de TI\n");
            }

            foreach(var venda in vendasCodigoProdutoInexistente)
            {
                File.AppendAllText("./divergencias.txt", $"Linha {venda.linha} - Código de Produto não encontrado {venda.codProduto}\n");
            }
        }

        public static void GeraRelatorioTotCanais(List<(int canal, int qtdVendida)> dadosRelatorioTotCanais)
        {
            if (File.Exists("./totcanais.txt"))
            {
                File.Delete("./totcanais.txt");
            }

            File.AppendAllText("./totcanais.txt", $"Quantidades de Vendas por canal\n\n");

            foreach(var dados in dadosRelatorioTotCanais)
            {
                switch(dados.canal)
                {
                    case 1:
                       File.AppendAllText("./totcanais.txt", $"{dados.canal} - Representantes\t\t{dados.qtdVendida}\n");
                        break;
                    case 2:
                       File.AppendAllText("./totcanais.txt", $"{dados.canal} - Website\t\t\t{dados.qtdVendida}\n");
                        break;
                    case 3:
                       File.AppendAllText("./totcanais.txt", $"{dados.canal} - App móvel Android\t\t{dados.qtdVendida}\n");
                        break;
                    case 4:
                       File.AppendAllText("./totcanais.txt", $"{dados.canal} - App móvel iPhone\t\t{dados.qtdVendida}\n");
                        break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TesteTecnicoIntelitrader.Helpers;

namespace TesteTecnicoIntelitrader
{
    public class Program
    {
        static void Main(string[] args)
        {
            string arquivoProdutosC1 = "ArquivosEntrada/c1_produtos.txt";
            string arquivoVendasC1 = "ArquivosEntrada/c1_vendas.txt";
            string arquivoDivervenciasC1 = "ArquivosSaida/CasoTeste1/c1_divergencias.txt";
            string arquivoTransfereC1 = "ArquivosSaida/CasoTeste1/c1_transfere.txt";
            string arquivoCanaisC1 = "ArquivosSaida/CasoTeste1/c1_totcanais.txt";

            var listaProdutosC1 = new List<Produto>();

            var helper = new Helper();
            helper.CriaProdutos(arquivoProdutosC1, listaProdutosC1);

            var vendaC1 = new Venda();
            vendaC1.VerificaVendas(arquivoVendasC1, arquivoDivervenciasC1, listaProdutosC1);

            helper.GeraRelatorioTransferencia(arquivoTransfereC1, listaProdutosC1);
            helper.GeraRelatorioCanaisVendas(arquivoCanaisC1, vendaC1);

            Console.WriteLine("Arquivos gerados na pasta './bin/Debug/net5.0/ArquivosSaida/CasoTeste1'");

            /* Caso 1 acima --- Caso 2 abaixo*/

            string arquivoProdutosC2 = "ArquivosEntrada/c2_produtos.txt";
            string arquivoVendasC2 = "ArquivosEntrada/c2_vendas.txt";
            string arquivoDivervenciasC2 = "ArquivosSaida/CasoTeste2/c2_divergencias.txt";
            string arquivoTransfereC2 = "ArquivosSaida/CasoTeste2/c2_transfere.txt";
            string arquivoCanaisC2 = "ArquivosSaida/CasoTeste2/c2_totcanais.txt";

            var listaProdutosC2 = new List<Produto>();

            helper.CriaProdutos(arquivoProdutosC2, listaProdutosC2);

            var vendaC2 = new Venda();
            vendaC2.VerificaVendas(arquivoVendasC2, arquivoDivervenciasC2, listaProdutosC2);

            helper.GeraRelatorioTransferencia(arquivoTransfereC2, listaProdutosC2);
            helper.GeraRelatorioCanaisVendas(arquivoCanaisC2, vendaC2);

            Console.WriteLine("Arquivos gerados na pasta './bin/Debug/net5.0/ArquivosSaida/CasoTeste2'");
            Console.Write("Pressione qualquer tecla para encerrar o programa...");
            Console.ReadLine();
        }
    }
}

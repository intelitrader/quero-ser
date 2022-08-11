using System;
using System.Collections.Generic;
using System.IO;

namespace TesteTecnicoIntelitrader.Helpers
{
    public class Helper
    {
        public void CriaProdutos(string enderecoArquivo, List<Produto> listaProdutos)
        {
            using (var fluxoProdutos = new FileStream(enderecoArquivo, FileMode.Open))
            using (var leitorProdutos = new StreamReader(fluxoProdutos))
            {
                while (!leitorProdutos.EndOfStream)
                {
                    string linha = leitorProdutos.ReadLine();
                    string[] campos = linha.Split(";");

                    int codigoProduto = Int32.Parse(campos[0]);
                    int estoqueInicial = Int32.Parse(campos[1]);
                    int quantidadeMinima = Int32.Parse(campos[2]);

                    listaProdutos.Add(new Produto(codigoProduto, estoqueInicial, quantidadeMinima));
                }
            }
        }

        public void GeraRelatorioTransferencia(string enderecoArquivo, List<Produto> listaProdutos)
        {
            using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoArquivo))
            {
                escritor.WriteLine("Necessidade de Transferência Armazém para CO\n");
                escritor.WriteLine("Produto   QtCO   QtMin   QtVendas   Estq.após   Necess.   Transf. de");
                escritor.WriteLine("                                     vendas               arm. p/ CO");

                foreach(Produto produto in listaProdutos)
                {
                    int repor = produto.CalculaReposicao();
                    int transferir = produto.CalculaTranferencia(repor);

                    escritor.WriteLine($"{produto.Codigo}     {produto.QuantidadeInicial}     {produto.QuantidadeMinima}      {produto.TotalVendido}         {produto.QuantidadeEstoque}         {repor}         {transferir}");
                }
            }
        }

        public void GeraRelatorioCanaisVendas(string enderecoArquivo, Venda vendas)
        {
            using (var fluxoArquivo = new FileStream(enderecoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoArquivo))
            {
                escritor.WriteLine("Quantidade de vendas por canal\n");
                escritor.WriteLine($"1 - Representantes          {vendas.VendasRepresentante}");
                escritor.WriteLine($"2 - Website                 {vendas.VendasWebsite}");
                escritor.WriteLine($"3 - App Móvel Android       {vendas.VendasAndroid}");
                escritor.WriteLine($"4 - App Móvel IPhone        {vendas.VendasIPhone}");
            }
        }
    }
}

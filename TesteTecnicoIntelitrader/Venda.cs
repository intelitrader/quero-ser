using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TesteTecnicoIntelitrader
{
    public class Venda
    {
        public Venda()
        {
            VendasRepresentante = 0;
            VendasWebsite = 0;
            VendasAndroid = 0;
            VendasIPhone = 0;
        }

        public int VendasRepresentante { get; set; }
        public int VendasWebsite { get; set; }
        public int VendasAndroid { get; set; }
        public int VendasIPhone { get; set; }

        public void VerificaVendas(string enderecoArquivoEntrada, string enderecoArquivoDivergencia, List<Produto> listaProdutos)
        {
            
            using (var fluxoVendas = new FileStream(enderecoArquivoEntrada, FileMode.Open))
            using (var leitorVendas = new StreamReader(fluxoVendas))
            {
                int linhaArquivo = 0;
                while (!leitorVendas.EndOfStream)
                {
                    linhaArquivo++;

                    string linha = leitorVendas.ReadLine();
                    string[] campos = linha.Split(';');

                    int codigoProduto = Int32.Parse(campos[0]);
                    int quantidadeVenda = Int32.Parse(campos[1]);
                    int statusVenda = Int32.Parse(campos[2]);
                    int canalVenda = Int32.Parse(campos[3]);

                    Produto produtoVendido = listaProdutos.FirstOrDefault(p => p.Codigo == codigoProduto);

                    if (produtoVendido != null)
                    {
                        switch (statusVenda)
                        {
                            case 100:
                                produtoVendido.AutorizaVenda(quantidadeVenda);
                                RegistraCanalVenda(canalVenda, quantidadeVenda);
                                break;
                            case 102:
                                produtoVendido.AutorizaVenda(quantidadeVenda);
                                RegistraCanalVenda(canalVenda, quantidadeVenda);
                                break;
                            case 135:
                                RegistraDivergencia(enderecoArquivoDivergencia, linhaArquivo, statusVenda);
                                break;
                            case 190:
                                RegistraDivergencia(enderecoArquivoDivergencia, linhaArquivo, statusVenda);
                                break;
                            case 999:
                                RegistraDivergencia(enderecoArquivoDivergencia, linhaArquivo, statusVenda);
                                break;
                        }
                    }
                    else
                    {
                        RegistraInexistente(enderecoArquivoDivergencia, linhaArquivo, codigoProduto);
                    }
                }
            }
        }

        public void RegistraCanalVenda(int canalVenda, int quantidadeVenda)
        {
            switch (canalVenda)
            {
                case 1:
                    VendasRepresentante += quantidadeVenda;
                    break;
                case 2:
                    VendasWebsite += quantidadeVenda;
                    break;
                case 3:
                    VendasAndroid += quantidadeVenda;
                    break;
                case 4:
                    VendasIPhone += quantidadeVenda;
                    break;
            }
        }

        public void RegistraDivergencia(string enderecoArquivoDivergencia, int linhaArquivo, int statusVenda)
        {
            using (var fluxoArquivo = new FileStream(enderecoArquivoDivergencia, FileMode.Append, FileAccess.Write))
            using (var escritor = new StreamWriter(fluxoArquivo))
            {
                switch (statusVenda)
                {
                    case 135:
                        escritor.WriteLine($"Linha {linhaArquivo} - Venda cancelada");
                        break;
                    case 190:
                        escritor.WriteLine($"Linha {linhaArquivo} - Venda não finalizada");
                        break;
                    case 999:
                        escritor.WriteLine($"Linha {linhaArquivo} - Erro desconhecido. Acionar equipe de TI");
                        break;
                }
            }
        }

        public void RegistraInexistente(string enderecoArquivoDivergencia, int linhaArquivo, int codigoProduto)
        {
            using (var fluxoArquivo = new FileStream(enderecoArquivoDivergencia, FileMode.Append, FileAccess.Write))
            using (var escritor = new StreamWriter(fluxoArquivo))
            {
                escritor.WriteLine($"Linha {linhaArquivo} - Código de produto não encontrado {codigoProduto}");
            }
        }
    }
}

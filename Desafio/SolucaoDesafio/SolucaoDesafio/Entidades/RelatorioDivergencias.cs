using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Entidades
{
    class RelatorioDivergencias
    {
        public RelatorioDivergencias()
        {
        }

        public static void ArquivoDivergencias(List<Produto> produtos, List<Vendas> vendas)
        {
            const string caminhoArquivoDivergencias = @"C:\Projects\quero-ser\Desafio\SolucaoDesafio\SolucaoDesafio\Arquivos\divergencias.txt";
            var aux = 0;
            var linha = 0;

            using (StreamWriter writer = new StreamWriter(caminhoArquivoDivergencias))
            {
                foreach (Vendas venda in vendas)
                {
                    foreach (Produto produto in produtos)
                    {
                        if (venda.CodProduto == produto.CodProduto)
                            aux++;
                    }

                    linha++;

                    if (aux == 0)
                        writer.WriteLine($"Linha {linha} – Código de Produto não encontrado {venda.CodProduto}");

                    aux = 0;

                    if (venda.SitVenda == "135")
                        writer.WriteLine($"Linha {linha} – Venda cancelada");

                    if (venda.SitVenda == "190")
                        writer.WriteLine($"Linha {linha} – Venda não finalizada");

                    if (venda.SitVenda == "999")
                        writer.WriteLine($"Linha {linha} – Erro desconhecido. Acionar equipe de TI");
                }
            }
        }
    }
}

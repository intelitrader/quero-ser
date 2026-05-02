using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Entidades
{
    class RelatorioCanais
    {
        public int QtVend1 { get; set; }
        public int QtVend2 { get; set; }
        public int QtVend3 { get; set; }
        public int QtVend4 { get; set; }
        public RelatorioCanais()
        {
        }

        public void ArquivoTotCanais(List<Vendas> vendas)
        {
            const string caminhoArquivoTotCanais = @"C:\Projects\quero-ser\Desafio\SolucaoDesafio\SolucaoDesafio\Arquivos\totcanais.txt";

            using (StreamWriter writer = new StreamWriter(caminhoArquivoTotCanais))
            {
                foreach (Vendas venda in vendas)
                {
                    if (venda.CanalVenda == "1" && venda.SitVenda == "100" || venda.CanalVenda == "1" && venda.SitVenda == "102")
                        QtVend1 += int.Parse(venda.QtdVendida);

                    if (venda.CanalVenda == "2" && venda.SitVenda == "100" || venda.CanalVenda == "2" && venda.SitVenda == "102")
                        QtVend2 += int.Parse(venda.QtdVendida);

                    if (venda.CanalVenda == "3" && venda.SitVenda == "100" || venda.CanalVenda == "3" && venda.SitVenda == "102")
                        QtVend3 += int.Parse(venda.QtdVendida);

                    if (venda.CanalVenda == "4" && venda.SitVenda == "100" || venda.CanalVenda == "4" && venda.SitVenda == "102")
                        QtVend4 += int.Parse(venda.QtdVendida);
                }

                writer.WriteLine($"Quantidades de Vendas por canal" + Environment.NewLine);

                writer.WriteLine("1 - Representantes" + QtVend1.ToString().PadLeft(18));
                writer.WriteLine("2 - Website" + QtVend2.ToString().PadLeft(25));
                writer.WriteLine("3 - App móvel Android" + QtVend3.ToString().PadLeft(15));
                writer.WriteLine("4 - App móvel iPhone" + QtVend4.ToString().PadLeft(15));
            }
        }

    }
}

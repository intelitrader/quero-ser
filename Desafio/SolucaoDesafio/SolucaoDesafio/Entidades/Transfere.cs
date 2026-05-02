using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Entidades
{
    class Transfere
    {
        public int QtCO { get; set; }
        public int QtMin { get; set; }
        public int QtVendas { get; set; }
        public int EstoqueAposVendas { get; set; }
        public int Necess { get; set; }
        public int TransfArmazemCO { get; set; }

        public Transfere()
        {
        }

        public void ArquivoTransfere(List<Produto> produtos, List<Vendas> vendas)
        {
            const string caminhoArquivoTransfere = @"C:\Projects\quero-ser\Desafio\SolucaoDesafio\SolucaoDesafio\Arquivos\transfere.txt";
            StringBuilder sbCabecalho = new StringBuilder();
            StringBuilder sbDados = new StringBuilder();

            using (StreamWriter writer = new StreamWriter(caminhoArquivoTransfere))
            {

                writer.WriteLine("Necessidade de Transferência Armazém para CO" + Environment.NewLine);

                sbCabecalho.AppendFormat("{0,-9}{1,-8}{2,-8}{3,-15}{4,-25}{5,-10}{6,-25}{7}",
                                         "Produto",
                                         "QtCO",
                                         "QtMin",
                                         "QtVendas",
                                         "Estq. após Vendas",
                                         "Necess.",
                                         "Transf. de Arm p/ CO",
                                         Environment.NewLine);

                writer.WriteLine(sbCabecalho.ToString());

                foreach (Produto produto in produtos)
                {
                    foreach (Vendas venda in vendas)
                    {
                        if (produto.CodProduto == venda.CodProduto && venda.SitVenda == "100" || produto.CodProduto == venda.CodProduto && venda.SitVenda == "102")
                        {
                            QtVendas += int.Parse(venda.QtdVendida);
                        }
                    }
                    
                    QtCO = int.Parse(produto.QtdEstoque);
                    QtMin = int.Parse(produto.QtdMinimaCO);
                    EstoqueAposVendas = QtCO - QtVendas;

                    if (EstoqueAposVendas > QtMin)
                    {
                        Necess = 0;
                        TransfArmazemCO = Necess;
                    }
                    
                    if (EstoqueAposVendas < QtMin)
                        Necess = QtMin - EstoqueAposVendas;

                    if (Necess > 1 && Necess < 10)
                        TransfArmazemCO = 10;
                    else
                        TransfArmazemCO = Necess;

                    sbDados.AppendFormat("{0,-9}{1,-8}{2,-8}{3,-15}{4,-25}{5,-10}{6,-25}{7}",
                                         produto.CodProduto,
                                         QtCO,
                                         QtMin,
                                         QtVendas,
                                         EstoqueAposVendas,
                                         Necess,
                                         TransfArmazemCO,
                                         Environment.NewLine);

                    QtVendas = 0;
                }
                writer.WriteLine(sbDados.ToString());
            }
        }

    }
}

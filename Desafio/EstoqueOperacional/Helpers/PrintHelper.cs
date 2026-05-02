using EstoqueOperacional.Models;
using System.Collections.Generic;
using System.IO;

namespace EstoqueOperacional.Helpers
{
    internal static class PrintHelper
    {
        private enum SellStatuses
        {
            SellCancelled = 135,
            SellUnfinished = 190,
            Unknown = 999
        }

        internal static readonly HashSet<int> Products = new HashSet<int>();

        internal static void PrintDivergences(List<Sell> sells)
        {
            using (StreamWriter streamWriter = new StreamWriter("divergencias.txt"))
            {
                int num = 0;
                foreach (Sell sell in sells)
                {
                    ++num;
                    switch (sell.Status)
                    {
                        case (int)SellStatuses.SellCancelled:
                            streamWriter.WriteLine("Linha {0} - Venda cancelada", num);
                            break;

                        case (int)SellStatuses.SellUnfinished:
                            streamWriter.WriteLine("Linha {0} - Venda não finalizada", num);
                            break;

                        case (int)SellStatuses.Unknown:
                            streamWriter.WriteLine("Linha {0} - Erro desconhecido. Acionar equipe de TI", num);
                            break;

                        default:
                            if (!Products.Contains(sell.Code))
                                streamWriter.WriteLine("Linha {0} - Código de Produto não encontrado {1}", num, sell.Code);
                            break;
                    }
                }
            }
        }

        internal static void PrintTransfer(IEnumerable<Transfer> transfer)
        {
            using (StreamWriter streamWriter = new StreamWriter("transfere.txt"))
            {
                streamWriter.WriteLine("Necessidade de Transferência Armazém para CO");
                streamWriter.WriteLine();
                streamWriter.WriteLine("Produto\tQtCO\tQtMin\tQtVendas\tEstq.após\tNecess.\tTransf. de");
                streamWriter.WriteLine("\t\t\t\t\t\t\t\t\tVendas\t\t\t\tArm p/ CO");
                foreach (Transfer tr in transfer)
                {
                    string str = tr.QtAfterSells.ToString();
                    streamWriter.Write("{0}\t", tr.Code);
                    streamWriter.Write("{0}\t{1}", tr.QtCo, tr.QtCo > 999 ? "" : "\t");
                    streamWriter.Write("{0}\t\t", tr.QtMin);
                    streamWriter.Write("{0}\t\t\t", tr.QtVendas);
                    streamWriter.Write(str + (str.Length >= 4 ? "" : "\t") + "\t\t");
                    streamWriter.Write("{0}\t\t", tr.Needed);
                    streamWriter.Write("{0}", tr.Transf);
                    streamWriter.WriteLine();
                }
            }
        }

        internal static void PrintChannelSales(Dictionary<int, int> totalChannels)
        {
            using (StreamWriter streamWriter = new StreamWriter("total_canal.txt"))
            {
                streamWriter.WriteLine("Quantidades de Vendas por Canal");
                streamWriter.WriteLine();
                streamWriter.WriteLine("Canal\t\t\t\t   QtVendas");
                streamWriter.WriteLine("1 - Representantes\t\t\t{0}", totalChannels[1]);
                streamWriter.WriteLine("2 - Website\t\t\t\t\t{0}", totalChannels[2]);
                streamWriter.WriteLine("3 - App móvel Android\t\t{0}", totalChannels[3]);
                streamWriter.WriteLine("4 - App móvel iPhone\t\t{0}", totalChannels[4]);
            }
        }
    }
}
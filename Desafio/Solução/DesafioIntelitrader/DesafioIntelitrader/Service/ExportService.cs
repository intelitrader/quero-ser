using DesafioIntelitrader.Models;
using System.Collections.Generic;
using System.IO;

namespace DesafioIntelitrader.Service
{
    public static class ExportService
    {
        public static void ExportarTXTVendasConfirmadas(string pathBase,  List<VendasConfirmadas> vendasConfirmadas)
        {
            var path = System.IO.Path.Combine(pathBase, "arquivos\\c1_tranfere.txt");            
            if (!File.Exists(path))
            {                
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Necessidade de Trasferência Armazém para CO");
                    sw.WriteLine();
                    sw.WriteLine("Produto\tQtCO\tQtMin\tQtVendas\tEstq.após Vendas\tNecess.\tTransf. de Arm p/CO");
                    sw.WriteLine();
                    foreach (var venda in vendasConfirmadas)
                    {
                        sw.WriteLine($"{venda.Produto} \t {venda.QtCO} \t {venda.QtMin} \t {venda.QtVendas} \t {venda.EstoquePosVendas} \t {venda.NecessidadeReposicao} \t {venda.QuantidadeTransferir}");
                        
                    }
                }
            }           
        }

        public static void ExportarTXTVendasDivergentes(string pathBase, List<Venda> vendasDivergentes)
        {
            var path = System.IO.Path.Combine(pathBase, "arquivos\\c1_divergencias.txt");
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {                   
                    foreach (var venda in vendasDivergentes)
                    {
                        sw.WriteLine($"{venda.MensagemDivergencia}");

                    }
                }
            }
        }

        public static void ExportarTXTVendaTotalCanais(string pathBase, List<VendaCanal> vendas)
        {
            var path = System.IO.Path.Combine(pathBase, "arquivos\\c1_totcanal.txt");
            if (!File.Exists(path))
            {                
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Quantidades de Vendas por Canal");
                    sw.WriteLine();
                    sw.WriteLine("Canal\tQtVendas");
                    foreach (var venda in vendas)
                    {
                        sw.WriteLine($"{venda.Canal}\t{venda.QtVendas}");

                    }
                }
            }
        }


    }
}

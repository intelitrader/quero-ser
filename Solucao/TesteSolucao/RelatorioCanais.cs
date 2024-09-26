using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSolucao
{
    internal class RelatorioCanais
    {
        public static async Task Canais(List<Vendas> vendas)
        {
            int cont1 = 0;
            int cont2 = 0;
            int cont3 = 0;
            int cont4 = 0;
            string cont1Str;
            string cont2Str;
            string cont3Str;
            string cont4Str;
            string canal = "Canal";
            string QtVendas = "QtVendas";
            string canal1 = "1 - Representantes";
            string canal2 = "2 - Website";
            string canal3 = "3 - App móvel Android";
            string canal4 = "4 - App móvel iPhone";

            using (var writer = new StreamWriter(@"C:\Users\Administrador\Desktop\Teste\TesteSolucao\totcanais.txt"))
            {

                writer.Write("Quantidades de Vendas por canal" + "\n\n");
                writer.Write(canal.PadLeft(1) + QtVendas.PadLeft(36) + "\n\n");

                foreach (Vendas v in vendas)
                {
                    if (v.CanalVenda == "1") { cont1 = cont1 + Int32.Parse(v.QtVenda); }
                    if (v.CanalVenda == "2") { cont2 = cont2 + Int32.Parse(v.QtVenda); }
                    if (v.CanalVenda == "3") { cont3 = cont3 + Int32.Parse(v.QtVenda); }
                    if (v.CanalVenda == "4") { cont4 = cont4 + Int32.Parse(v.QtVenda); }

                }

                cont1Str = cont1.ToString();
                cont2Str = cont2.ToString();
                cont3Str = cont3.ToString();
                cont4Str = cont4.ToString();



                writer.Write(canal1.PadLeft(1) + cont1Str.PadLeft(23) + "\n");
                writer.Write(canal2.PadLeft(1) + cont2Str.PadLeft(30) + "\n");
                writer.Write(canal3.PadLeft(1) + cont3Str.PadLeft(20) + "\n");
                writer.Write(canal4.PadLeft(1) + cont4Str.PadLeft(20) + "\n");


            }
        }
    }
}

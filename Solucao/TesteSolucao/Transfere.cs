using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSolucao
{
    class Transfere : Produto
    {

        public string EstqAposVendas;
        public string Necessidade;
        public string TransfArmazem;



        public static async Task Example(List<Produto> produtos, List<Vendas> vendas)
        {
            int ContVendas=0;
            int EstoquePosVendas = 0;
            int Necess = 0;
            int QtMini = 0;
            int transfe = 0;
            string ContVendasStr;
            string EstoquePosVendasStr;
            string NecessStr;
            string transfStr;
            string Produto = "Produto";
            string QtCO = "QtCO";
            string QtMin = "QtMin";
            string QtVendas = "QtVendas";
            string Estq_apos = "Estq.após Vendas";
            string necessid = "Necess.";
            string transf = "Transf.de Arm p/ CO";



            using (var writer = new StreamWriter(@"C:\Users\Administrador\Desktop\Teste\TesteSolucao\transfere.txt"))
            {

                writer.Write("Necessidade de Transferência Armazém para CO"+ "\n\n");
                writer.Write(Produto.PadLeft(1)   + QtCO.PadLeft(6) + QtMin.PadLeft(8) + QtVendas.PadLeft(10) + Estq_apos.PadLeft(18) +  necessid.PadLeft(9) + transf.PadLeft(21) + "\n\n");

                foreach (Produto p in produtos)
                {
                    foreach (Vendas v in vendas)
                    {
                        if (p.CodProduto == v.CodProduto) 
                        {
                           ContVendas = ContVendas + Int32.Parse(v.QtVenda);
                            
                            
                        }
                    }
                    EstoquePosVendas = Int32.Parse(p.QtEstoque) - ContVendas;
                    QtMini = Int32.Parse(p.QtMinima);
                    if (EstoquePosVendas < QtMini) { Necess = QtMini - EstoquePosVendas; } else { Necess = 0; }
                    if(Necess > 1 && Necess<10) { transfe = 10; }
                    if (Necess >= 10) { transfe = Necess; } 
                    if(Necess ==0) { transfe = 0; }

                    ContVendasStr = ContVendas.ToString();
                    EstoquePosVendasStr = EstoquePosVendas.ToString();
                    NecessStr = Necess.ToString();
                    transfStr = transfe.ToString(); 



                    writer.Write(p.CodProduto.PadLeft(1) +""+ p.QtEstoque.PadLeft(8) + "" + p.QtMinima.PadLeft(8) + "" + ContVendasStr.PadLeft(10) + "" + EstoquePosVendasStr.PadLeft(12)+ "" + NecessStr.PadLeft(12)+"" + transfStr.PadLeft(12) + Environment.NewLine);
                    ContVendas = 0;

                }
            }
        }


        public static void IserirTransfere(List<Produto>produtos)
        {
            List<Transfere> transfere = new List<Transfere>();

            foreach (Produto p in produtos)
            {
                Console.WriteLine(p.CodProduto + " " + p.QtMinima + " " + p.QtEstoque);
               
                foreach (Transfere t in transfere)
                {
                        t.CodProduto = p.CodProduto;
                        t.QtEstoque = p.QtEstoque;
                        t.QtMinima = p.QtMinima;

                        transfere.Add(t);
                 
                    

                }

                //}

            }

            foreach (Transfere t in transfere)
            {
                Console.WriteLine(t.CodProduto + " " + t.QtMinima + " " + t.QtEstoque);
            }



        }
    }
} 
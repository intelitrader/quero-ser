using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSolucao
{
    internal class RelatorioDivergencia
    {
        public static async Task Divergencia(List<Produto> produtos, List<Vendas> vendas)
        {

            int linha = 0;
            int verifica = 0;

            using (var writer = new StreamWriter(@"C:\Users\Administrador\Desktop\Teste\TesteSolucao\divergencias.txt"))
            {



                foreach (Vendas v in vendas)
                {
                    linha++;
                    verifica = 0;

                    foreach (Produto p in produtos)
                    {


                        if (v.CodProduto == p.CodProduto)
                        {
                            verifica = 1;
                            switch (v.SituacaoVenda)
                            {
                                case "135":
                                    writer.Write("Linha " + linha + " - Venda cancelada" + "\n");
                                    break;
                                case "190":
                                    writer.Write("Linha " + linha + " - Venda não finalizada" + "\n");
                                    break;
                                case "999":
                                    writer.Write("Linha " + linha + " - Erro desconhecido. Acionar equipe de TI" + "\n");
                                    break;


                            }

                        }

                    }
                        
                        if (verifica==0)
                        {

                                writer.Write("Linha " + linha + " - Código de Produto não encontrado " + v.CodProduto + "\n");
                        }

                        

                    }
                }
            }






        }
    }



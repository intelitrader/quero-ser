using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSolucao
{
    public class Vendas
    {

        private string codProduto;
        private string qtVenda;
        private string situacaoVenda;
        private string canalVenda;
        private static Stream caminhovendas;
        public static List<Vendas>vendas;

        public string CodProduto { get; set; }
        public string QtVenda { get; set; }
        public string SituacaoVenda { get; set; }
        public string CanalVenda { get; set; }

        public Vendas(string codProduto, string qtVenda, string situacaoVenda, string canalVenda)
        {
            this.CodProduto = codProduto;
            this.QtVenda = qtVenda;
            this.SituacaoVenda = situacaoVenda;
            this.CanalVenda = canalVenda;

        }

        public Vendas()
        {
        }

        public static List<Vendas> InserirVendas(String caminhovendas)
          {
              List<Vendas> vendas = new List<Vendas>();

              string[] array = File.ReadAllLines(caminhovendas);

              for (int i = 0; i < array.Length; i++)
              {
                  Vendas p = new Vendas();

                  string[] auxiliar = array[i].Split(';');

                  p.CodProduto = (auxiliar[0]);
                  p.QtVenda = auxiliar[1];
                  p.SituacaoVenda = auxiliar[2];
                  p.CanalVenda = auxiliar[3];

                vendas.Add(p);
              }


             /* foreach (Vendas p in vendas)
              {
                  Console.WriteLine(p.CodProduto + " " + p.QtVenda + " " + p.SituacaoVenda+ " "+ p.CanalVenda);
              }*/
             return vendas;
          }
    }
}

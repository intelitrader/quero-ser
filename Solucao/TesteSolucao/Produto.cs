using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSolucao
{
    public class Produto : Vendas
    {

        private string codProduto;
        private string qtEstoque;
        private string qtMinima;
        private static Stream caminhoprodutos;
        public static List<Produto> produtos;


        public string CodProduto { get; set; }
        public string QtMinima { get; set; }
        public string QtEstoque { get; set; }


        public Produto(string codProduto, string qtEstoque, string qtMinima)
        {
            this.CodProduto = codProduto;
            this.QtEstoque = qtEstoque;
            this.QtMinima = qtMinima;

        }

        public Produto()
        {
        }

        public static List<Produto> InserirProdutos(string caminhoprodutos)
        {

            List<Produto> produtos = new List<Produto>();
            string[] array = File.ReadAllLines(caminhoprodutos);

            for (int i = 0; i < array.Length; i++)
            {
                Produto p = new Produto();

                string[] auxiliar = array[i].Split(';');

                p.CodProduto = (auxiliar[0]);
                p.QtEstoque = auxiliar[1];
                p.QtMinima = auxiliar[2];

                produtos.Add(p);
            }


            /*foreach (Produto p in produtos)
            {
                Console.WriteLine(p.CodProduto + " " + p.QtMinima + " " + p.QtEstoque);
            }*/
            
            return produtos;

        }
    }
}

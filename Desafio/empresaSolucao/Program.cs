using System;
using System.Collections.Generic;

namespace empresaSolucao
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instânciamos as listas Produto e Venda
            List<Produto> produtos = new List<Produto>();
            List<Venda> venda = new List<Venda>();
 
        }

        // Fazemos um método para criar o arquivo.txt
        public void GerarArquivo(string caminho, string conteudo)
        {
            using (var streamWritter = new StreamWriter(caminho))
            {
                streamWritter.Write(conteudo);
            }
        }
    }
}

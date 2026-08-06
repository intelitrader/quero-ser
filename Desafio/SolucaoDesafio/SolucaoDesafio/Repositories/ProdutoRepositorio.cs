using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Entidades.Interfaces;

namespace Desafio.Entidades
{
    class ProdutoRepositorio : IRepositorio<Produto>
    {
        private List<Produto> produtos = new List<Produto>();
        public List<Produto> Lista(string caminhoArquivo)
        {
           using (StreamReader arquivo = new StreamReader(caminhoArquivo))
           {
                string linha;

                while((linha = arquivo.ReadLine()) != null)
                {                   
                    var aux = linha.Split(';');

                    Produto produto = new Produto(aux[0],
                                                  aux[1],
                                                  aux[2]);

                    produtos.Add(produto);
                }
           }

            return produtos;
        }
    }
}

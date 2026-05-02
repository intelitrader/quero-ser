using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Entidades.Interfaces;

namespace Desafio.Entidades
{
    class VendasRepositorio : IRepositorio<Vendas>
    {
        private List<Vendas> vendas = new List<Vendas>();
        public List<Vendas> Lista(string caminhoArquivo)
        {
            using (StreamReader arquivo = new StreamReader(caminhoArquivo))
            {
                string linha;

                while ((linha = arquivo.ReadLine()) != null)
                {
                    var aux = linha.Split(';');

                    Vendas venda = new Vendas(aux[0],
                                              aux[1],
                                              aux[2],
                                              aux[3]);

                    vendas.Add(venda);
                }
            }
            
            return vendas;
        }
    }
}

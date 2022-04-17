using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Entidades
{
    class Vendas
    {
        public string CodProduto { get; set; }
        public string QtdVendida { get; set; }
        public string SitVenda { get; set; }
        public string CanalVenda { get; set; }

        public Vendas()
        {
        }

        public Vendas(string codProduto, string qtdVendida, string sitVenda, string canalVenda)
        {
            CodProduto = codProduto;
            QtdVendida = qtdVendida;
            SitVenda = sitVenda;
            CanalVenda = canalVenda;
        }
    }
}

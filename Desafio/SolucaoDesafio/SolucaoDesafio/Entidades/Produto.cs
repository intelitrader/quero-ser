using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Entidades
{
    class Produto
    {
        public string CodProduto { get; set; }
        public string QtdEstoque { get; set; }
        public string QtdMinimaCO { get; set; }

        public Produto()
        {

        }

        public Produto(string codProduto, string qtdEstoque, string qtdMinimaCO)
        {
            CodProduto = codProduto;
            QtdEstoque = qtdEstoque;
            QtdMinimaCO = qtdMinimaCO;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnicoIntelitrader
{
    public class Produto
    {
        public Produto(int codigo, int quantidadeInicial, int quantidadeMinima)
        {
            Codigo = codigo;
            QuantidadeInicial = quantidadeInicial;
            QuantidadeEstoque = quantidadeInicial;
            QuantidadeMinima = quantidadeMinima;
            TotalVendido = 0;
        }

        public int Codigo { get; set; }
        public int QuantidadeInicial { get; }
        public int QuantidadeEstoque { get; set; }
        public int QuantidadeMinima { get; set; }
        public int TotalVendido { get; set; }

        public void AutorizaVenda(int quantidadeVendida)
        {
            QuantidadeEstoque -= quantidadeVendida;
            TotalVendido += quantidadeVendida;
        }

        public int CalculaReposicao()
        {
            if (this.QuantidadeMinima > this.QuantidadeEstoque)
            {
                return this.QuantidadeMinima - this.QuantidadeEstoque;
            }

            return 0;
        }

        public int CalculaTranferencia(int reposicao)
        {
            if (reposicao > 0 && reposicao < 10)
            {
                return 10;
            }

            return reposicao;
        }
    }
}

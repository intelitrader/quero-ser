using System;

namespace empresaSolucao
{
    class Venda
    {
        public Venda(string fonte, int linha)
        {
            // Quebramos cada linha em partes, pegado
            var split = fonte.Split(";");
            Quantidade = Convert.ToInt32(split[1]);
            Linha = linha;
            CodigoProduto = Convert.ToInt32(split[0]);
            Situacao = (SituacaoVenda)Convert.ToInt32(split[2]);
            Canal = (CanalVenda)Convert.ToInt32(split[3]);


        }


        public int Linha { get; }
        public int CodigoProduto { get; }
        public int Quantidade { get; }
        public CanalVenda Canal { get; }
        public SituacaoVenda Situacao {get; }

        // Usamos de um enum para clissifcar os diferentes tipos de status da venda
        public enum SituacaoVenda
        {
            VendaConfirmada = 100,
            VendaConfirmadaPagPendente = 102,
            Cancelada = 135,
            NaoFinalizadas = 190,
            Erro = 999

        }
        // Usamos de um enum para clissifcar os diferentes tipos de canal da venda
        public enum CanalVenda
        {
            Representante = 1,
            WebSite = 2,
            Android = 3,
            Iphone = 4

        }

    }
}

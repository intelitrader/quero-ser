namespace Solucao.Models
{
    class Vendas
    {
        public int Linha { get; set; }
        public int CodProduto { get; set; }
    
        public int QtdVendida { get; set; }
        
        public int SituacaoVenda { get; set; }

        public int  CanalDeVenda { get; set; }
    
    }
}
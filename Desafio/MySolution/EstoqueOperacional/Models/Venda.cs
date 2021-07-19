namespace EstoqueOperacional.Models
{
    public class Venda
    {
        public int codProduto {get;set;}
        public int qtdVendida {get;set;}
        public int situacao {get;set;}
        public int canal {get;set;}

        public Venda(int codigo, int qtdVendida, int situacao, int canal)
        {
            this.codProduto = codigo;
            this.qtdVendida = qtdVendida;
            this.situacao = situacao;
            this.canal = canal;
        }
    }
}
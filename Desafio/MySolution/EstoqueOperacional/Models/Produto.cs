namespace EstoqueOperacional.Models
{
    public class Produto
    {
        private int codigo {get ; set;}
        private int qtdEstoque {get;set;}
        private int qtdMinCO {get;set;}

        public Produto(int codigo, int qtdEstoque, int qtdMinCO)
        {
            this.codigo = codigo;
            this.qtdEstoque = qtdEstoque;
            this.qtdMinCO = qtdMinCO;
        }
    }
}
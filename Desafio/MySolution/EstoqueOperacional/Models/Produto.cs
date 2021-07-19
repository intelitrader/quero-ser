namespace EstoqueOperacional.Models
{
    public class Produto
    {
        public int codigo {get ; set;}
        public int qtdEstoque {get;set;}
        public int qtdMinCO {get;set;}

        public Produto(int codigo, int qtdEstoque, int qtdMinCO)
        {
            this.codigo = codigo;
            this.qtdEstoque = qtdEstoque;
            this.qtdMinCO = qtdMinCO;
        }
    }
}
namespace EstoqueOperacional.Models
{
    public class Venda
    {
        private int codigo {get;set;}
        private int qtdVendida {get;set;}
        private int situacao {get;set;}
        private int canal {get;set;}

        public Venda(int codigo, int qtdVendida, int situacao, int canal)
        {
            this.codigo = codigo;
            this.qtdVendida = qtdVendida;
            this.situacao = situacao;
            this.canal = canal;
        }
    }
}
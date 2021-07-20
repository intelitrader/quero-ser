namespace EstoqueOperacional.Models
{
    public class Produto
    {
        private int _codigo;
        public int codigo
        {
            get => _codigo;
            
            set {
                if(!(value >= 10000) && !(value <= 99999))
                {
                    _codigo = 0;
                }

                _codigo = value;
            }
        }
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
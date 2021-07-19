namespace EstoqueOperacional.Structs
{
    public struct ResumoVendas
    {
        public int codProduto;
        public int qtdVendida;

        public ResumoVendas(int codProduto, int qtdVendida)
        {
            this.codProduto = codProduto;
            this.qtdVendida = qtdVendida;
        }
    }
}
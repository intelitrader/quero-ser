namespace EstoqueOperacional.Models
{
    public class VendaRelatorioTransfere
    {
        public int produto;
        public int qtCO;
        public int qtMin;
        public int qtVendas;
        public int estqAposVendas;
        public int necessidade;
        public int transArmzParaCO;

        public VendaRelatorioTransfere(int produto, int qtCO, int qtMin, int qtVendas, int estqAposVendas, int necessidade, int transfArmzParaCO)
        {
            this.produto = produto;
            this.qtCO = qtCO;
            this.qtMin = qtMin;
            this.qtVendas = qtVendas;
            this.estqAposVendas = estqAposVendas;
            this.necessidade = necessidade;
            this.transArmzParaCO = transfArmzParaCO;
        }
    }
}
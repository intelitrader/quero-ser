using OperationalStorage.Entities.Enums;

namespace OperationalStorage.Entities
{
    public class Sale
    {
        public Sale(int productCode, int quantitySold, SaleSituation situation, SaleChannel channel)
        {
            ProductCode = productCode;
            QuantitySold = quantitySold;
            Situation = situation;
            Channel = channel;
        }

        public int ProductCode { get; set; }
        public int QuantitySold { get; set; }
        public SaleSituation Situation { get; set; }
        public SaleChannel Channel { get; set; }

        public override string ToString()
        {
            return $"Product Code: {ProductCode}, Quantity Selled: {QuantitySold}, Situation: {Situation}, Channel: {Channel}";
        }
    }
}
 
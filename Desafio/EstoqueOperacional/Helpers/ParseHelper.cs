using EstoqueOperacional.Models;

namespace EstoqueOperacional.Helpers
{
    internal static class ParseHelper
    {
        internal static Product ParseToProduct(string line)
        {
            string[] strArray = line.Split(';');
            return new Product()
            {
                Code = int.Parse(strArray[0]),
                Quantity = int.Parse(strArray[1]),
                MinRequiredQuantity = int.Parse(strArray[2])
            };
        }

        internal static Sell ParseToSell(string line)
        {
            string[] strArray = line.Split(';');
            return new Sell()
            {
                Code = int.Parse(strArray[0]),
                Quantity = int.Parse(strArray[1]),
                Status = int.Parse(strArray[2]),
                Channel = int.Parse(strArray[3])
            };
        }
    }
}
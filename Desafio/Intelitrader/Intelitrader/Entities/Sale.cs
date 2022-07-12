using Intelitrader.Entities.Enums;
using System;

namespace Intelitrader.Entities
{
    internal class Sale
    {
        public int ProductCode { get; set; }
        public int SoldAmount { get; set; }
        public SaleStatus SaleStatus { get; set; }
        public SaleChannel SaleChannel { get; set; }

        public Sale() { }

        public Sale(int productCode, int soldAmount, SaleStatus saleStatus, SaleChannel saleChannel)
        {
            if (productCode >= 10000 && productCode.ToString().Length == 5)
                ProductCode = productCode;
            else throw new Exception($"{productCode} é um código de produto inválido");

            SoldAmount = soldAmount;
            SaleStatus = saleStatus;
            SaleChannel = saleChannel;
        }
    }
}

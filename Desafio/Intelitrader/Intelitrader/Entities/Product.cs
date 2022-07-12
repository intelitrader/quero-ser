using System;
using Intelitrader.Entities.Enums;
using System.Collections.Generic;

namespace Intelitrader.Entities
{
    internal class Product
    {
        public int Code { get; set; }
        public int Quantity { get; set; }
        public int MinimalForOC { get; set; }
        public List<Sale> Sales { get; set; }

        public Product() { }

        public Product(int code, int quantity, int minimalForOC, List<Sale> sales)
        {
            if (code >= 10000 && code.ToString().Length == 5) 
                Code = code;
            else throw new Exception($"{code} é um código de produto inválido");

            Quantity = quantity;
            MinimalForOC = minimalForOC;
            Sales = sales;
        }

        public int TotalSold()
        {
            int sum = 0;

            foreach (Sale sale in Sales)
            {
                var confirmedSale = sale.SaleStatus == SaleStatus.ConfirmedAndPayd 
                    || sale.SaleStatus == SaleStatus.ConfirmedAndWaitingPayment;

                if (confirmedSale && sale.ProductCode == Code)
                    sum += 1;
            }

            return sum;
        }

        public int InventoryAmount()
        {
            return Quantity - TotalSold();
        }

        public int ReplacementNeeded()
        {
            if (InventoryAmount() >= MinimalForOC)
            {
                return 0;
            }

            return MinimalForOC - InventoryAmount();
        }

        public int TransferToOC()
        {
            if (ReplacementNeeded() > 1 && ReplacementNeeded() < 10)
            {
                return 10;
            }

            return ReplacementNeeded();
        }
    }
}

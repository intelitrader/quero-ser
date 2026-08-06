using EstoqueOperacional.Models;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueOperacional.Helpers
{
    internal static class MiscHelper
    {
        private enum SellStatuses
        {
            SellConfirmedPaymentOk = 100,
            SellConfirmedPaymentPending = 102,
        }

        internal static readonly Dictionary<int, int> TotalVendas = new Dictionary<int, int>();
        internal static readonly Dictionary<int, int> TotalChannels = new Dictionary<int, int>();

        internal static IEnumerable<Transfer> CreateTransfers(IEnumerable<Product> products)
        {
            return from product in products
                   let qtAfterSells = product.Quantity - TotalVendas[product.Code]
                   let qtNeeded = product.MinRequiredQuantity - qtAfterSells
                   select new Transfer()
                   {
                       Code = product.Code,
                       QtCo = product.Quantity,
                       QtMin = product.MinRequiredQuantity,
                       QtVendas = TotalVendas[product.Code],
                       QtAfterSells = qtAfterSells,
                       Needed = qtNeeded > 0 ? qtNeeded : 0,
                       Transf = qtNeeded < 1 || qtNeeded > 10 ? (qtNeeded > 0 ? qtNeeded : 0) : 10
                   };
        }

        internal static void CalcTotVendas(List<Sell> sells)
        {
            foreach (Sell sell in sells)
            {
                if (!TotalVendas.ContainsKey(sell.Code))
                    TotalVendas[sell.Code] = 0;
                bool sellConfirmed = sell.Status == (int)SellStatuses.SellConfirmedPaymentOk ||
                                     sell.Status == (int)SellStatuses.SellConfirmedPaymentPending;
                if (sellConfirmed)
                    TotalVendas[sell.Code] += sell.Quantity;
                if (!TotalChannels.ContainsKey(sell.Channel))
                    TotalChannels[sell.Channel] = 0;
                if (sellConfirmed)
                    TotalChannels[sell.Channel] += sell.Quantity;
            }
        }
    }
}
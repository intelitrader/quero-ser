using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTraderSolutionPlus.Models.Reports
{
    public class ProductTransferLine
    {
        public int ProductCode { get; set; }
        public int Inventory { get; set; }
        public int MinInventory { get; set; }
        public int SaleSize { get; set; }
        public int InventoryAfterSale { get; set; }
        public int InventoryDeficit { get; set; }
        public int InventoryTransfer { get; set; }
    }
}

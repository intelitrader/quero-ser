using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quero_ser.model
{
    public class Transfer
    {
        public uint product { get; set; }
        public int QuantityOperationsCenter { get; set; }
        public int minimumAmount { get; set; }
        public int quantitySold { get; set; }
        public int stockAfterSale { get; set; }
        public int replacement { get; set; }
        public int transferToOperationsCenter { get; set; }
    }
}
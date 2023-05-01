using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quero_ser.model
{
    public class Product
    {
        public uint productCode { get; set; }
        public int quantityInStockBeginningPeriod { get; set; }
        public int minStockCenterOperation { get; set; }
    }
}
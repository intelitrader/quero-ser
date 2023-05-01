using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quero_ser.model
{
    public class Sale
    {
        public uint productCode { get; set; }
        public int quantitySale { get; set; }
        public int saleSituation { get; set; }
        public int saleChannel { get; set; }
    }
}
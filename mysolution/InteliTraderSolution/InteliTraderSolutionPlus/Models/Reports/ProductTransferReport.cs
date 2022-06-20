using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTraderSolutionPlus.Models.Reports
{
    public class ProductTransferReport
    {
        public string Description { get; set; }
        public IEnumerable<ProductTransferLine> ProductTransferLine { get; set; }
    }
}

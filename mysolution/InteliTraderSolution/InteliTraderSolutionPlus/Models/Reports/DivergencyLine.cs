using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTraderSolutionPlus.Models.Reports
{
    public class DivergencyLine
    {
        public int Line { get; set; }
        public int Error { get; set; }
        public int ProductCode { get; set; }
        public bool? InvalidProductCode { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTraderSolutionPlus.Models.Reports
{
    public class DivergencyReport
    {
        public IEnumerable<DivergencyLine> DivergencyLines { get; set; }
    }
}

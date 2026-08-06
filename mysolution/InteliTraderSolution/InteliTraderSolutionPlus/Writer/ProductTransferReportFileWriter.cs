using InteliTraderSolutionPlus.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTraderSolutionPlus.Writer
{
    public class ProductTransferReportFileWriter : IReportWriter
    {
        public string Path { get; set; }
        public ProductTransferReport Report { get; set; }
        public ProductTransferReportFileWriter(string path, ProductTransferReport report)
        {
            Path = path;
            Report = report;
        }
        public void Write()
        {
            var reportString = BuildReportString();
            File.WriteAllText(Path, reportString);
        }

        private string BuildReportString()
        {
            var report = new System.Text.StringBuilder();
            report.Append($"{Report.Description}\n\n\n");
            report.Append(String.Format("{0}{1,10}{2,10}{3,10}{4,10}{5,10}{6,10} \n",
                                             "Produto", "QtCO", "QtMin", "QtVendas", "Estq.após", "Necess.", "Transf.de"));
            report.Append(String.Format("{0,44}{1,24}", "Vendas", "Arm p/CO \n"));

            foreach (var reportLine in Report.ProductTransferLine)
            {
                report.Append(String.Format("{0}{1,10}{2,10}{3,10}{4,10}{5,10}{6,10} \n", reportLine.ProductCode, reportLine.Inventory, reportLine.MinInventory,
                    reportLine.SaleSize, reportLine.InventoryAfterSale, reportLine.InventoryDeficit, reportLine.InventoryTransfer));
            }

            return report.ToString();
        }
    }
}

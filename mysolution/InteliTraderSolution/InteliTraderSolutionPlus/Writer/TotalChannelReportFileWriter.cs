using InteliTraderSolutionPlus.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTraderSolutionPlus.Writer
{
    internal class TotalChannelReportFileWriter : IReportWriter
    {
        public string Path { get; set; }
        public TotalChannelReport Report { get; set; }
        public TotalChannelReportFileWriter(string path, TotalChannelReport report)
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
            var report = $"Quantidade de Vendas por canal \n\n" +
                $"Canal                   QtVendas \n" +
                $"1- Representantes       {Report.TotalChannelLine.Representantes} \n" +
                $"2- Website              {Report.TotalChannelLine.Website} \n" +
                $"3- App móvel Android    {Report.TotalChannelLine.AppAndroid} \n" +
                $"4- App mível iPhone     {Report.TotalChannelLine.AppIphone}";

            return report;
        }
    }
}

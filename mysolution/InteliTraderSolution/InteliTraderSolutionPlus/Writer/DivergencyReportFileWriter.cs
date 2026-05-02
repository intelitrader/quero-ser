using InteliTraderSolutionPlus.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTraderSolutionPlus.Writer
{
    public class DivergencyReportFileWriter : IReportWriter
    {
        public string  Path { get; set; }
        public DivergencyReport Report { get; set; }
        public DivergencyReportFileWriter(string path,DivergencyReport report)
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

            var divergencies = new HashSet<string>();
            foreach(var reportLine in Report.DivergencyLines)
            {

                if(reportLine.Error == 999)
                        divergencies.Add($"Linha {reportLine.Line} - Erro desconhecido. Acionar equipe de TI.");
                
                else if (reportLine.Error == 135)
                        divergencies.Add($"Linha {reportLine.Line} - Venda cancelada.");
                
                else if (reportLine.Error == 190)
                        divergencies.Add($"Linha {reportLine.Line} - Venda não finalizada.");

                else if(reportLine.InvalidProductCode == true)
                        divergencies.Add($"Linha {reportLine.Line} - Código de Produto não encontrado { reportLine.ProductCode}.");
            }

            return String.Join("\n", divergencies);
        }
    }
}

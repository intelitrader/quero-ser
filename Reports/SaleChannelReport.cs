using OperationalStorage.Entities;
using OperationalStorage.Entities.Enums;
using System.Text;

namespace OperationalStorage.Reports
{
    public class SaleChannelReport
    {
        public Dictionary<string, int> GetDataReport()
        {
            var salesList = Sales.SalesList;
            
            var dataDictionary = new Dictionary<string, int>();
            dataDictionary["1 - Representantes"] = 0;
            dataDictionary["2 - Website"] = 0;
            dataDictionary["3 - App móvel Android"] = 0;
            dataDictionary["4 - App móvel iPhone"] = 0;

            foreach (var sales in salesList)
            {
                if (sales.Situation == SaleSituation.SaleAndPaymentConfirmed || sales.Situation == SaleSituation.SaleConfirmedPaymentPendent)
                { 
                    if (sales.Channel == SaleChannel.ComercialRepresentant)
                        dataDictionary["1 - Representantes"] += sales.QuantitySold;

                    if (sales.Channel == SaleChannel.Website)
                        dataDictionary["2 - Website"] += sales.QuantitySold;

                    if (sales.Channel == SaleChannel.AndroidMobileApp)
                        dataDictionary["3 - App móvel Android"] += sales.QuantitySold;

                    if (sales.Channel == SaleChannel.IphoneMobileApp)
                        dataDictionary["4 - App móvel iPhone"] += sales.QuantitySold;
                }
            }

            return dataDictionary;
        }

        public string WriteReport(Dictionary<string, int> dict)
        {
            var format = "{0,-25} {1,-20}";
            var report = new StringBuilder();

            report.AppendLine("Quantidades de Vendas por canal\n");
            report.AppendFormat(format, "Canal", "QntVendas");
            report.AppendLine("");

            foreach (var item in dict)
            {
                report.AppendFormat(format.TrimEnd(), $"{item.Key}", $"{item.Value}");;
                report.AppendLine();
            }
            return report.ToString();
        }

        public void SaveReport(string report)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "TOTCANAL.txt";
            
            if (File.Exists(path))
                File.Delete(path);

            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine(report.Trim());
            }
        }

        public void GenerateReport()
        {
           var data = GetDataReport();
           var report = WriteReport(data);
           SaveReport(report);
        }
    }
}

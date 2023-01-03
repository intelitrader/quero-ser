using OperationalStorage.Entities;
using OperationalStorage.Entities.Enums;
using System.Text;

namespace OperationalStorage.Reports
{

    public class DivergencyReport
    {
        public List<string> GetDivergency()
        {
            var saleList = Sales.SalesList;
            var productCodes = GetProductsCode();
            var messages = new List<string>();

            for (int i = 0; i < saleList.Count; i++)
            {
                var sale = saleList[i];

                if(sale.Situation == SaleSituation.ErrorUnindentified)
                {
                    messages.Add($"Linha {i + 1} - Erro desconhecido. Acionar equipe de TI");
                }
                else 
                { 
                    if (sale.Situation == SaleSituation.UnfinishedSale)
                        messages.Add($"Linha {i + 1} - Venda não finalizada");

                    if (sale.Situation == SaleSituation.SaleCancelled)
                        messages.Add($"Linha {i + 1} - Venda cancelada");

                    if (!productCodes.Contains(sale.ProductCode))
                        messages.Add($"Linha {i + 1} - Código de Produto não encontrado {sale.ProductCode}");
                }
            }
            return messages;
        }

        private List<int> GetProductsCode()
        {
            var codes = new List<int>();

            foreach(var product in Storage.ProductsList)
                codes.Add(product.Code);

            return codes;
        }

        private string WriteReport(List<string> messages)
        {
            var report = new StringBuilder();
            foreach (var message in messages)
            {
                report.AppendLine(message);
            }

            return report.ToString();
        }

        private void SaveReport(string report)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "DIVERGENCIA.txt";

            if (File.Exists(path))
                File.Delete(path);

            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine(report);
            }
        }

        public void GenerateReport()
        {
            var data = GetDivergency();
            var report = WriteReport(data);
            SaveReport(report);
        }
    }
}
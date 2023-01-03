using OperationalStorage.Entities;
using OperationalStorage.Entities.Enums;
using System.Text;

namespace OperationalStorage.Reports
{

    public class TransferencyReport
    {
        private int ProductCode { get; set; }
        private int QuantityOnCO { get; set; }
        private int MinimumQuantity { get; set; }
        private int SoldQuantity { get; set; }
        private int StockAfterSale { get; set; }
        private int QuantityRequired { get; set; }
        private int QuantityToTransferToCO { get; set; }

        private List<TransferencyReport> DataReport = new List<TransferencyReport>();

        private void GetDataReport()
        {
            var stockList = Storage.ProductsList;
            var salesOnCorrectSituation = GetSaleStatus100And102();

            foreach (var stockItem in stockList)
            {
                var productCode = stockItem.Code;
                var quantityPerItem = stockItem.Quantity;
                var minimumQuantiy = stockItem.MininumQuantity;

                var soldQuantity = 0;
                var qntRequired = 0;
                var transferToCO = 0;

                foreach (var saleItem in salesOnCorrectSituation)
                {
                    if (saleItem.ProductCode == stockItem.Code)
                    {
                        soldQuantity += saleItem.QuantitySold;
                    }
                }

                var storageAfterSale = quantityPerItem - soldQuantity;
                if(storageAfterSale < minimumQuantiy)
                {
                    qntRequired = (minimumQuantiy - storageAfterSale);
                }

                if(qntRequired > 0 && qntRequired < 10)
                {
                    transferToCO = 10;
                }
                else    
                {
                    transferToCO = qntRequired;
                }

                DataReport.Add(new TransferencyReport
                {
                    ProductCode = productCode,
                    QuantityOnCO = quantityPerItem,
                    MinimumQuantity = minimumQuantiy,
                    SoldQuantity = soldQuantity,
                    StockAfterSale = storageAfterSale,
                    QuantityRequired = qntRequired,
                    QuantityToTransferToCO = transferToCO
                });
            }
        }

        private List<Sale> GetSaleStatus100And102()
        {
            var list = new List<Sale>();

            foreach (var sale in Sales.SalesList)
            {
                if (sale.Situation == SaleSituation.SaleAndPaymentConfirmed
                    || sale.Situation == SaleSituation.SaleConfirmedPaymentPendent)
                { 
                    list.Add(sale);
                }
            }
            return list;
        }

        private string WriteReport()
        {
            var dataReceived = this.DataReport;
            var report = new StringBuilder();
            report.AppendLine("Necessidade de Transferência Armazém para CO");
            report.AppendLine();
            report.AppendLine("Produto\tQtCO\tQtMin\tQtVendas\tEstq.após Vendas\tNecess.\tTrans. de Arm. p / CO");
            foreach(var info in dataReceived)
            {
                report.Append(info.ProductCode + "\t\t");
                report.Append(info.QuantityOnCO + "\t");
                report.Append(info.MinimumQuantity + "\t");
                report.Append(info.SoldQuantity + "\t\t");
                report.Append(info.StockAfterSale + "\t\t\t");
                report.Append(info.QuantityRequired + "\t\t");
                report.Append(info.QuantityToTransferToCO);
                report.AppendLine();
            }

            return report.ToString();
        }

        private void SaveReport(string report)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "TRANSFERE.txt";

            if (File.Exists(path))
                File.Delete(path);

            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine(report);
            }
        }


        public void GenerateReport()
        {
            GetDataReport();
            var report = WriteReport();
            SaveReport(report);
        }
    }
}
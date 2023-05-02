using System.Text;
using quero_ser.model;

namespace quero_ser.repositories.implementation
{
    public class ReportsTransfersRepository : IReportsTranfersRepository
    {
        public void CreateFileTransfer(string filePath, List<Transfer> transferList)
        {
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8, bufferSize: 1024);
            sw.WriteLine("Necessidade de Transferência Armazém para CO");
            sw.WriteLine("");
            sw.WriteLine("Produto".PadRight(9) + "QtCO".PadRight(6) + "QtMin".PadRight(7) + "QtVendas".PadRight(10) + "Estq.após".PadRight(11) + "Necess.".PadRight(9) + "Transf. de".PadRight(10));
            sw.WriteLine("".PadLeft(35) + "Vendas".PadRight(18) + "Arm p/ CO");

            foreach (var transfer in transferList)
            {
                sw.WriteLine($"{transfer.product}".PadRight(9) + $"{transfer.QuantityOperationsCenter}".PadLeft(4) + $"{transfer.minimumAmount}".PadLeft(7) + $"{transfer.quantitySold}".PadLeft(10) + $"{transfer.stockAfterSale}".PadLeft(11) + $"{transfer.replacement}".PadLeft(9) + $"{transfer.transferToOperationsCenter}".PadLeft(12));
            }
            sw.Flush();
            sw.Close();
        }

        public List<Sale> FilterProductsSales(Product product, List<Sale> salesList)
        {
            List<Sale> filterProductsSales = salesList.Where(sale => product.productCode == sale.productCode && (sale.saleSituation == 100 || sale.saleSituation == 102)).ToList();

            return filterProductsSales;
        }

        public int TotalProductSales(List<Sale> productSaleList)
        {
            int totalProductSales = productSaleList.Sum(sale => sale.quantitySale);

            return totalProductSales;
        }
    }
}
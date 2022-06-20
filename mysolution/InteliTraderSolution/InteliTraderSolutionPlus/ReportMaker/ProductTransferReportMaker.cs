using InteliTraderSolutionPlus.Models;
using InteliTraderSolutionPlus.Models.Reports;

namespace InteliTraderSolutionPlus.ReportMaker
{
    public class ProductTransferReportMaker
    {

        public static ProductTransferReport Make(IEnumerable<Product> products, IEnumerable<Sale> sales)
        {
            return new ProductTransferReport()
            {
                Description = "Necessidade de Transferência Armazém para CO.",
                ProductTransferLine = Report(products, sales)
            };

        }

        public static IEnumerable<ProductTransferLine> Report(IEnumerable<Product> products, IEnumerable<Sale> sales)
        {
            var reportList = new List<ProductTransferLine>();
            var salesFilter = SalesCompact(SalesFilter(products, sales));
            foreach (var s in salesFilter)
            {
                var product = products.First(p => p.ProductCode == s.ProductCode);

                reportList.Add(new ProductTransferLine()
                {
                    ProductCode = product.ProductCode,
                    Inventory = product.Inventory,
                    MinInventory = product.MinInventory,
                    SaleSize = s.Size,
                    InventoryAfterSale = product.Inventory - s.Size,
                    InventoryDeficit = InventoryDeficitCalculation((product.Inventory - s.Size), product.MinInventory),
                    InventoryTransfer = InventoryNecessityCalculation(InventoryDeficitCalculation((product.Inventory - s.Size), product.MinInventory))

                });
            }


            return reportList.OrderBy(r => r.ProductCode);
        }



        public static IEnumerable<Sale> SalesFilter(IEnumerable<Product> products, IEnumerable<Sale> sales)
        {

            var existFilter = ProductExistsCheck(products, sales);

            var statusFilter = existFilter.Where(s => s.Status == 100 ||
                                                 s.Status == 102);
            return statusFilter;
        }
        public static IEnumerable<Sale> ProductExistsCheck(IEnumerable<Product> products, IEnumerable<Sale> sales)
        {

            var exist = from s in sales
                        from p in products
                        where s.ProductCode == p.ProductCode
                        select s;
            return sales.Where(s => products.Any(p => p.ProductCode == s.ProductCode));

        }

        public static List<Sale> SalesCompact(IEnumerable<Sale> data)
        {
            var productCode = new List<int>();
            var saleCompact = new List<Sale>();

            foreach (var s in data)
            {
                var verifyIfCodeIsValid = productCode.FirstOrDefault(p => p == s.ProductCode);

                if (verifyIfCodeIsValid != 0)
                {
                    var saleToUpdate = saleCompact.First(x => x.ProductCode == s.ProductCode);
                    saleToUpdate.Size += s.Size;
                }
                else
                {
                    productCode.Add(s.ProductCode);
                    saleCompact.Add(new Sale()
                    {
                        ProductCode = s.ProductCode,
                        Size = s.Size,
                        Channel = s.Channel,
                        Status = s.Status,
                        LineNumber = s.LineNumber
                    });
                }
            }
            return saleCompact;
        }
        private static int InventoryDeficitCalculation(int inventoryAfterSale, int minInventory)
        {
            if (inventoryAfterSale < minInventory) return minInventory - inventoryAfterSale;
            return 0;
        }

        private static int InventoryNecessityCalculation(int deficit)
        {
            if (deficit > 0 && deficit < 10) return 10;
            return deficit;
        }

    }
}

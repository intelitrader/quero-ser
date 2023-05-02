using quero_ser.model;
using quero_ser.repositories;

namespace quero_ser.useCase.generateTransferReport
{
    public class GenerateTransferReportUseCase
    {
        private readonly IReportsTranfersRepository _reportsTranfersRepository;

        public GenerateTransferReportUseCase(IReportsTranfersRepository reportsTranfersRepository)
        {
            _reportsTranfersRepository = reportsTranfersRepository;
        }
        public void execute(List<Sale> salesList, List<Product> productsList, string pathFolder, string folderName)
        {

            string createNameFile = $"transfere.txt";
            string filePathSave = $"{pathFolder}/{folderName}/{createNameFile}";

            List<Transfer> transfersList = new List<Transfer>();

            foreach (Product product in productsList)
            {
                List<Sale> filterProductsSales = _reportsTranfersRepository.FilterProductsSales(product, salesList);
                int totalProductSales = _reportsTranfersRepository.TotalProductSales(filterProductsSales);

                int stockAfterSale = product.quantityInStockBeginningPeriod - totalProductSales;
                int stockReplenishmentNeeded = stockAfterSale - product.minStockCenterOperation;
                int replenishmentQuantity = stockReplenishmentNeeded >= 0 ? 0 : Math.Abs(stockReplenishmentNeeded);
                int transferToOperationsCenter = replenishmentQuantity >= 1 && replenishmentQuantity <= 10 ? 10 : replenishmentQuantity;

                Transfer newTransfer = new Transfer()
                {
                    product = product.productCode,
                    QuantityOperationsCenter = product.quantityInStockBeginningPeriod,
                    minimumAmount = product.minStockCenterOperation,
                    quantitySold = totalProductSales,
                    stockAfterSale = stockAfterSale,
                    replacement = replenishmentQuantity,
                    transferToOperationsCenter = transferToOperationsCenter
                };

                transfersList.Add(newTransfer);
            }

            _reportsTranfersRepository.CreateFileTransfer(filePathSave, transfersList);

        }
    }
}
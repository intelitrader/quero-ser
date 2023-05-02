using quero_ser.model;

namespace quero_ser.repositories
{
    public interface IReportsTranfersRepository
    {
        public void CreateFileTransfer(string filePath, List<Transfer> transferList);
        public List<Sale> FilterProductsSales(Product product, List<Sale> salesList);
        public int TotalProductSales(List<Sale> productSaleList);

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quero_ser.model;

namespace quero_ser.repositories
{
    public interface IReportsTranfersRepository
    {
        public List<Sale> FilterProductsSales(Product product, List<Sale> salesList);
        public int TotalProductSales(List<Sale> productSaleList);

    }
}
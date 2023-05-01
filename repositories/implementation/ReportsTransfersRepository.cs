using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quero_ser.model;

namespace quero_ser.repositories.implementation
{
    public class ReportsTransfersRepository : IReportsTranfersRepository
    {
        public List<Sale> FilterProductsSales(Product product, List<Sale> salesList)
        {
            List<Sale> filterProductsSales = salesList.Where(sale => product.productCode == sale.productCode && (sale.saleSituation == 100 || sale.saleSituation == 102)).ToList();

            return filterProductsSales;
        }
    }
}
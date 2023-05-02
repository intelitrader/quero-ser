using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quero_ser.model;

namespace quero_ser.repositories
{
    public interface IReportsChannelsRepository
    {
        public int TotalSalesRepresentativeQuantities(List<Sale> salesList);
        public int TotalSalesWebSiteQuantities(List<Sale> salesList);
        public int TotalSalesAndroidMobileQuantities(List<Sale> salesList);
        public int TotalSalesIphoneMobileQuantities(List<Sale> salesList);
        public Task CreateFile(string filePath, int totalSalesRepresentative, int totalSalesWebSite, int totalSalesAndroid, int totalSalesIPhone);

    }
}
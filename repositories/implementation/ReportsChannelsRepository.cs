using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quero_ser.model;

namespace quero_ser.repositories.implementation
{
    public class ReportsChannelsRepository : IReportsChannelsRepository
    {
        public async Task CreateFile(string filePath, int totalSalesRepresentative, int totalSalesWebSite, int totalSalesAndroid, int totalSalesIPhone)
        {
            await Task.Run(() =>
            {
                StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8, bufferSize: 1024);

                sw.WriteLine("Quantidades de Vendas por canal".PadRight(40));
                sw.WriteLine();
                sw.WriteLine("Canal".PadRight(23) + "QtVendas");
                sw.WriteLine("1 - Representantes".PadRight(20) + $"{totalSalesRepresentative}".PadLeft(11));
                sw.WriteLine("2 - Website".PadRight(20) + $"{totalSalesWebSite}".PadLeft(11));
                sw.WriteLine("3 - App móvel Android".PadRight(20) + $"{totalSalesAndroid}".PadLeft(10));
                sw.WriteLine("4 - App móvel iPhone".PadRight(20) + $"{totalSalesIPhone}".PadLeft(11));
                sw.Flush();
                sw.Close();
            });


        }

        public int TotalSalesAndroidMobileQuantities(List<Sale> salesList)
        {
            int sum = 0;

            foreach (var sale in salesList)
            {
                if (sale.saleChannel == 3 && (sale.saleSituation == 100 || sale.saleSituation == 102))
                {
                    sum += sale.quantitySale;
                }
            }

            return sum;

        }

        public int TotalSalesIphoneMobileQuantities(List<Sale> salesList)
        {
            int sum = 0;

            var filterSalesChannel = salesList.Where(sale => sale.saleChannel == 4 && (sale.saleSituation == 100 || sale.saleSituation == 102));
            foreach (var item in filterSalesChannel)
            {
                sum += item.quantitySale;
            }

            return sum;
        }

        public int TotalSalesRepresentativeQuantities(List<Sale> salesList)
        {
            int sum = 0;

            var filterSalesChannel = salesList.Where(sale => sale.saleChannel == 1 && (sale.saleSituation == 100 || sale.saleSituation == 102));
            sum = filterSalesChannel.Sum(sale => sale.quantitySale);
            return sum;
        }

        public int TotalSalesWebSiteQuantities(List<Sale> salesList)
        {
            int sum = 0;

            foreach (var sale in salesList)
            {
                if (sale.saleChannel == 2 && (sale.saleSituation == 100 || sale.saleSituation == 102))
                {
                    sum += sale.quantitySale;
                }
            }

            return sum;
        }
    }
}
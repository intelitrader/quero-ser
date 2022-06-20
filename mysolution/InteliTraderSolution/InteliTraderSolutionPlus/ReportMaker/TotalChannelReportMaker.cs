using InteliTraderSolutionPlus.Models;
using InteliTraderSolutionPlus.Models.Reports;

namespace InteliTraderSolutionPlus.ReportMaker
{
    public class TotalChannelReportMaker
    {

        public static TotalChannelReport Make(IEnumerable<Product> products, IEnumerable<Sale> sales)
        {
            return new TotalChannelReport()
            {
                Description = "Total de vendas por canal.",
                TotalChannelLine = Report(products, sales)
            };

        }

        public static TotalChannelLine Report(IEnumerable<Product> products, IEnumerable<Sale> sales)
        {
            var salesFilter = SellsPerChannelCount(products, sales);

            return new TotalChannelLine()
            {
                Representantes = salesFilter[0],
                Website = salesFilter[1],
                AppAndroid = salesFilter[2],
                AppIphone = salesFilter[3]
            };
        }

        public static List<int> SellsPerChannelCount(IEnumerable<Product> products, IEnumerable<Sale> sales)
        {
            var sellsPerChannel = new List<int>();
            for (int i = 1; i <= 4; i++)
            {
                var sells = from s in sales
                            where s.Channel == i && (s.Status == 100 || s.Status == 102)
                            select s;
                var count = 0;
                foreach (var sell in sells)
                {
                    count += sell.Size;
                }
                sellsPerChannel.Add(count);

            }
            return sellsPerChannel;
        }



    }
}

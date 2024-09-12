using InteliTraderSolutionPlus.Models;
using InteliTraderSolutionPlus.Models.Reports;

namespace InteliTraderSolutionPlus.ReportMaker
{
    public class DivergencyReportMaker
    {

        public static DivergencyReport Make(IEnumerable<Product> products, IEnumerable<Sale> sales)
        {
            return new DivergencyReport()
            {
                DivergencyLines = Report(products, sales)
            };

        }

        public static IEnumerable<DivergencyLine> Report(IEnumerable<Product> products, IEnumerable<Sale> sales)
        {
            var reportList = new List<DivergencyLine>();
            var invalidCode = InvalidProductCode(products, sales);
            var cancelStatus = CanceldSalesStatus(sales);
            var notFinishedStatus = NotFinishedSalesStatus(sales);
            var error = ErrorStatus(sales);

            foreach(var i in invalidCode)
            {
                reportList.Add(new DivergencyLine()
                {
                    Line = i.LineNumber,
                    Error = i.Status,
                    ProductCode = i.ProductCode,
                    InvalidProductCode = true

                });
            }

            foreach(var i in cancelStatus)
            {
                reportList.Add(new DivergencyLine()
                {
                    Line = i.LineNumber,
                    Error = i.Status,
                    ProductCode = i.ProductCode
                });
            }


            foreach (var i in notFinishedStatus)
            {
                reportList.Add(new DivergencyLine()
                {
                    Line = i.LineNumber,
                    Error = i.Status,
                    ProductCode = i.ProductCode
                });
            }


            foreach (var i in error)
            {
                reportList.Add(new DivergencyLine()
                {
                    Line = i.LineNumber,
                    Error = i.Status,
                    ProductCode = i.ProductCode
                });
            }

            reportList = reportList.OrderBy(x => x.Line).ToList();
            return reportList;

        }

        public static IEnumerable<Sale> InvalidProductCode(IEnumerable<Product> products, IEnumerable<Sale> sales)
        {
            var exist = from s in sales
                        from p in products
                        where s.ProductCode == p.ProductCode
                        select s;
            return sales.Except(exist);
        }

        public static IEnumerable<Sale> CanceldSalesStatus(IEnumerable<Sale> sales)
        {


           return   from s in sales
                    where s.Status == 135
                    select s;

        }

        public static IEnumerable<Sale> NotFinishedSalesStatus(IEnumerable<Sale> sales)
        {


            return from s in sales
                   where s.Status == 190
                   select s;
        }

        public static IEnumerable<Sale> ErrorStatus(IEnumerable<Sale> sales)
        {


            return from s in sales
                   where s.Status == 999
                   select s;
        }
    }
}

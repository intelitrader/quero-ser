using OperationalStorage.Processors;
using OperationalStorage.Reports;

namespace OperationalStorage
{
    public class Program
    {
        static void Main(string[] args)
        {
            var productsInput = args[0];
            var salesInput = args[1];
            var storageProcessor = new StorageProcessor(productsInput);
            var salesProcessor = new SaleProcessor(salesInput);
            
            var report = new DivergencyReport();
            report.GenerateReport();

            var report2 = new SaleChannelReport();
            report2.GenerateReport();

            var report3 = new TransferencyReport();
            report3.GenerateReport();
        }
    }
}

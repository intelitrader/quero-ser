using InteliTraderSolutionPlus.Models;

namespace InteliTraderSolution.Reader
{
    internal class SaleFileReader : ISaleReader
    {
        public string Path { get; set; }
        public SaleFileReader(string path)
        {
            Path = path;
        }
        public IEnumerable<Sale> Read()
        {
            var rawData = File.ReadAllLines(@$"{Path}\vendas.txt");
            var sales = new List<Sale>();

            var lineNumer = 1;
            foreach (var item in rawData)
            {
                var data = item.Split(';').Select(d => int.Parse(d)).ToList();
                sales.Add(new Sale()
                {
                    ProductCode = data[0],
                    Size = data[1],
                    Status = data[2],
                    Channel = data[3],
                    LineNumber = lineNumer++
                }); 
            }
            return sales;
        }
    }
}
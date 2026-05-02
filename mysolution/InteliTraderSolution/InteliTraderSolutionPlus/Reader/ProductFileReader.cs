using InteliTraderSolutionPlus.Models;

namespace InteliTraderSolution.Reader
{
    public class ProductFileReader : IProductReader
    {
        public string Path { get; set; }
        public ProductFileReader(string path)
        {
            Path = path;
        }
        public IEnumerable<Product> Read()
        { 
            var rawData = File.ReadAllLines(@$"{Path}\produtos.txt");
            return ObjectMaker(rawData);
        }

        private static IEnumerable<Product> ObjectMaker(string[] rawData)
        {
            var products = new List<Product>();


            foreach (var item in rawData)
            {
                var data = item.Split(';').Select(d => int.Parse(d)).ToList();
                products.Add(new Product()
                {
                    ProductCode = data[0],
                    Inventory = data[1],
                    MinInventory = data[2]
                });
            }
            return products;
        }
    }
}
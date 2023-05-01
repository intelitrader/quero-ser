using quero_ser.model;

namespace quero_ser.repositories.implementation
{
    public class ProductsRepository : IProductsRepository
    {
        public string[] ReadFile(string pathFile)
        {
            string[] lines = File.ReadAllLines(pathFile);

            return lines;
        }
        public List<Product> FormatProductListFile(string[] lines)
        {
            List<Product> productsList = new List<Product> { };
            foreach (string line in lines)
            {
                string[] formatLine = line.Split(';');

                Product newProduct = new Product()
                {
                    productCode = uint.Parse(formatLine[0]),
                    quantityInStockBeginningPeriod = int.Parse(formatLine[1]),
                    minStockCenterOperation = int.Parse(formatLine[2]),
                };

                productsList.Add(newProduct);
            }
            return productsList;
        }
    }
}
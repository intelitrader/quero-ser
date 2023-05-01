namespace quero_ser.repositories.implementation
{
    public class ProductsRepository : IProductsRepository
    {
        public string[] ReadFile(string pathFile)
        {
            string[] lines = File.ReadAllLines(pathFile);

            return lines;
        }
    }
}
using OperationalStorage.Entities;

namespace OperationalStorage.Processors
{
    public class StorageProcessor : BaseProcessor
    {
        public StorageProcessor(string path) : base(path)
        { 
            AddProductsToStorage();
        }

        protected void AddProductsToStorage()
        {
            string[] productsLines = File.ReadAllLines(this.Path);
            for (int i = 0; i < productsLines.Length; i++)
            {
                string[] rows = productsLines[i].Split(';');
                var product = new Product(int.Parse(rows[0]), int.Parse(rows[1]), int.Parse(rows[2]));
                Storage.ProductsList.Add(product);
            }
        }
    }
}

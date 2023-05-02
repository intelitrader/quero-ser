using quero_ser.model;

namespace quero_ser.repositories.implementation
{
    public class SalesRepository : ISalesRepository
    {
        public List<Sale> FormatSaleListFile(string[] lines)
        {
            List<Sale> _salesList = new List<Sale> { };

            foreach (string line in lines)
            {
                string[] formatLine = line.Split(';');

                var newProduct = new Sale()
                {
                    productCode = uint.Parse(formatLine[0]),
                    quantitySale = int.Parse(formatLine[1]),
                    saleSituation = int.Parse(formatLine[2]),
                    saleChannel = int.Parse(formatLine[3])
                };

                _salesList.Add(newProduct);
            }

            return _salesList;
        }

        public string[] ReadFile(string pathFile)
        {
            string[] lines = File.ReadAllLines(pathFile);

            return lines;
        }
    }
}
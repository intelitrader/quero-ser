using quero_ser.model;

namespace quero_ser.repositories
{
    public interface ISalesRepository
    {
        public string[] ReadFile(string pathFile);
        public List<Sale> FormatSaleListFile(string[] lines);
    }
}
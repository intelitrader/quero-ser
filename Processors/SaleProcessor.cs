using OperationalStorage.Entities.Enums;
using OperationalStorage.Entities;

namespace OperationalStorage.Processors
{
    public class SaleProcessor : BaseProcessor
    {
        public SaleProcessor(string path) : base(path)
        {
            AddSalesAtList();
        }

        private void AddSalesAtList()
        {
            string[] salesLines = File.ReadAllLines(this.Path);

            for (int i = 0; i < salesLines.Length; i++)
            {
                string[] rows = salesLines[i].Split(';');

                var sale = new Sale(
                    int.Parse(rows[0]),
                    int.Parse(rows[1]),
                    (SaleSituation)int.Parse(rows[2]),
                    (SaleChannel)int.Parse(rows[3])
                );

                Sales.SalesList.Add(sale);
            }
        }


    }
}

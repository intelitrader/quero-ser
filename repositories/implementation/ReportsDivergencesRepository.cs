using System.Text;
using quero_ser.model;

namespace quero_ser.repositories.implementation
{
    public class ReportsDivergencesRepository : IReportsDivergencesRepository
    {
        public void CreateFileDivergences(string filePath, List<Divergence> divergencesList)
        {
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8, bufferSize: 1024);

            foreach (var divergence in divergencesList)
            {
                sw.WriteLine($"Linha {divergence.numberLine} - {divergence.message}");
            }
            sw.Flush();
            sw.Close();
        }

        public List<Divergence> FilterCanceledSales(List<Product> productsList, Sale sale, int line)
        {
            List<Divergence> canceledSalesList = new List<Divergence>();

            if (sale.saleSituation == 135)
            {
                Divergence divergence = new Divergence()
                {
                    numberLine = line + 1,
                    message = "Venda cancelada"
                };

                canceledSalesList.Add(divergence);
            }
            return canceledSalesList;
        }

        public List<Divergence> FilterIncompleteSales(List<Product> productsList, Sale sale, int line)
        {
            List<Divergence> IncompleteSalesList = new List<Divergence>();

            if (sale.saleSituation == 190)
            {
                Divergence divergence = new Divergence()
                {
                    numberLine = line + 1,
                    message = "Venda não finalizada"
                };

                IncompleteSalesList.Add(divergence);
            }

            return IncompleteSalesList;

        }

        public List<Divergence> FilterNotFoundProducts(List<Product> productsList, Sale sale, int line)
        {
            List<Divergence> notFoundProductsList = new List<Divergence>();

            var productContainInList = productsList.Find(product => product.productCode == sale.productCode);

            if (productContainInList == null && sale.saleSituation != 999)
            {

                Divergence divergence = new Divergence()
                {
                    numberLine = line + 1,
                    message = $"Código de Produto não encontrado {sale.productCode}"
                };

                notFoundProductsList.Add(divergence);
            }
            return notFoundProductsList;
        }

        public List<Divergence> FilterUnknownErrors(List<Product> productsList, Sale sale, int line)
        {

            List<Divergence> UnknownErrorsList = new List<Divergence>();

            if (sale.saleSituation == 999)
            {
                Divergence divergence = new Divergence()
                {
                    numberLine = line + 1,
                    message = "Erro desconhecido. Acionar equipe de TI"
                };

                UnknownErrorsList.Add(divergence);

            }

            return UnknownErrorsList;

        }
    }
}
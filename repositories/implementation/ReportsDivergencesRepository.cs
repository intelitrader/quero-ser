using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quero_ser.model;

namespace quero_ser.repositories.implementation
{
    public class ReportsDivergencesRepository : IReportsDivergencesRepository
    {
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quero_ser.model;

namespace quero_ser.repositories
{
    public interface IReportsDivergencesRepository
    {
        List<Divergence> FilterNotFoundProducts(List<Product> productsList, Sale sale, int line);
        List<Divergence> FilterCanceledSales(List<Product> productsList, Sale sale, int line);
        List<Divergence> FilterIncompleteSales(List<Product> productsList, Sale sale, int line);
        List<Divergence> FilterUnknownErrors(List<Product> productsList, Sale sale, int line);
        void CreateFileDivergences(string filePath, List<Divergence> divergencesList);

    }
}
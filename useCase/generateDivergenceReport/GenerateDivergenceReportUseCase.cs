using quero_ser.model;
using quero_ser.repositories;

namespace quero_ser.useCase.generateDivergenceReport
{
    public class GenerateDivergenceReportUseCase
    {
        private readonly IReportsDivergencesRepository _reportsDivergencesRepository;

        public GenerateDivergenceReportUseCase(IReportsDivergencesRepository reportsDivergencesRepository)
        {
            _reportsDivergencesRepository = reportsDivergencesRepository;
        }

        public void execute(List<Sale> salesList, List<Product> productsList, string pathFolder, string folderName)
        {
            string createNameFile = "DIVERGENCIAS.txt";
            string filePathSave = $"{pathFolder}/{folderName}/{createNameFile}";

            List<Divergence> divergencesList = new List<Divergence>();

            for (int i = 0; i < salesList.Count; i++)
            {
                divergencesList.AddRange(_reportsDivergencesRepository.FilterNotFoundProducts(productsList, salesList[i], i));
                divergencesList.AddRange(_reportsDivergencesRepository.FilterCanceledSales(productsList, salesList[i], i));
                divergencesList.AddRange(_reportsDivergencesRepository.FilterIncompleteSales(productsList, salesList[i], i));
                divergencesList.AddRange(_reportsDivergencesRepository.FilterUnknownErrors(productsList, salesList[i], i));
            }

            divergencesList.OrderBy(divergence => divergence.numberLine).ToList();

            _reportsDivergencesRepository.CreateFileDivergences(filePathSave, divergencesList);

        }
    }
}
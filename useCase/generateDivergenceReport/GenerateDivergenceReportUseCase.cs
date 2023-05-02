using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            Console.WriteLine("GenerateDivergenceReportUseCase");
        }
    }
}
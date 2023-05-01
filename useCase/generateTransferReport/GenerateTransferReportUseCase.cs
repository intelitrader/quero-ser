using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quero_ser.model;
using quero_ser.repositories;

namespace quero_ser.useCase.generateTransferReport
{
    public class GenerateTransferReportUseCase
    {
        private readonly IReportsTranfersRepository _reportsTranfersRepository;

        public GenerateTransferReportUseCase(IReportsTranfersRepository reportsTranfersRepository)
        {
            _reportsTranfersRepository = reportsTranfersRepository;
        }
        public void execute(List<Sale> salesList, List<Product> productsList, string pathFolder, string folderName)
        {

            string createNameFile = $"transfere.txt";
            string filePathSave = $"{pathFolder}/{folderName}/{createNameFile}";

            Console.WriteLine("GenerateTransferReportUseCase");
        }
    }
}
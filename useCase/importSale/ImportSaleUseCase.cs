using quero_ser.model;
using quero_ser.repositories;

namespace quero_ser.useCase.importSale
{
    public class ImportSaleUseCase
    {
        private readonly ISalesRepository _salesRepository;
        public ImportSaleUseCase(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }
        public List<Sale> execute(string pathFolder, string folderName)
        {

            string numberFile = folderName.Split(' ').Last();
            string filePath = $"{pathFolder}/{folderName}/c{numberFile}_vendas.txt";

            string[] lines = _salesRepository.ReadFile(filePath);

            List<Sale> formatSalesList = _salesRepository.FormatSaleListFile(lines);


            return formatSalesList;

        }
    }
}
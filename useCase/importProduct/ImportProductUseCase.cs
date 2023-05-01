using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quero_ser.model;
using quero_ser.repositories;

namespace quero_ser.useCase.importProduct
{
    public class ImportProductUseCase
    {
        private readonly IProductsRepository _productsRepository;

        public ImportProductUseCase(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public List<Product> execute(string pathFolder, string folderName)
        {

            string numberFile = folderName.Split(' ').Last();
            string filePath = $"{pathFolder}/{folderName}/c{numberFile}_produtos.txt";

            string[] lines = _productsRepository.ReadFile(filePath);

            List<Product> formatProductsList = _productsRepository.FormatProductListFile(lines);

            return formatProductsList;

        }
    }
}
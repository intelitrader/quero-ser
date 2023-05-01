
using Microsoft.Extensions.DependencyInjection;
using quero_ser.model;
using quero_ser.repositories;
using quero_ser.repositories.implementation;
using quero_ser.useCase.importProduct;
using quero_ser.useCase.importSale;

namespace quero_ser_master;

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
        // Produtos
        .AddScoped<IProductsRepository, ProductsRepository>()
        .AddScoped<ImportProductUseCase>()

        // Vendas
        .AddScoped<ISalesRepository, SalesRepository>()
        .AddScoped<ImportSaleUseCase>()

        .BuildServiceProvider();

        ImportProductUseCase importProductUseCase = serviceProvider.GetService<ImportProductUseCase>()!;

        ImportSaleUseCase importSaleUseCase = serviceProvider.GetService<ImportSaleUseCase>()!;

        string diretorios = $"{System.Environment.CurrentDirectory}/Desafio";
        string[] files = Directory.GetDirectories(diretorios);

        for (int i = 0; i < files.Length; i++)
        {
            if (files[i].Contains("Caso"))
            {
                string nameFile = Path.GetFileName(files[i]);

                List<Product> productsList = importProductUseCase.execute(diretorios, nameFile);

                List<Sale> salesList = importSaleUseCase.execute(diretorios, nameFile);

            }

        }
    }
}
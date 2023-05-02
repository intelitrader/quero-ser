
using Microsoft.Extensions.DependencyInjection;
using quero_ser.model;
using quero_ser.repositories;
using quero_ser.repositories.implementation;
using quero_ser.useCase.generateChannelReport;
using quero_ser.useCase.generateDivergenceReport;
using quero_ser.useCase.generateTransferReport;
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

        // relatorios de transferencia
        .AddScoped<IReportsTranfersRepository, ReportsTransfersRepository>()
        .AddScoped<GenerateTransferReportUseCase>()

        // relatorios de divergencia
        .AddScoped<IReportsDivergencesRepository, ReportsDivergencesRepository>()
        .AddScoped<GenerateDivergenceReportUseCase>()

        // relatorios de vendas
        .AddScoped<IReportsChannelsRepository, ReportsChannelsRepository>()
        .AddScoped<GenerateChannelReportUseCase>()

        .BuildServiceProvider();

        ImportProductUseCase importProductUseCase = serviceProvider.GetService<ImportProductUseCase>()!;

        ImportSaleUseCase importSaleUseCase = serviceProvider.GetService<ImportSaleUseCase>()!;

        GenerateTransferReportUseCase generateTransferReportUseCase = serviceProvider.GetService<GenerateTransferReportUseCase>()!;

        GenerateDivergenceReportUseCase generateDivergenceReportUseCase = serviceProvider.GetService<GenerateDivergenceReportUseCase>()!;

        GenerateChannelReportUseCase reportChannelsRepository = serviceProvider.GetService<GenerateChannelReportUseCase>()!;

        string diretorios = $"{System.Environment.CurrentDirectory}/Desafio";
        string[] files = Directory.GetDirectories(diretorios);

        for (int i = 0; i < files.Length; i++)
        {
            if (files[i].Contains("Caso"))
            {
                string nameFile = Path.GetFileName(files[i]);

                List<Product> productsList = importProductUseCase.execute(diretorios, nameFile);

                List<Sale> salesList = importSaleUseCase.execute(diretorios, nameFile);

                generateTransferReportUseCase.execute(salesList, productsList, diretorios, nameFile);

                generateDivergenceReportUseCase.execute(salesList, productsList, diretorios, nameFile);

                reportChannelsRepository.execute(salesList, diretorios, nameFile);

            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quero_ser.model;
using quero_ser.repositories;

namespace quero_ser.useCase.generateChannelReport
{
    public class GenerateChannelReportUseCase
    {
        private readonly IReportsChannelsRepository _reportsChannelsRepository;

        public GenerateChannelReportUseCase(IReportsChannelsRepository reportsChannelsRepository)
        {
            _reportsChannelsRepository = reportsChannelsRepository;
        }

        public void execute(List<Sale> saleList, string pathFolder, string folderName)
        {
            string createNameFile = $"TOTCANAIS.txt";
            string filePathSave = $"{pathFolder}/{folderName}/{createNameFile}";

            int totalSaleRepresentative = _reportsChannelsRepository.TotalSalesRepresentativeQuantities(saleList);

            int totalSalesWebSite = _reportsChannelsRepository.TotalSalesWebSiteQuantities(saleList);

            int totalSalesAndroidMobile = _reportsChannelsRepository.TotalSalesAndroidMobileQuantities(saleList);

            int totalSalesIPhoneMobile = _reportsChannelsRepository.TotalSalesIphoneMobileQuantities(saleList);

            _reportsChannelsRepository.CreateFile(filePathSave, totalSaleRepresentative, totalSalesWebSite, totalSalesAndroidMobile, totalSalesIPhoneMobile);

        }
    }
}
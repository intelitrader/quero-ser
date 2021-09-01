using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MySolution.Models
{
    static class TotalChannelsReport
    {
        public static void Save(IEnumerable<SellModel> sells)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Quantidades de Vendas por canal\n");
            sb.AppendLine("Canal\t\t\t\tQtVendas");
            sb.AppendLine($"1 - {ChannelModel.Representative.ToFriendlyString()}\t\t{ProductModel.GetTotalSoldByChannel()[ChannelModel.Representative]}");
            sb.AppendLine($"2 - {ChannelModel.Website.ToFriendlyString()}\t\t\t{ProductModel.GetTotalSoldByChannel()[ChannelModel.Website]}");
            sb.AppendLine($"3 - {ChannelModel.Android.ToFriendlyString()}\t\t{ProductModel.GetTotalSoldByChannel()[ChannelModel.Android]}");
            sb.AppendLine($"4 - {ChannelModel.Iphone.ToFriendlyString()}\t\t{ProductModel.GetTotalSoldByChannel()[ChannelModel.Iphone]}");

            var content = sb.ToString();
            File.WriteAllText("TOTCANAIS.TXT", content);
            
        } 
    }
}
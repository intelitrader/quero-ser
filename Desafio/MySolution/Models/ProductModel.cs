using System.Collections.Generic;

namespace MySolution.Models
{
    public class ProductModel
    {
        public ProductModel(uint prodCode, int initialQt, int minimunQt)
        {
            this.ProdCode = prodCode;
            this.InitialQt = initialQt;
            this.MinimunQt = minimunQt;
        }

        public uint ProdCode { get; }
        public int InitialQt { get; }
        public int MinimunQt { get; }
        private static Dictionary<ChannelModel, int> totalSoldByChannel;
        private static Dictionary<uint, int> totalSoldByProdCode;

        public static Dictionary<ChannelModel, int> GetTotalSoldByChannel()
        {
            if (totalSoldByChannel != null) return totalSoldByChannel;
            else
            {
                totalSoldByChannel = new Dictionary<ChannelModel, int>();
                return totalSoldByChannel;
            }
        }

        public static void SetTotalSoldByChannel(ChannelModel channel, int qtValue)
        {
            if (totalSoldByChannel == null) totalSoldByChannel = new Dictionary<ChannelModel, int>();

            if (totalSoldByChannel.ContainsKey(channel))
            {
                totalSoldByChannel[channel] += qtValue;
            }
            else
            {
                totalSoldByChannel.Add(channel, qtValue);
            }
        }

        public static Dictionary<uint, int> GetTotalSoldByProdCode()
        {
            if (totalSoldByProdCode != null) return totalSoldByProdCode;
            else
            {
                totalSoldByProdCode = new Dictionary<uint, int>();
                return totalSoldByProdCode;
            } 
        }

        public static void SetTotalSoldByProdCode(uint prodCode, int qtValue )
        {
            if (totalSoldByProdCode == null) totalSoldByProdCode = new Dictionary<uint, int>();

            if (totalSoldByProdCode.ContainsKey(prodCode))
            {
                totalSoldByProdCode[prodCode] += qtValue;
            }
            else
            {
                totalSoldByProdCode.Add(prodCode, qtValue);
            }
        }
    }
}
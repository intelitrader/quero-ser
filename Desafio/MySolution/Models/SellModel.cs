namespace MySolution.Models
{
    public class SellModel
    {
        public SellModel(uint prodCode, int soldQt, int status, int channel)
        {
            this.ProdCode = prodCode;
            this.SoldQt = soldQt;
            this.Status = (StatusModel)status;
            this.Channel = (ChannelModel)channel;

            if (this.Status == Status.Completed || this.Status == Status.PaymentPending)
            {
                ////Total by ProdCode
                ProductModel.SetTotalSoldByProdCode(this.ProdCode, soldQt);

                //Total by Channel
                ProductModel.SetTotalSoldByChannel(this.Channel, soldQt);
            }
            
            
        }
        public uint ProdCode { get; }
        public int SoldQt { get; }
        public StatusModel Status { get; }
        public ChannelModel Channel { get; }

    }
}
namespace MySolution.Models
{
    public class SellModel
    {
        public SellModel(int code, int quantity, StatusModel status, ChannelModel channel)
        {
            Code = code;
            Quantity = quantity;
            Status = status;
            Channel = channel;
        }

        public int Code { get; set; }
        public int Quantity { get; set; }
        public StatusModel Status{ get; set; }
        public ChannelModel Channel{ get; set; }

    }
}
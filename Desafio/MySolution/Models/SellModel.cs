namespace MySolution.Models
{
    public class SellModel
    {
        public int Code { get; set; }
        public int Quantity { get; set; }
        public StatusModel Status{ get; set; }
        public ChannelModel Channel{ get; set; }
    }
}
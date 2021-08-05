namespace MySolution.Models
{
    public class ProductModel
    {
        public ProductModel(int code, int quantity, int minRequiredQuantity)
        {
            Code = code;
            Quantity = quantity;
            MinRequiredQuantity = minRequiredQuantity;
        }

        public int Code { get; set; }
        public int Quantity { get; set; }
        public int MinRequiredQuantity { get; set; }
    }
}
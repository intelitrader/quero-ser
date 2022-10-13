namespace OperationalStorage.Entities
{
    public class Product
    {
        public Product(int code, int quantity, int mininumQuantity)
        {
            Code = code;
            Quantity = quantity;
            MininumQuantity = mininumQuantity;
        }

        public int Code { get; set; }
        public int Quantity { get; set; }
        public int MininumQuantity { get; set; }

        public override string ToString()
        {
            return $"Code: {Code}, Quantity: {Quantity}, Mininum Quantity: {MininumQuantity}";
        }
    }
}
 
namespace EstoqueOperacional.Models
{
    internal class Product
    {
        public int Code { get; set; }

        public int Quantity { get; set; }

        public int MinRequiredQuantity { get; set; }
    }
}
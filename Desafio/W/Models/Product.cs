using System;

namespace W.Models
{
    public class Product
    {

        public Product(string source)
        {
            var split = source.Split(";");
            Id = Convert.ToInt32(split[0]);
            InStock = Convert.ToInt32(split[1]);
            OperationalMinimum = Convert.ToInt32(split[2]);
        }

        public int Id { get; init; }
        public int InStock { get; init; }
        public int OperationalMinimum { get; init; }

    }
}

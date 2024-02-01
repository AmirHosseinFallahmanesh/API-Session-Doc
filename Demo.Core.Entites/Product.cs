using System;

namespace Demo.Core.Entites
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }

        public DateTime CreationDate { get; set; }
    }
}

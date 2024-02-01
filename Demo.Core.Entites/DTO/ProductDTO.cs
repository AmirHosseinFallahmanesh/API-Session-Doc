using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Entites.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }

        public DateTime CreationDate { get; set; }
    }
}

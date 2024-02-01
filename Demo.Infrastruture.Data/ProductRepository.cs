using Demo.Core.Contract;
using Demo.Core.Entites;
using Demo.Infrastruture.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Infrastruture.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DemoContext demoContext;

        public ProductRepository(DemoContext demoContext)
        {
            this.demoContext = demoContext;

        }
        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
           return this.demoContext.Products.Find(id);
        }

        public List<Product> GetAll()
        {
            return this.demoContext.Products.ToList();
        }

        public int Insert(Product product)
        {
            demoContext.Products.Add(product);
            demoContext.SaveChanges();
            return product.ProductId;
        }

        public Product Update(Product product)
        {
            demoContext.Products.Update(product);
            demoContext.SaveChanges();
            return product;
        }
    }
}

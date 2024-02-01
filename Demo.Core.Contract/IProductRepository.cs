using Demo.Core.Entites;
using System;
using System.Collections.Generic;

namespace Demo.Core.Contract
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Get(int id);
        int Insert(Product product);

        Product Update(Product product);

        void Delete(Product product);    


    }
}

using Demo.Core.Entites;
using Demo.Core.Entites.DTO;
using System.Collections.Generic;

namespace Demo.Core.Contract
{
    public interface IProductFacade
    {
        IEnumerable<ProductDTO> GetAll();
        ProductDTO Get(int id);
        int Insert(ProductDTO product);

        ProductDTO Update(ProductDTO product);

        void Delete(int id);
    }
}

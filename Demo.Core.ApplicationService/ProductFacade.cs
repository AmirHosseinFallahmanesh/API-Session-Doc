using AutoMapper;
using Demo.Core.Contract;
using Demo.Core.Entites;
using Demo.Core.Entites.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Demo.Core.ApplicationService
{
    public class ProductFacade: IProductFacade
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductFacade(IProductRepository productRepository,IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProductDTO Get(int id)
        {
     

           Product product= productRepository.Get(id);
            PersianCalendar pc = new PersianCalendar();
            DateTime cd = new DateTime(
                pc.GetYear(product.CreationDate),
                pc.GetMonth(product.CreationDate),
                pc.GetDayOfMonth(product.CreationDate)
                );
            ProductDTO dto = new ProductDTO()
            {
                Color = product.Color,
                CreationDate = cd,
                Price = product.Price,
                ProductCode = product.ProductCode,
                ProductId = product.ProductId
            };
            return dto;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var data= productRepository.GetAll();
            var dto = mapper.Map<List<Product>, List<ProductDTO>>(data);
            return dto;
        }

        public int Insert(ProductDTO productDTO)
        {
           var product= mapper.Map<ProductDTO, Product>(productDTO);
            product.CreationDate = DateTime.Now;
            return productRepository.Insert(product);
        }

        public ProductDTO Update(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}

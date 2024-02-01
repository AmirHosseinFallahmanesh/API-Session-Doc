using AutoMapper;
using Demo.Core.Entites;
using Demo.Core.Entites.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.ApplicationService.Config
{
   public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Core.Contract;
using Demo.Core.Entites.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceHost.Model;

namespace ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductFacade productFacade;

        public ProductController(IProductFacade productFacade)
        {
            this.productFacade = productFacade;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            ApiResponceModel<IEnumerable<ProductDTO>> responce = 
                new ApiResponceModel<IEnumerable<ProductDTO>>();
            try
            {
                var data = productFacade.GetAll();
                responce.Data = data;

                return Ok(responce);
            }
            catch (Exception ex)
            {
                responce.IsFailed = true;
                responce.Errors.Add(ex.Message);
                return BadRequest(responce);
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ApiResponceModel<ProductDTO> responce = new ApiResponceModel<ProductDTO>();
            try
            {
               var data = productFacade.Get(id);
                responce.Data = data;
                
                return Ok(responce);
            }
            catch ( Exception ex)
            {
                responce.IsFailed = true;
                responce.Errors.Add(ex.Message);
                return NotFound( responce);
            }
            
        }

        [HttpPost]
        public  IActionResult Post(ProductDTO product)
        {
            try
            {
               int id =productFacade.Insert(product);
               return Created($"api/product/{id}", id); 
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        [HttpPut]
        public IActionResult Update(ProductDTO product)
        {
            try
            {
                ProductDTO productDTO= productFacade.Update(product);
                return Ok(productDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
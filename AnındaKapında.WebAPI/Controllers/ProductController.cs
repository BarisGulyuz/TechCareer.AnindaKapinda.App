using AnındaKapında.WebAPI.Constans;
using BusinessLayer.Abstract;
using BusinessLayer.ErrorResponse;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnındaKapında.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _productService.GetAll();
            return Ok(values);
        }

        [HttpGet]
        [Route("Category/{categoryId}")]
        public IActionResult GetAllByCategory(int categoryId)
        {
            var values = _productService.GetProductsByCategory(categoryId);
            return Ok(values);
        }
        [HttpGet]
        [Route("{productId}")]
        public IActionResult GetbyId(int productId)
        {
            var value = _productService.GetById(productId);
            if (value == null)
            {
                return NotFound(new ApiResponse(404, productId, message: Messages.NotFound));
            }
            return Ok(value);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deletedValue = _productService.GetById(id);
            if (deletedValue == null)
            {
                return NotFound(new ApiResponse(404, id, message: Messages.NotFound));
            }
            _productService.Delete(deletedValue);
            return NoContent();

        }
        [HttpPost]
        [Route("")]
        public IActionResult AddProduct(Product product)
        {
            _productService.Add(product);
            return Created("", product);
        }
        [HttpPut]
        [Route("")]
        public IActionResult UpdateProduct(Product product)
        {
            var updatedValue = _productService.GetById(product.Id);
            if (updatedValue == null)
            {
                return NotFound(new ApiResponse(404, product.Id, message: Messages.NotFound));
            }
            _productService.Update(product);
            return NoContent();
        }
    }
}

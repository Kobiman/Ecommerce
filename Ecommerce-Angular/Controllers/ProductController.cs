using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Models.Dto;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(AddProductDto productVm)
        {
            var result = _productService.AddProduct(productVm);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(UpdateProductDto product)
        {
            var result = _productService.UpdateProduct(product);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            var result = _productService.GetProducts();
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("GetProducts/{skip}/{take}")]
        public IActionResult GetProducts(int skip, int take)
        {
            var result = _productService.GetProducts(skip, take);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("GetProductsInventory")]
        public IActionResult GetProductsInventory()
        {
            var result = _productService.GetInventory();
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("GetProductsInventory/{skip}/{take}")]
        public IActionResult GetProductsInventory(int skip, int take)
        {
            var result = _productService.GetProductsInventory(skip, take);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("GetProduct/{productId}")]
        public IActionResult GetProduct(string productId)
        {
            var result = _productService.GetProduct(productId);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("DeleteProduct/{productId}")]
        public IActionResult DeleteProduct(string productId)
        {
            var result = _productService.DeleteProduct(productId);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("Count")]
        public IActionResult Count()
        {
            var result = _productService.Count();
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

    }
}
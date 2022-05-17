using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models.Dto;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTransactionController : ControllerBase
    {
        private IProductTransactionService _producttransactionService;

        public ProductTransactionController(
            IProductTransactionService productTransactionService)
        {
            _producttransactionService = productTransactionService;
        }

        [HttpPost]
        [Route("AddProductTransaction")]
        public IActionResult AddProductTransaction(AddProductTransactionDto productTransaction)
        {
            var result = _producttransactionService.AddProductTransaction(productTransaction);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("Total")]
        public IActionResult Total()
        {
            var result = _producttransactionService.Total();
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models.Dto;
using Ecommerce.Services.Interfaces;
using Ecommerce.Services;

namespace Ecommerce_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CheckoutController : ControllerBase
    {
      private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
           _checkoutService = checkoutService;
        }

        [HttpPost]
        [Route("AddCheckoutItem")]
        public IActionResult AddCheckoutItem(AddCheckoutItemDto checkoutItemVm)
        {
            _checkoutService.SaveCheckoutItem(checkoutItemVm);
           return Ok("OK");
        }

        [HttpGet]
        [Route("GetCheckoutItems")]
        public IActionResult GetCheckoutItems()
        {
            var result = _checkoutService.GetCheckoutItems();
            if (result.IsSucessful) return Ok(result);
            return BadRequest();
        }
    }
}

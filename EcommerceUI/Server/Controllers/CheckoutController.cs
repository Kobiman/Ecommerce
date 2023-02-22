using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models.Dto;
using Ecommerce.Services.Interfaces;

namespace EcommerceUI.Server.Controllers
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
            var result = _checkoutService.SaveCheckoutItem(checkoutItemVm);
            if (result.IsSucessful) return Ok(result);
            return BadRequest();
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

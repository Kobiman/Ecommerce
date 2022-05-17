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
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterDto model)
        {
            var result = await _userService.RegisterUser(model);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginDto model)
        {
            var result = await _userService.LoginUser(model);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("Confirmmail")]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery]string userid, [FromQuery]string token)
        {
            var result = await _userService.ConfirmEmail(userid, token);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

    }
}
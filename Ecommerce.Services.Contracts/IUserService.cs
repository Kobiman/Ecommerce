using Ecommerce.Models;
using Ecommerce.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces
{
    public interface IUserService
    {
        Task<IResult> RegisterUser(RegisterDto model);
        Task<IResult> LoginUser(LoginDto model);
        Task<IResult> ConfirmEmail(string userId, string token);
    }
}

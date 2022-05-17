using Ecommerce.Models;
using Ecommerce.Models.Dto;
using Ecommerce.Services.Interfaces;
using KMailHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{

    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _mailService;
        private readonly AppConfig _emailConfig;

        public UserService(UserManager<IdentityUser> userManager, IEmailSender mailService, AppConfig emailConfig)
        {
            _userManager = userManager;
            _mailService = mailService;
            _emailConfig = emailConfig;
        }

        public async Task<IResult> LoginUser(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null) return new Result(false, "There is no user with that email address");
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!result) return new Result(false,"Invalid password");
            var claims = new[]
            {
              new Claim("Email",model.Email),
              new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello please jffndddjdjd"));
            var token = new JwtSecurityToken(
                issuer: "https://localhost:44392/",
                audience: "https://localhost:44392/",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Result<string>(true, tokenAsString, "");
        }

        public async Task<IResult> RegisterUser(RegisterDto model)
        {
            if (model.Password != model.ConfirmPassword)
                return new Result(false, "Confirm password doesn't match the password");

            var identityUser = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(identityUser, model.Password);

            if (result.Succeeded)
            {
                var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                var validationToken = WebEncoders.Base64UrlEncode(encodedEmailToken);
                var url = $"{_emailConfig.AppUrl}/api/Auth/Confirmmail?userid={identityUser.Id}&token={validationToken}";
                var message = new Message(new string[] { $"{identityUser.Email}" }, "Confirm Your Email", "<h1>Welcome To UENR Auth</h1>" +
                    $"<p>Please confirm your email by <a href='{url}'>clicking here.</a></p>");
                await _mailService.SendEmailAsync(message);
                return new Result(true, "User created successfully");
            }
            return new Result(false, "Could not create user");
        }

        public async Task<IResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return new Result(false,"User not found");
            var decodedToken = WebEncoders.Base64UrlDecode(token);
            var normalToken = Encoding.UTF8.GetString(decodedToken);
            var result = await _userManager.ConfirmEmailAsync(user, normalToken);
            if (result.Succeeded) return new Result(true,"Email confirmed successfully");
            return new Result(false, "Email not confirmed");
        }
    }
}

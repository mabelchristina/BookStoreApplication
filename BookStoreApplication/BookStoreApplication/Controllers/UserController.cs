using BusinessLogic.Interfaces;
using CommonModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IUserBL userData;
        public UserController(IConfiguration configuration, IUserBL userData)
        {
            this.configuration = configuration;
            this.userData = userData;
        }
        [HttpPost]
        public async Task<ActionResult> Register(User user)
        {
            try
            {
                var result = await userData.Register(user);
                if (result !=0)
                {
                    return this.Ok(new { Status = true, Message = "User Registration Sucesesfull", Data = user });
                }
                return this.BadRequest(new { Status = false, Message = "User Registration UnSuccesfull" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.InnerException.Message });
            }
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(UserLogin login)
        {
            try
            {
                var result = this.userData.Login(login);
                if (result != null)
                {
                    var token = GenrateJWTToken(result.UserId);
                    return this.Ok(new { Status = true, Message = "User Loged In Sucssesfull", Token = token, Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "User Login Failed" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        private string GenrateJWTToken(int UserId)
        {
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Key"]));
            var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Role, "User"),
                            new Claim("UserId",UserId.ToString())
                        };
            var tokenOptionOne = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: signinCredentials
                );
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptionOne);
            return token;
        }
    }
}

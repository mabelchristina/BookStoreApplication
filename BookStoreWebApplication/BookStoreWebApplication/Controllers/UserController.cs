using BussinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserBL userBL;
        public readonly IConfiguration _configuration;
        public UserController(IUserBL userBL, IConfiguration configuration)
        {
            this.userBL = userBL;
            this._configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> UserRegistration(User user)
        {
            try
            {
                User usersData = await this.userBL.UserRegistration(user);
                return this.Ok(new { Success = true, Message = "User registration is successful", Data = usersData });
            }
            catch(Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [HttpPost]
        [Route("Login")]

        public async Task<ActionResult> UserLogin(UserLogin userLogin)
        {
            try
            {
                User usersData = await this.userBL.UserLogin(userLogin);
                string token = new JwtServices(this._configuration).GenerateSecurityToken(usersData);
                return this.Ok(new { Success = true, Message = "User Login is successful", Data = usersData , Token = token});
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }
    }
}

using BussinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        public readonly IUserAddressBL userAddressBL;
        public readonly IConfiguration _configuration;
        public UserAddressController(IUserAddressBL userAddressBL, IConfiguration configuration)
        {
            this.userAddressBL = userAddressBL;
            this._configuration = configuration;
        }
        [Authorize]
        [HttpPost]
       
        public async Task<ActionResult> AddUserAddress( UserAddress userAddresses)
        {
            var currentUser = HttpContext.User;
            int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            try
            {
                UserAddress userAddress = await this.userAddressBL.AddUserAddress( userAddresses);
                return this.Ok(new { Success = true, Message = "An address is added successfully", Data = userAddress });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAllAddress()
        {
            var currentUser = HttpContext.User;
            int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            try
            {
                List<UserAddress> users = await this.userAddressBL.GetAllAddresses(userId);
                return this.Ok(new { Success = true, Message = "Get all address is successful", Data = users });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }
        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> DeleteAddress(int bookId)
        {
            var currentUser = HttpContext.User;
            int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            try
            {
                List<UserAddress> users = await this.userAddressBL.DeleteAddress(userId);
                return this.Ok(new { Success = true, Message = "Address deletion is successful", Data = users });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }
    }
}

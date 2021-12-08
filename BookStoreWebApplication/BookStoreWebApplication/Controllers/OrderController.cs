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
    public class OrderController : ControllerBase
    {
        public readonly IOrderBL orderBL;
        public readonly IConfiguration _configuration;
        public OrderController(IOrderBL orderBL, IConfiguration configuration)
        {
            this.orderBL = orderBL;
            this._configuration = configuration;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PlaceOrders(Order summary)
        {
            var currentUser = HttpContext.User;
            int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            try
            {
               var order = await this.orderBL.PlaceOrder( summary);
                return this.Ok(new { Success = true, Message = "order placed successfully", Data = order });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }
    }
}

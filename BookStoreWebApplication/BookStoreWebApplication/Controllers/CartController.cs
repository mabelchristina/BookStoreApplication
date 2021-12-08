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
    public class CartController : ControllerBase
    {
        public readonly ICartBL cartBL;
        public readonly IConfiguration _configuration;
        public CartController(ICartBL cartBL, IConfiguration configuration)
        {
            this.cartBL = cartBL;
            this._configuration = configuration;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAllBooksInCart()
        {
            var currentUser = HttpContext.User;
            int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            try
            {
                List<CartResponse> cart = await this.cartBL.GetAllBooksInCart(userId);
                return this.Ok(new { Success = true, Message = "Get all books in cart is successful", Data = cart });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("{bookId:int}")]
        public async Task<ActionResult> GetABookInCart(int bookId)
        {
            var currentUser = HttpContext.User;
            int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            try
            {
                CartResponse cart = await this.cartBL.GetABookInCart(userId, bookId);
                return this.Ok(new { Success = true, Message = "Get a book in cart is successful", Data = cart });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("{bookId:int}")]
        public async Task<ActionResult> AddABookToCart(int bookId, int numberOfBooks)
        {
            var currentUser = HttpContext.User;
            int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            try
            {
                CartResponse cart = await this.cartBL.AddABookToCart(userId, bookId, numberOfBooks);
                return this.Ok(new { Success = true, Message = "Add a book to cart is successful", Data = cart });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("{bookId:int}")]
        public async Task<ActionResult> UpdateABookInCart(int bookId, int numberOfBooks)
        {
            var currentUser = HttpContext.User;
            int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            try
            {
                CartResponse cart = await this.cartBL.UpdateABookInCart(userId, bookId, numberOfBooks);
                return this.Ok(new { Success = true, Message = "Update a book in cart is successful", Data = cart });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("{bookId:int}")]
        public async Task<ActionResult> DeleteABookInCart(int bookId)
        {
            var currentUser = HttpContext.User;
            int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            try
            {
                List<CartResponse> carts = await this.cartBL.DeleteABookInCart(userId, bookId);
                return this.Ok(new { Success = true, Message = "Update a book in cart is successful", Data = carts });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }

        }
        //[Authorize]
        //[HttpDelete]
        //[Route("{bookId:int}/MoveToWishList")]
        //public async Task<ActionResult> MoveABookToWishList(int bookId)
        //{
        //    var currentUser = HttpContext.User;
        //    int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
        //    try
        //    {
        //        List<CartResponse> carts = await this.cartBL.MoveABookToWishList(userId, bookId);
        //        return this.Ok(new { Success = true, Message = "Move a book in cart to wishlist is successful", Data = carts });
        //    }
        //    catch (Exception e)
        //    {
        //        return this.BadRequest(new { Success = false, Message = e.Message });
        //    }
        //}
    }
}



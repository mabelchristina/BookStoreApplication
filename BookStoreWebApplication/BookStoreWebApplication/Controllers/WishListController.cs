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
    public class WishListController : ControllerBase
    {
        public readonly IWishListBL wishListBL;
        public readonly IConfiguration _configuration;
        public WishListController(IWishListBL wishListBL, IConfiguration configuration)
        {
            this.wishListBL = wishListBL;
            this._configuration = configuration;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAllBooksInWishList()
        {
            var currentUser = HttpContext.User;
            int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            try
            {
                List<WishResponse> wishList = await this.wishListBL.GetAllBooksInWishList(userId);
                return this.Ok(new { Success = true, Message = "Get all books in wishlist is successful", Data = wishList });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [Authorize]
        [HttpGet("{bookId:int}")]
        public async Task<ActionResult> GetABookInWishList(int bookId)
        {
            var currentUser = HttpContext.User;
            int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            try
            {
                WishResponse wishList = await this.wishListBL.GetABookInWishList(userId, bookId);
                return this.Ok(new { Success = true, Message = "Get a book in wishlist is successful", Data = wishList });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [Authorize]
        [HttpPost("{bookId:int}")]
        public async Task<ActionResult> AddABookToWishList(int bookId)
        {
            var currentUser = HttpContext.User;
            int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            try
            {
                WishResponse wishList = await this.wishListBL.AddABookToWishList(userId, bookId);
                return this.Ok(new { Success = true, Message = "Add a book to wishlist is successful", Data = wishList });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [Authorize]
        [HttpDelete("{bookId:int}")]
        public async Task<ActionResult> RemoveABookFromWishList(int bookId)
        {
            var currentUser = HttpContext.User;
            int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            try
            {
                List<WishResponse> wishList = await this.wishListBL.RemoveABookFromWishList(userId, bookId);
                return this.Ok(new { Success = true, Message = "Remove a book from wishlist is successful", Data = wishList });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [Authorize]
        [HttpDelete("{bookId:int}/MoveToCart")]
        public async Task<ActionResult> MoveToCart(int bookId)
        {
            var currentUser = HttpContext.User;
            int userId = Convert.ToInt32(currentUser.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            try
            {
                List<WishResponse> wishList = await this.wishListBL.MoveToCart(userId, bookId);
                return this.Ok(new { Success = true, Message = "Move a book from wishlist to cart is successful", Data = wishList });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }
    }
}

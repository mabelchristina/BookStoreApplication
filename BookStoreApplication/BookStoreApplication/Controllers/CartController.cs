using BusinessLogic.Interfaces;
using CommonModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartBL cart;
        public CartController(ICartBL cart)
        {
            this.cart = cart;
        }
        [HttpPost]
        public async Task<ActionResult> AddBooksToCart(Carts book)
        {
            try
            {
                //int userId = TokenUserId();
                //book.UserId = userId;
                var result = await this.cart.AddBooksToCart(book);
                if (result == 1)
                {
                    return this.Ok(new { Status = true, Message = "Book Added to Cart Successfully", Data = book });
                }
                return this.BadRequest(new { Status = false, Message = "Book Added to Cart Un-Successful" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpGet]
        public ActionResult GetAllBooks()
        {
            try
            {
                //int userId = TokenUserId();
                var result = this.cart.GetAllCartBooks();
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "List of books added to cart", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "No books found" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpDelete]
        [Route("{cartId}")]
        public ActionResult DeleteBookFromCart(int cartId)
        {
            try
            {
                var result = this.cart.DeleteBookFromCart(cartId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Deleted from Cart Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Book Deleted from Cart Un-Successful" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }

        [HttpPut]
        public ActionResult UpdateBookInCart(Carts cart)
        {
            try
            {
                ////int userId = TokenUserId();
                ////cart.UserId = userId;
                var result = this.cart.UpdateCart(cart);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Cart updated successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Cart update Un-Successful" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        //private int TokenUserId()
        //{
        //    return Convert.ToInt32(User.FindFirst("userId").Value);
        //}

    }
}

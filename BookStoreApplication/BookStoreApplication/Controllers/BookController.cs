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
    public class BookController : ControllerBase
    {
        private readonly IBookBL bookData;
        public BookController(IBookBL bookData)
        {
            this.bookData = bookData;
        }
        [HttpPost]
        public async Task<ActionResult> AddBooks(Books book)
        {
            try
            {
                var result = await this.bookData.AddBooks(book);
                if (result == 1)
                {
                    return this.Ok(new { Status = true, Message = "Book Added Sucssesfull", Data = book });
                }
                return this.BadRequest(new { Status = false, Message = "Book Added Un-Sucssesfull" });
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
                var result = this.bookData.GetAllBooks();
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "List of books", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "No books found" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [Route("Search/BookId")]
        [HttpGet]
        public ActionResult Search(int BookId)
        {
            try
            {
                 var result=this.bookData.SearchBook(BookId);

                    return this.Ok(new { Status = true, Message = "List of books", Data= result });
                
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
            finally
            {
                this.BadRequest(new { Status = false, Message = "No books found" });
            }
        }
    }
}

using BussinessLayer.Interfaces;
using CommonLayer.Model;
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
    public class BookController : ControllerBase
    {
        public readonly IBookBL bookBL;
        public readonly IConfiguration _configuration;
        public BookController(IBookBL bookBL, IConfiguration configuration)
        {
            this.bookBL = bookBL;
            this._configuration = configuration;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllBooks()
        {
            try
            {
                List<Book> books = await this.bookBL.GetAllBooks();
                return this.Ok(new { Success = true, Message = "Get all books is successful", Data = books });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [HttpGet]
        [Route("{bookId:int}")]
        public async Task<ActionResult> GetBook(int bookId)
        {
            try
            {
                Book book = await this.bookBL.GetBook(bookId);
                return this.Ok(new { Success = true, Message = "Get book is successful", Data = book });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddBook(Book newBook)
        {
            try
            {
                Book book = await this.bookBL.AddBook(newBook);
                return this.Ok(new { Success = true, Message = "Book details updation is successful", Data = book });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [HttpPut]
        [Route("{bookId:int}")]
        public async Task<ActionResult> UpdateBook(int bookId, Book updatedBook)
        {
            try
            {
                Book book = await this.bookBL.UpdateBook(bookId, updatedBook);
                return this.Ok(new { Success = true, Message = "Book details updation is successful", Data = book });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }



        [HttpDelete]
        [Route("{bookId:int}")]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            try
            {
                List<Book> books = await this.bookBL.DeleteBook(bookId);
                return this.Ok(new { Success = true, Message = "Book deletion is successful", Data = books });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }
    }
}

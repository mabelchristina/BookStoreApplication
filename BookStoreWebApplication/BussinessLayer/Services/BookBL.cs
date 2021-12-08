using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class BookBL :IBookBL
    {
        private readonly IBookRL bookRL;
        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }
        public async Task<List<Book>> GetAllBooks()
        {
            try
            {
                return await bookRL.GetAllBooks();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Book> GetBook(int bookId)
        {
            try
            {
                return await bookRL.GetBook(bookId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Book> AddBook(Book newBook)
        {
            try
            {
                return await bookRL.AddBook(newBook);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Book> UpdateBook(int bookId, Book updatedBook)
        {
            try
            {
                return await bookRL.UpdateBook(bookId, updatedBook);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Book>> DeleteBook(int bookId)
        {
            try
            {
                return await bookRL.DeleteBook(bookId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

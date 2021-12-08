using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class BookRL:IBookRL
    {
        private readonly ApplicationDBContext applicationDBContext;
        public BookRL(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public async Task<Book> AddBook(Book newBook)
        {
            await this.applicationDBContext.Books.AddAsync(newBook);
            await this.applicationDBContext.SaveChangesAsync();
            return await applicationDBContext.Books.Where(u => u.Title == newBook.Title).FirstOrDefaultAsync();
        }

        public async Task<Book> UpdateBook(int bookId, Book updatedBook)
        {
            var book = await applicationDBContext.Books.Where(u => u.BookId == bookId).FirstOrDefaultAsync();
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Category = updatedBook.Category;
                book.Stock = updatedBook.Stock;
                book.Price = updatedBook.Price;
                await applicationDBContext.SaveChangesAsync();
                return await applicationDBContext.Books.Where(u => u.BookId == bookId).FirstOrDefaultAsync();
            }
            throw new Exception("No book available with given book id to update.");
        }
        public async Task<List<Book>> GetAllBooks()
        {
            return await applicationDBContext.Books.ToListAsync();
        }

        public async Task<Book> GetBook(int bookId)
        {
            var book = await applicationDBContext.Books.Where(u => u.BookId == bookId).FirstOrDefaultAsync();
            if (book != null)
            {
                return book;
            }
            throw new Exception("No book available with given book id to view.");
        }


        public async Task<List<Book>> DeleteBook(int bookId)
        {
            var book = await applicationDBContext.Books.Where(u => u.BookId == bookId).FirstOrDefaultAsync();
            if (book != null)
            {
                this.applicationDBContext.Books.Remove(book);
                await this.applicationDBContext.SaveChangesAsync();
                return await applicationDBContext.Books.ToListAsync();
            }
            throw new Exception("No book available with given book id to delete.");

        }

    }
}

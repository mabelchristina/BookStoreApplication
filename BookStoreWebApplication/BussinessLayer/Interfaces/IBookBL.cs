using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IBookBL
    {
        Task<Book> AddBook(Book newBook);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBook(int bookId);
        Task<Book> UpdateBook(int bookId, Book updatedBook);
        Task<List<Book>> DeleteBook(int bookId);
    }
}

using CommonModel.Models;
using CommonModel.RequestModel;
using CommonModel.ResponseModel;
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
        public readonly BookStoreDBContext context;
        public BookRL(BookStoreDBContext context)
        {
            this.context = context;
        }

        public Task<int> AddBooks(Books books)
        {
            this.context.Books.Add(books);
            var result = this.context.SaveChangesAsync();
            return result;
        }
        public IEnumerable<Books> GetAllBooks()
        {
            var result = this.context.Books.ToList<Books>();
            return result;
        }
        public Books SearchBook(int BookId)
        {
            try
            {
                var responseList = this.context.Books;
                var response = this.context.Books.FirstOrDefault(value => ((value.BookId == BookId)));
                return response;
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}

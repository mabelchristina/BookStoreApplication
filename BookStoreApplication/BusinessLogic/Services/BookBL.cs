using BusinessLogic.Interfaces;
using CommonModel.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class BookBL : IBookBL
    {
        private readonly IBookRL bookRL;
        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }

        public Task<int> AddBooks(Books books)
        {
            var result = this.bookRL.AddBooks(books);
            return result;
        }

        Task<int> IBookBL.AddBooks(Books books)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Books> IBookBL.GetAllBooks()
        {
            try
            {
                var result = this.bookRL.GetAllBooks();
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        Books IBookBL.SearchBook(int BookId)
        {
            try
            {
                var result=this.bookRL.SearchBook(BookId);
                return result;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

using CommonModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IBookBL
    {
        Task<int> AddBooks(Books books);
        public IEnumerable<Books> GetAllBooks();
        public Books SearchBook(int BookId);
    }
}

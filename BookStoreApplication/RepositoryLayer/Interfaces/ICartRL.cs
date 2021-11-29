using CommonModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ICartRL
    {
        Task<int> AddBooksToCart(Carts books);
        List<BookCartResponse> GetAllCartBooks();
        Carts DeleteBookFromCart(int cartId);
        public Carts UpdateCart(Carts cart);
    }
}

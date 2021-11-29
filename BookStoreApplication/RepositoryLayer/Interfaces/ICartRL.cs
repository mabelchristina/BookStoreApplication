using CommonModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ICartRL
    {
        Task<int> AddBooksToCart(Cart books);
        List<BookCartResponse> GetAllCartBooks();
        Cart DeleteBookFromCart(int cartId);
        public Cart UpdateCart(Cart cart);
    }
}

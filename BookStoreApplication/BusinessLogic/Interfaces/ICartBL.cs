using CommonModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICartBL
    {
        Task<int> AddBooksToCart(Cart books);
        List<BookCartResponse> GetAllCartBooks();
        Cart DeleteBookFromCart(int cartId);
        public Cart UpdateCart(Cart cart);
    }
}

using CommonModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IWishListBL
    {
        Task<int> AddBooksToWishlist(Wish books);
        List<BookWishlistResponse> GetAllWishlistBooks();
        Wish DeleteBookFromWishlist(int wishlistId);
        int GetWishlistCount(int userId);
    }
}

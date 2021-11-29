using CommonModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IWishListRL
    {
        Task<int> AddBooksToWishlist(Wish books);
        List<BookWishlistResponse> GetAllWishlistBooks();
        Wish DeleteBookFromWishlist(int wishlistId);
        int GetWishlistCount(int userId);
    }
}

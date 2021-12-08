using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IWishListRL
    {
        Task<CartResponse> AddABookToCart(int userId, int bookId, int numberOfBooks);
        Task<CartResponse> UpdateABookInCart(int userId, int bookId, int numberOfBooks);
        Task<List<WishResponse>> GetAllBooksInWishList(int userId);
        Task<WishResponse> GetABookInWishList(int userId, int bookId);
        Task<WishResponse> AddABookToWishList(int userId, int bookId);
        Task<List<WishResponse>> RemoveABookFromWishList(int userId, int bookId);
        Task<List<WishResponse>> MoveToCart(int userId, int bookId);
        Task<List<CartResponse>> MoveABookToWishList(int userId, int bookId);
    }
}

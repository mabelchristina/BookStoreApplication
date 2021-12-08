using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ICartRL
    {
        Task<CartResponse> AddABookToCart(int userId, int bookId, int numberOfBooks);
        Task<CartResponse> UpdateABookInCart(int userId, int bookId, int numberOfBooks);
        Task<List<CartResponse>> GetAllBooksInCart(int userId);
        Task<CartResponse> GetABookInCart(int userId, int bookId);
        Task<List<CartResponse>> DeleteABookInCart(int userId, int bookId);
        //Task<List<CartResponse>> MoveABookToWishList(int userId, int bookId);
    }
}

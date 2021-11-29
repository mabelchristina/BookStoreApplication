using BusinessLogic.Interfaces;
using CommonModel.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class WishListBL:IWishListBL
    {
        private readonly IWishListRL wishListRepo;
        public WishListBL(IWishListRL wishListRepo)
        {
            this.wishListRepo = wishListRepo;
        }
        public Task<int> AddBooksToWishlist(Wish books)
        {
            try
            {
                var result = this.wishListRepo.AddBooksToWishlist(books);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public Wish DeleteBookFromWishlist(int wishlistId)
        {
            try
            {
                var result = this.wishListRepo.DeleteBookFromWishlist(wishlistId);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public List<BookWishlistResponse> GetAllWishlistBooks()
        {
            try
            {
                var result = this.wishListRepo.GetAllWishlistBooks();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int GetWishlistCount(int userId)
        {
            try
            {
                var result = this.wishListRepo.GetWishlistCount(userId);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}

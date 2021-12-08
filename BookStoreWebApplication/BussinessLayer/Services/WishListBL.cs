using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class WishListBL:IWishListBL
    {
        private readonly IWishListRL wishListRL;
        public WishListBL(IWishListRL wishListRL)
        {
            this.wishListRL = wishListRL;
        }
        public async Task<CartResponse> AddABookToCart(int userId, int bookId, int numberOfBooks)
        {
            try
            {
                return await wishListRL.AddABookToCart(userId, bookId, numberOfBooks);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CartResponse> UpdateABookInCart(int userId, int bookId, int numberOfBooks)
        {
            try
            {
                return await wishListRL.UpdateABookInCart(userId, bookId, numberOfBooks);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<WishResponse>> GetAllBooksInWishList(int userId)
        {
            try
            {
                return await wishListRL.GetAllBooksInWishList(userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<WishResponse> GetABookInWishList(int userId, int bookId)
        {
            try
            {
                return await wishListRL.GetABookInWishList(userId, bookId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<WishResponse> AddABookToWishList(int userId, int bookId)
        {
            try
            {
                return await wishListRL.AddABookToWishList(userId, bookId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<WishResponse>> RemoveABookFromWishList(int userId, int bookId)
        {
            try
            {
                return await wishListRL.RemoveABookFromWishList(userId, bookId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<WishResponse>> MoveToCart(int userId, int bookId)
        {
            try
            {
                return await wishListRL.MoveToCart(userId, bookId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<CartResponse>> MoveABookToWishList(int userId, int bookId)
        {
            try
            {
                return await wishListRL.MoveABookToWishList(userId, bookId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

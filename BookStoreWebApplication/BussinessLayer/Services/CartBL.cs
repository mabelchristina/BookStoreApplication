using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class CartBL:ICartBL
    {
        private readonly ICartRL cartRL;
        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }
        public async Task<List<CartResponse>> GetAllBooksInCart(int userId)
        {
            try
            {
                return await cartRL.GetAllBooksInCart(userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CartResponse> GetABookInCart(int userId, int bookId)
        {
            try
            {
                return await cartRL.GetABookInCart(userId, bookId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CartResponse> AddABookToCart(int userId, int bookId, int numberOfBooks)
        {
            try
            {
                return await cartRL.AddABookToCart(userId, bookId, numberOfBooks);
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
                return await cartRL.UpdateABookInCart(userId, bookId, numberOfBooks);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<CartResponse>> DeleteABookInCart(int userId, int bookId)
        {
            try
            {
                return await cartRL.DeleteABookInCart(userId, bookId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //public async Task<List<CartResponse>> MoveABookToWishList(int userId, int bookId)
        //{
        //    try
        //    {
        //        return await cartRL.MoveABookToWishList(userId, bookId);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
    }
}

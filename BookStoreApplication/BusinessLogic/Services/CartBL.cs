using BusinessLogic.Interfaces;
using CommonModel.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CartBL : ICartBL
    {
        private readonly ICartRL bookRepo;
        public CartBL(ICartRL bookRepo)
        {
            this.bookRepo = bookRepo;
        }
        public Task<int> AddBooksToCart(Cart books)
        {
            try
            {
                var result = this.bookRepo.AddBooksToCart(books);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public List<BookCartResponse> GetAllCartBooks()
        {
            try
            {
                var result = this.bookRepo.GetAllCartBooks();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
        public Cart DeleteBookFromCart(int cartId)
        {
            try
            {
                var result = this.bookRepo.DeleteBookFromCart(cartId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cart UpdateCart(Cart cart)
        {
            try
            {
                var result = this.bookRepo.UpdateCart(cart);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}

using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class CartRL:ICartRL
    {
        private readonly ApplicationDBContext applicationDBContext;
        public CartRL(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public async Task<List<CartResponse>> GetAllBooksInCart(int userId)
        {
            return await applicationDBContext.Carts
                .Where(c => c.UserId == userId)
                .Join(applicationDBContext.Books,
                c => c.BookId,
                b => b.BookId,
                (c, b) => new CartResponse
                {
                    Price = c.Price,
                    UserId = c.UserId,
                    BookTitle = b.Title,
                    Quantity = c.NumberOfBooks
                }).ToListAsync();
        }

        public async Task<CartResponse> GetABookInCart(int userId, int bookId)
        {
            var book = await applicationDBContext.Carts.Where(c => c.UserId == userId && c.BookId == bookId).FirstOrDefaultAsync();
            if (book != null)
            {
                return await applicationDBContext.Carts
                .Where(c => c.UserId == userId)
                .Join(applicationDBContext.Books
                .Where(b => b.BookId == bookId),
                c => c.BookId,
                b => b.BookId,
                (c, b) => new CartResponse
                {
                    Price = c.Price,
                    UserId = c.UserId,
                    BookTitle = b.Title,
                    Quantity = c.NumberOfBooks
                }).FirstOrDefaultAsync();
            }
            throw new Exception("No book in cart with selected book id.");
        }

        public async Task<CartResponse> AddABookToCart(int userId, int bookId, int numberOfBooks)
        {
            var cart = await applicationDBContext.Carts.Where(c => c.UserId == userId && c.BookId == bookId).FirstOrDefaultAsync();
            
                var book = await applicationDBContext.Books.Where(b => b.BookId == bookId).FirstOrDefaultAsync();
                if (book.Equals(null))
                {
                    throw new Exception("No book available in book store with selected book id");
                }
                var price = book.Price;
                if (book.Stock >= numberOfBooks)
                {
                    cart = new Cart()
                    {
                        UserId = userId,
                        BookId = bookId,
                        NumberOfBooks = numberOfBooks,
                        Price = numberOfBooks * price
                    };
                    await applicationDBContext.Carts.AddAsync(cart);
                    await applicationDBContext.SaveChangesAsync();
                    return await applicationDBContext.Carts
                       .Where(c => c.UserId == userId)
                       .Join(applicationDBContext.Books
                       .Where(b => b.BookId == bookId),
                       c => c.BookId,
                       b => b.BookId,
                       (c, b) => new CartResponse
                       {
                           Price = c.Price,
                           UserId = c.UserId,
                           BookTitle = b.Title,
                           Quantity = c.NumberOfBooks
                       }).FirstOrDefaultAsync();
                }
                else
                {
                    if (book.Stock > 0)
                    {
                        throw new Exception("Selected Quantity is more than available stock.");
                    }
                    throw new Exception("Out of Stock.");
                }
            
            return await UpdateABookInCart(userId, bookId, numberOfBooks + cart.NumberOfBooks);
        }

        public async Task<CartResponse> UpdateABookInCart(int userId, int bookId, int numberOfBooks)
        {
            var cart = await applicationDBContext.Carts.Where(c => c.UserId == userId && c.BookId == bookId).FirstOrDefaultAsync();
            if (cart.Equals(null))
            {
                throw new Exception("No book in cart with selected book id.");
            }
            cart.Price = (cart.Price / cart.NumberOfBooks) * (numberOfBooks);
            cart.NumberOfBooks = numberOfBooks;
            applicationDBContext.Carts.Update(cart);
            await applicationDBContext.SaveChangesAsync();
            return await applicationDBContext.Carts
                    .Where(c => c.UserId == userId)
                    .Join(applicationDBContext.Books
                    .Where(b => b.BookId == bookId),
                    c => c.BookId,
                    b => b.BookId,
                    (c, b) => new CartResponse
                    {
                        Price = c.Price,
                        UserId = c.UserId,
                        BookTitle = b.Title,
                        Quantity = c.NumberOfBooks
                    }).FirstOrDefaultAsync();
        }

        public async Task<List<CartResponse>> DeleteABookInCart(int userId, int bookId)
        {
            var cart = await applicationDBContext.Carts.Where(c => c.UserId == userId && c.BookId == bookId).FirstOrDefaultAsync();
            if (cart.Equals(null))
            {
                throw new Exception("No book in cart with selected book id.");
            }
            applicationDBContext.Carts.Remove(cart);
            await applicationDBContext.SaveChangesAsync();
            return await applicationDBContext.Carts
                .Where(c => c.UserId == userId)
                .Join(applicationDBContext.Books,
                c => c.BookId,
                b => b.BookId,
                (c, b) => new CartResponse
                {
                    Price = c.Price,
                    UserId = c.UserId,
                    BookTitle = b.Title,
                    Quantity = c.NumberOfBooks
                }).ToListAsync();
        }
        //public async Task<List<CartResponse>> MoveABookToWishList(int userId, int bookId)
        //{
        //    var cart = await applicationDBContext.Carts.Where(c => c.UserId == userId && c.BookId == bookId).FirstOrDefaultAsync();
        //    if (cart.Equals(null))
        //    {
        //        throw new Exception("No book in cart with selected book id.");
        //    }
        //    applicationDBContext.Carts.Remove(cart);
        //    await applicationDBContext.SaveChangesAsync();
        //    await AddABookToWishList(userId, bookId);
        //    return await applicationDBContext.Carts
        //        .Where(c => c.UserId == userId)
        //        .Join(applicationDBContext.Books,
        //        c => c.BookId,
        //        b => b.BookId,
        //        (c, b) => new CartResponse
        //        {
        //            Price = c.Price,
        //            UserId = c.UserId,
        //            BookTitle = b.Title,
        //            Quantity = c.NumberOfBooks
        //        }).ToListAsync();
        //}
    }
}

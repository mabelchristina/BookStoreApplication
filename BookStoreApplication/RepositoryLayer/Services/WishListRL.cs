using CommonModel.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class WishListRL : IWishListRL
    {
        public readonly BookStoreDBContext context;
        public WishListRL(BookStoreDBContext context)
        {
            this.context = context;
        }
        public Task<int> AddBooksToWishlist(Wish books)
        {
            this.context.Wish.Add(books);
            var result = this.context.SaveChangesAsync();
            return result;
        }
        public List<BookWishlistResponse> GetAllWishlistBooks()
        {
            List<BookWishlistResponse> books = new List<BookWishlistResponse>();
            var wishlistData = this.context.Wish.Join(this.context.Books,
                WishList => WishList.BookId,
                Book => Book.BookId,
                (WishList, Book) =>
                new BookWishlistResponse
                {
                    BookId = Book.BookId,
                    BookTitle = Book.BookTitle,
                    AuthorName = Book.AuthorName,
                    Price = Book.Price,
                    BookImage = Book.BookImage,
                    WishListId = WishList.WishListId,
                    UserId = WishList.UserId
                });
            foreach (var data in wishlistData)
            {
                
                    books.Add(data);
                
            }
            return books;
        }
        public Wish DeleteBookFromWishlist(int wishlistId)
        {
            var cartModel = context.Wish.Find(wishlistId);
            if (cartModel != null)
            {
                context.Wish.Remove(cartModel);
                context.SaveChanges();
            }
            return cartModel;
        }
        public int GetWishlistCount(int userId)
        {
            var result = context.Wish.Where<Wish>(item => item.UserId == userId).ToList();
            return result.Count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModel.Models
{
    public class BookWishlistResponse
    {
        public int WishListId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public double Price { get; set; }
        public string BookImage { get; set; }
    }
}

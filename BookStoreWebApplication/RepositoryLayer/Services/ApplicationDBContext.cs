using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cart>()
                .HasKey(c => new { c.UserId, c.BookId });
            modelBuilder.Entity<WishList>()
               .HasKey(c => new { c.UserId, c.BookId });
            modelBuilder.Entity<UserAddress>()
               .HasKey(c => new { c.UserId });
            modelBuilder.Entity<Order>()
              .HasKey(c => new { c.UserId,c.BookId,c.AddressId });
        }
    }
}

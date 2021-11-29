using CommonModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<Wish> Wish { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                Name = "Mabel",
                Email = "Mabel@gmail.com",
                Password = "Mabel@123"
            }, new User
            {
                UserId = 2,
                Name = "John",
                Email = "John@gmail.com",
                Password = "John@123"
            }, new User
            {
                UserId = 3,
                Name = "Sam",
                Email = "Sam@gmail.com",
                Password = "Sam@123"
            }, new User
            {
                UserId = 4,
                Name = "Joy",
                Email = "Joy@gmail.com",
                Password = "Joy@123"
            },
             new User
             {
                 UserId = 5,
                 Name = "Jane",
                 Email = "Jane@gmail.com",
                 Password = "Jane@123"
             }
            );
    }
    }
}

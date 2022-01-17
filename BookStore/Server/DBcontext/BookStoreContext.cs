using BookStore.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Client.Contract;

namespace BookStore.Server.DBcontext
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "power", Description = "nothing"},
                new Book { Id = 2, Title = "I,Tonya", Description = "nothing"}
            );


            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fiction" },
                new Category { Id = 2, Name = "Biology" },
                new Category { Id = 3, Name = "Novel" },
                new Category { Id = 4, Name = "Thriller" },
                new Category { Id = 5, Name = "Romance" }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "New World"}
            );
        }
        public IBookContract IBookContract;
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}

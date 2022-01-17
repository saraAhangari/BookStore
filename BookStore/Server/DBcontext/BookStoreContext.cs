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
                new Book { Id = 1, Title = "The Forty Rules of Love", Description = "nothing"},
                new Book { Id = 2, Title = "The Gaze", Description = "nothing"}
            );


            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fiction" },
                new Category { Id = 2, Name = "Biology" },
                new Category { Id = 3, Name = "Novel" },
                new Category { Id = 4, Name = "Thriller" },
                new Category { Id = 5, Name = "Romance" }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "New World"},
                new Publisher { Id = 2, Name = "Pearson" },
                new Publisher { Id = 3, Name = "ThomsonReuters" },
                new Publisher { Id = 4, Name = "Wolters Kluwer" },
                new Publisher { Id = 5, Name = "Reed Elsevier" }
            );

            modelBuilder.Entity<Author>().HasData(
               new Author { Id = 1, Firstname= "Elif", Lastname= "Shafak", Email= "Shafak2@gmail.com"
               , phone= "444-885-781"}
           );
        }
        public IBookContract IBookContract;
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}

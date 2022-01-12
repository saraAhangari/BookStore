using BookStore.Shared.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Client.Contract
{
    public interface IBookContract
    {
        event Action OnChange;
        List<Category> categories { get; set; }
        List<Book> books { get; set; }
        List<Author> authors { get; set; }
        List<Publisher> publishers { get; set; }
        Task<List<Book>> GetBooks();
        Task GetCategories();
        Task GetPublishers();
        Task<Book> GetBookById(int id);
        Task<List<Book>> CreateBook(Book book);
        Task<List<Book>> UpdateBook(Book book, int id);
        Task<List<Book>> DeleteBook(int id);

    }
}
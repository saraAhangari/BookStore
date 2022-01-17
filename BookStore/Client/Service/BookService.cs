using BookStore.Client.Contract;
using BookStore.Shared.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BookStore.Client.Service
{
    public class BookService : IBookContract
    {
        public HttpClient _httpClient { get; }
        public List<Category> categories { get; set; } = new List<Category>();
        public List<Book> books { get; set; } = new List<Book>();
        public List<Publisher> publishers { get; set; } = new List<Publisher>();
        public List<Author> authors { get; set; } = new List<Author>();

        public event Action OnChange;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Book>> CreateBook(Book book)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/book", book);
            books = await result.Content.ReadFromJsonAsync<List<Book>>();
            OnChange.Invoke();
            return books;
        }

        public async Task<List<Book>> DeleteBook(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/book/{id}");
            books = await result.Content.ReadFromJsonAsync<List<Book>>();
            OnChange.Invoke();
            return books;
        }

        public async Task GetCategories()
        {
            categories = await _httpClient.GetFromJsonAsync<List<Category>>("api/book/categories");
        }

        public async Task GetPublishers()
        {
            publishers = await _httpClient.GetFromJsonAsync<List<Publisher>>("api/book/publishers");
        }
        public async Task GetAuthors()
        {
            authors = await _httpClient.GetFromJsonAsync<List<Author>>("api/book/authors");
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Book>($"api/book/{id}");
        }
        public async Task<List<Book>> GetBooks()
        {
            books = await _httpClient.GetFromJsonAsync<List<Book>>("api/book");
            return books;
        }

        public async Task<List<Book>> UpdateBook(Book book, int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/book/{id}", book);
            books = await result.Content.ReadFromJsonAsync<List<Book>>();
            OnChange.Invoke();
            return books;
        }
    }
}

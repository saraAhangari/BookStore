using BookStore.Shared.Model;
using BookStore.Server.DBcontext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace BookStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookStoreContext _context;

        public BookController(BookStoreContext context)
        {
            _context = context;
        }
        private async Task<List<Book>> GetDbBooks()
        {
            return await _context.Books.Include(b => b.Category)
                .Include(a => a.publisher)
                .ToListAsync();
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpGet("publishers")]
        public async Task<IActionResult> GetPublishers()
        {
            return Ok(await _context.publishers.ToListAsync());
        }

        [HttpGet("authors")]
        public async Task<IActionResult> GetAuthors()
        {
            return Ok(await _context.Authors.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return base.Ok(await GetDbBooks());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.publisher)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
                return NotFound("Book wasn't found. Too bad. :(");

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book)
        {
            try
            {
                UpdateBookAuthors(book);
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var x = ex;
            }

            return Ok(await GetDbBooks());
        }

        private void UpdateBookAuthors(Book book)
        {
            List<Author> oldAuthors = new List<Author>();
            List<Author> newAuthors = new List<Author>();
            if (book.Authors != null)
            {
                foreach (var item in book.Authors)
                {
                    var author = _context.Authors.Where(a => a.Lastname.Equals(item.Lastname)).FirstOrDefault();
                    if (author != null)
                    {
                        oldAuthors.Add(item);
                        newAuthors.Add(author);
                    }
                }

                foreach (var item in oldAuthors)
                {
                    book.Authors.Remove(item);
                }
                foreach (var item in newAuthors)
                {
                    book.Authors.Add(item);
                }

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Book book, int id)
        {
            var dbBook = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.publisher)
                .Include(b => b.Authors)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (dbBook == null)
                return NotFound("Book wasn't found. Too bad. :(");

            dbBook.Title = book.Title;
            dbBook.Description = book.Description;
            dbBook.categoryId = book.categoryId;
            dbBook.publisherId = book.publisherId;
            dbBook.Authors = book.Authors;

            await _context.SaveChangesAsync();
            return Ok(await GetDbBooks());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var dbBook = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.publisher)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (dbBook == null)
                return NotFound("Book wasn't found. Too bad. :(");

            _context.Books.Remove(dbBook);

            await _context.SaveChangesAsync();
            return Ok(await GetDbBooks());
        }

    }
}
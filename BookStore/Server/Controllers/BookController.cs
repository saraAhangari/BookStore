using BookStore.Shared.Model;
using BookStore.Server.DBcontext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book)
        {
            _context.Books.Add(book);

            await _context.SaveChangesAsync();
            return Ok(await GetDbBooks());
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Book book, int id)
        {
            var dbBook = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.publisher)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (dbBook == null)
                return NotFound("Book wasn't found. Too bad. :(");

            dbBook.Title = book.Title;
            dbBook.Description = book.Description;
            dbBook.categoryId = book.categoryId;
            dbBook.publisherId = book.publisherId;

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

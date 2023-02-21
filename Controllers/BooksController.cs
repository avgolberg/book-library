using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using BookLibrary.Extensions;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookLibraryContext _context;

        public BooksController(BookLibraryContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books
                                    .Include(b => b.Authors)
                                    .Include(b => b.BookTypes)
                                    .Include(b => b.CoverTypes)
                                    .Include(b => b.Genres)
                                    .Include(b => b.Language)
                                    .Include(b => b.Publisher)
                                    .ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _context.Entry(book).Collection(b => b.Authors).Load();
            _context.Entry(book).Collection(b => b.BookTypes).Load();
            _context.Entry(book).Collection(b => b.CoverTypes).Load();
            _context.Entry(book).Collection(b => b.Genres).Load();
            _context.Entry(book).Reference(b => b.Language).Load();
            _context.Entry(book).Reference(b => b.Publisher).Load();

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Books/add-to-favourites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        [Route("add-to-favourites")]
        public async Task<ActionResult<Book>> AddToFavourites(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            var user = _context.Users.FirstOrDefault(u => u.Email.Equals(GetCurrentUserEmail()));

            _context.Entry(user).Collection(u => u.FavouriteBooks).Load();

            if (book == null || user == null)
            {
                return NotFound();
            }

            if (user.FavouriteBooks == null)
                user.FavouriteBooks = new List<Book>();

            if (user.FavouriteBooks.Contains(book))
                return BadRequest();

            user.FavouriteBooks.Add(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Books/delete-from-favourites
        [HttpDelete]
        [Authorize]
        [Route("delete-from-favourites")]
        public async Task<IActionResult> DeleteFromFavourites(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            var user = _context.Users.FirstOrDefault(u => u.Email.Equals(GetCurrentUserEmail()));

            _context.Entry(user).Collection(u => u.FavouriteBooks).Load();

            if (book == null || user == null || user.FavouriteBooks == null)
            {
                return NotFound();
            }

            if (!user.FavouriteBooks.Contains(book))
                return BadRequest();

            user.FavouriteBooks.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        private string GetCurrentUserEmail()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity == null)
                return null;

            return identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        }
    }
}

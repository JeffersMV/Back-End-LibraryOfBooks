using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryOfBooksServer.Models;

namespace LibraryOfBooksServer.Controllers
{
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class BooksController : Controller
    {
        private readonly AppDatabaseContext _context;

        public BooksController(AppDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _context.Books.Include(book => book.Genre);
        }

        [HttpGet("{id}")]
        public IQueryable<Book> Get(int id)
        {
            return _context.Books.Where(book => book.Id == id).Include(book => book.Genre);
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        public IQueryable<Book> Post([FromBody] Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            var bookId = _context.Books.LastOrDefault();
            return _context.Books.Where(b => b.Id == bookId.Id).Include(b => b.Genre);
        }

        [HttpPut("{id}")]
        public IQueryable<Book> Put(int id, [FromBody] Book book)
        {
            if (id == book.Id)
            {
                _context.Update(book);
                _context.SaveChanges();
            }

            return _context.Books.Where(b => b.Id == id).Include(b => b.Genre);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Books.Remove(_context.Books.Find(id));
            _context.SaveChanges();
        }
    }
}
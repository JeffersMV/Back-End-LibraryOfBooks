using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using LibraryOfBooksServer.Models;

namespace LibraryOfBooksServer.Controllers
{

    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class GenresController : Controller
    {
        private readonly AppDatabaseContext _context;

        public GenresController(AppDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Genre> Get()
        {
            return _context.Genres.Include(genre => genre.Books);
        }

        [HttpGet("{id}")]
        public IQueryable<Genre> Get(int id)
        {
            return _context.Genres.Where(genre => genre.Id == id).Include(genre => genre.Books);
        }

        [HttpPost]
        public Genre Post([FromBody] Genre genre)
        {
            Console.WriteLine(genre.Name);////////
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return _context.Genres.LastOrDefault();
        }

        [HttpPut("{id}")]
        public IQueryable<Genre> Put(int id, [FromBody] Genre genre)
        {
            if (id == genre.Id)
            {
                _context.Update(genre);
                _context.SaveChanges();
            }
            return _context.Genres.Where(g => g.Id == id).Include(g => g.Books);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Genres.Remove(_context.Genres.Find(id));
            _context.SaveChanges();
        }
    }
}
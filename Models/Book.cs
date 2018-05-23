//using System;

using System;

namespace LibraryOfBooksServer.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
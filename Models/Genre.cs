using System.Collections.Generic;

namespace LibraryOfBooksServer.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public override string ToString() { return Name; }
        
        
    }
}



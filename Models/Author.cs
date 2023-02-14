using System.Collections.Generic;

namespace BookLibrary.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public string Information { get; set; }

    }
}
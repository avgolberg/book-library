using System.Collections.Generic;

namespace BookLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
        public string Annotation { get; set; }
        public int Pages { get; set; }
        public Publisher Publisher { get; set; }
        public Language Language { get; set; }
        public List<CoverType> CoverTypes { get; set; }
        public List<BookType> BookTypes { get; set; }

        public List<User> Users { get; set; }
    }
}

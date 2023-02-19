using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
        public string Annotation { get; set; }
        [Range(1, Double.PositiveInfinity)]
        public int Pages { get; set; }
        public Publisher Publisher { get; set; }
        public Language Language { get; set; }
        public List<CoverType> CoverTypes { get; set; }
        public List<BookType> BookTypes { get; set; }

        public ICollection<User> Users { get; set; }
    }
}

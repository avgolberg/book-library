using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class BookModel
    {
        public string Title { get; set; }
        public List<int> AuthorsIds { get; set; }
        public List<int> GenresIds { get; set; }
        public string Annotation { get; set; }
        [Range(1, Double.PositiveInfinity)]
        public int Pages { get; set; }
        public int PublisherId { get; set; }
        public int LanguageId { get; set; }
        public List<int> CoverTypesIds { get; set; }
        public List<int> BookTypesIds { get; set; }
    }
}

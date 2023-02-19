using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class BookType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

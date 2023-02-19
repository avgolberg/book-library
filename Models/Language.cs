using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Language
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
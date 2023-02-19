using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Information { get; set; }
    }
}
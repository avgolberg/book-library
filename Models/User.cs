using System.Collections.Generic;

namespace BookLibrary.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<Book> Favourites { get; set; }
        public bool IsAdmin { get; set; }
    }
}

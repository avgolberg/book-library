using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BookLibrary.Models
{
    public class User : IdentityUser
    {
        public ICollection<Book> FavouriteBooks { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WAD_DATABASE.Models
{
    public class AppUser : IdentityUser
    {
        //[Key]
        //public string? Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }

        public ICollection<Games>? Games { get; set; }

        public ICollection<News>? News { get; set; }

    }
}

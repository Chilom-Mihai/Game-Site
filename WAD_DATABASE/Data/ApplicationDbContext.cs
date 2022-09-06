using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WAD_DATABASE.Models;

namespace WAD_DATABASE.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<News> News { get; set; }
       
        public DbSet<Games> Games { get; set; }
        public DbSet<Home> Home { get; set; }
      
    }
}

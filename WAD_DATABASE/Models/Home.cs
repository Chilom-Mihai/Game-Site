using System.ComponentModel.DataAnnotations;

namespace WAD_DATABASE.Models
{
   
    
        public class Home
        {
            [Key]
            public int Id { get; set; }
            public string? NewGames { get; set; }


        }
    
}

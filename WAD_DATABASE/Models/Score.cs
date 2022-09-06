using System.ComponentModel.DataAnnotations;

namespace WAD_DATABASE.Models
{
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }

        //public ICollection<Games> Game { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Movie_Genres
    {
        [Key]
        public int MovId { get; set; }
        public int GenId { get; set; }

        public Movie Movie { get; set; }
        public Genres Genres { get; set; }
    }
}

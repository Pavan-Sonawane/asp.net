using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Genres
    {
        [Key]
        public int GenId { get; set; }
        public string GenTitle { get; set; }

        
        public List<Movie_Genres> Movies { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Movie_Direction
    {
        [Key]
        public int DirId { get; set; }
        public int MovId { get; set; }

        
        public Directors Director { get; set; }
        public Movie Movie { get; set; }
    }
}

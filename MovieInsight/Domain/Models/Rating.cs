using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Rating
    {
        [Key]
        public int MovId { get; set; }
        public int RevId { get; set; }
        public int RevStars { get; set; }
        public int NumOfRating { get; set; }

       
        public Movie Movie { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}

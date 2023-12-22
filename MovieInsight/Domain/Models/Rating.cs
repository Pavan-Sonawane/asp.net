using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Rating
    {
       
        public int MovId { get; set; }
        public int RevId { get; set; }
        public int RevStars { get; set; }
        public float NumOfRating { get; set; }
        public Movie Movie { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}

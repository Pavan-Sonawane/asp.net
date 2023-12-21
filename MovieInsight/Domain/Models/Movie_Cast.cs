using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Movie_Cast
    {
        [Key]
        public int ActId { get; set; }
        public int MovId { get; set; }
        public string Role { get; set; }

       
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genere { get; set; }

        public string? Director { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Directors
    {
        [Key]
        public int DirId { get; set; }
        public string DirFirstName { get; set; }
        public string DirLastName { get; set; }
        public DateTime DirDob { get; set; }

      
        public List<Movie_Direction> Movies { get; set; }
    }
}

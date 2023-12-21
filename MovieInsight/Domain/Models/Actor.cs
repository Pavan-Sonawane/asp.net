using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Actor
    {
        [Key]
        public int ActId { get; set; }
        public string ActFirstName { get; set; }
        public string ActLastName { get; set; }
        public string ActGender { get; set; }
        public DateTime ActDob { get; set; }
       
        public List<Movie_Cast> Movies { get; set; }
    }
}

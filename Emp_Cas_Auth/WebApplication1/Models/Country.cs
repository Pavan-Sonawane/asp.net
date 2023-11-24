using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public IList<State> states { get; set; }

        public IList<Employee> employees { get; set; }
    }
}

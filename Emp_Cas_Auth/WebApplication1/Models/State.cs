using WebApplication1.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class State
    {

        [Key]
        public int StateId { get; set; }

        [Required(ErrorMessage = "State Name is required.")]
        public string StateName { get; set; }

        [Required(ErrorMessage = "Country ID is required.")]
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}

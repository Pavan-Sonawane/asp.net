using WebApplication1.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key]
        [Required(ErrorMessage = "Employee ID is required.")]
        public int Emp_Id { get; set; }

        [Required(ErrorMessage = "Employee Name is required.")]
        public string Emp_Name { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        public string mobno { get; set; }

        [Required(ErrorMessage = "Department ID is required.")]
        public int Dept_Id { get; set; }

        [Required(ErrorMessage = "State ID is required.")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "City ID is required.")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Country ID is required.")]
        public int CountryId { get; set; }

        public Department department { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }

    }
}


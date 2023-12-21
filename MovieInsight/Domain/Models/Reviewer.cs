using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public  class Reviewer
    {
        [Key]
        public int RevId { get; set; }
        public string RevName { get; set; }
        public DateTime RevDob { get; set; }
        public string RevAddress { get; set; }
        public string RevCountry { get; set; }
        public string RevState { get; set; }
        public string RevCity { get; set; }
        public string RevPincode { get; set; }
        public string RevPhoneNumber { get; set; }

        public List<Rating> Ratings { get; set; }
    }
}

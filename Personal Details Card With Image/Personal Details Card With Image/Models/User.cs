using System.Globalization;

namespace Personal_Details_Card_With_Image.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Full_Name { get; set; }
        public string Contact_number { get; set; }
        public string Email { get; set; }
        public string Proffession { get; set; }
        public string Qualification { get; set; }
        public string Previeous_Company { get; set; }
        public string Previeous_CTC { get; set; }
        public string Working_Domain { get; set; }
        public byte[] Resume { get; set; } 
        public byte[] ProfileImage { get; set; }
    }
}

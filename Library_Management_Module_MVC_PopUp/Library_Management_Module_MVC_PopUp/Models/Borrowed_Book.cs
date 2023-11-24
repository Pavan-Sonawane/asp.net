using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Library_Management_Module_MVC_PopUp.Models
{
    public class Borrowed_Book
    {
        [Key]
        public int BorrowedID { get; set; }

        [Required(ErrorMessage = "BookID is required")]
        public int BookID { get; set; }

        [Required(ErrorMessage = "UserID is required")]
        public int UserID { get; set; }

        [DataType(DataType.Date)]
       
        [Display(Name = "Borrow Date")]
        public DateTime BorrowDate { get; set; }

        [DataType(DataType.Date)]
        
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }
        [Required(ErrorMessage = "UserID is required")]
        
        public User User { get; set; }  

        [Required(ErrorMessage = "BookID is required")]
       
        public Book Book { get; set; }
    }
}

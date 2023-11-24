using System.ComponentModel.DataAnnotations;

namespace Library_Management_Module_MVC_PopUp.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
       
        public string ISBN { get; set; }

        public ICollection<Borrowed_Book> BorrowedBooks { get; set; }
    }
}

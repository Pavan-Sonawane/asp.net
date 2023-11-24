using System.ComponentModel.DataAnnotations;

namespace Library_Management_Module_MVC_PopUp.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string User_Name { get; set;}
        public ICollection<Borrowed_Book> BorrowedBooks { get; set; }
    }
}

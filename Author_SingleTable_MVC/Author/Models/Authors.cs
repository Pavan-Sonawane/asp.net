using Microsoft.CodeAnalysis.Operations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Author.Models
{
    public class Authors
    {
        [Key]
       
        public int BookID { get; set; }
        [DisplayName("Book Name")]
        [Required(ErrorMessage = "This Field is required.")]
        public string BookTitle { get; set; }
      
        [DisplayName("Author Name")]
        [Required(ErrorMessage = "This Field is required.")]
        public string AuthorName { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        [DisplayName("Page Count")]
       
        public int PageCount { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        [DisplayName("Price Of the Book")]
        public int Price { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        [DisplayName("Type Of Book ")]
      
        public string BookType { get; set; }
 
        [DisplayName("Quantity OF the Book")]
        [Required(ErrorMessage = "This Field is required.")]
        public int BookQuantity { get; set; }
        [Required(ErrorMessage = "This Field is required.")]
        [DisplayName("Rating Out Of 5")]
        public string Ratings { get; set; }
     
        public DateTime Date { get; set; }

    }
}

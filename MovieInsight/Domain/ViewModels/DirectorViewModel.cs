using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class DirectorViewModel
    {
        public int DirId { get; set; }
        public string DirFirstName { get; set; }
        public string DirLastName { get; set; }
        public DateTime DirDob { get; set; }


        public List<Movie_Direction> Movies { get; set; }
    }
    public class DirectorInsertModel
    {
        public int DirId { get; set; }
        public string DirFirstName { get; set; }
        public string DirLastName { get; set; }
        public DateTime DirDob { get; set; }

    }
}

using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class MovieDirectionViewModel
    {
        public int DirId { get; set; }
        public int MovId { get; set; }
        public string DirectorName { get; set; } 
        public string MovieTitle { get; set; }
    }
}

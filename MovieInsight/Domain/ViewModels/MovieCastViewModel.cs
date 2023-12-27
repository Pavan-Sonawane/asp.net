using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class MovieCastViewModel
    {
        public int ActId { get; set; }
        public int MovId { get; set; }
        public string Role { get; set; }
        public ActorViewModel Actor { get; set; } 
        public MovieViewModel Movie { get; set; }

    }
}

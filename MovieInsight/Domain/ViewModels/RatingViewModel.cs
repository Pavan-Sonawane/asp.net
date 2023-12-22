using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class RatingViewModel
    {
        public int MovId { get; set; }
        public int RevId { get; set; }
        public int RevStars { get; set; }
        public float NumOfRating { get; set; }
        public Movie Movie { get; set; }
        public Reviewer Reviewer { get; set; } 
    }
    public class RatingInsertModel
    {
        public int MovId { get; set; }
        public int RevId { get; set; } 
        public int RevStars { get; set; }
       
    }
}

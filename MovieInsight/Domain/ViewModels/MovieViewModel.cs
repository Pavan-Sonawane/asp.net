using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class MovieViewModel
    {
        public int MovId { get; set; }
        public string MovTitle { get; set; }
        public int MovYear { get; set; }
        public int MovTime { get; set; }
        public string MovLang { get; set; }
        public DateTime MovDtRel { get; set; }
        public string MovRelCountry { get; set; }

        public List<Movie_Genres> Genres { get; set; }
        public List<Movie_Direction> Directors { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Movie_Cast> Cast { get; set; }
    }

    public class MovieInsertModel
    {
        public int MovId { get; set; }
        public string MovTitle { get; set; }
        public int MovYear { get; set; }
        public int MovTime { get; set; }
        public string MovLang { get; set; }
        public DateTime MovDtRel { get; set; }
        public string MovRelCountry { get; set; }
    }
}

using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class ActorViewModel
    {
        public int ActId { get; set; }
        public string ActFirstName { get; set; }
        public string ActLastName { get; set; }
        public string ActGender { get; set; }
        public DateTime ActDob { get; set; }

      /*  public List<Movie_Cast> Movies { get; set; }*/
    }
    public class ActorInsertModel
    {
        public int ActId { get; set; }
        public string ActFirstName { get; set; }
        public string ActLastName { get; set; }
        public string ActGender { get; set; }
        public DateTime ActDob { get; set; }

    }
}

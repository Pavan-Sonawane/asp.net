using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels
{
    public class RoomViewModel
    {
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal RatePerNight { get; set; }
        public bool Availability { get; set; }

     
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.Models
{
    public  class Room
    {
        [Key]
        public int RoomNumber { get; set; } 
        public string RoomType { get; set; }
        public decimal RatePerNight { get; set; }
        public bool Availability { get; set; }

       
        public ICollection<Reservation> Reservations { get; set; }
    }
}

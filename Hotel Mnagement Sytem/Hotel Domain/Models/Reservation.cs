using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.Models
{
    public  class Reservation
    {
        public int ReservationId { get; set; } 
        public int GuestId { get; set; } 
        public string RoomType { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CheckInDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CheckOutDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ReservationDate { get; set; }
        public Guest Guest { get; set; }
     
        public Invoice Invoice { get; set; }
    }
}

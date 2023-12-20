using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels
{
    public class ReservationViewModel
    {
        public int ReservationId { get; set; }
        public int GuestId { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime ReservationDate { get; set; }

      
    }
    public class Reservation1ViewModel
    {
        public int ReservationId { get; set; }
        public int GuestId { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime ReservationDate { get; set; }

        public GuestViewModel Guest { get; set; }
        public InvoiceViewModel Invoice { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Models
{
    public class Booking
    {
        public int Booking_id { get; set; }
        public string Uid { get; set; }
        public int Show_id { get; set; }

        public float AmountPaid { get; set; }
        public int USSID { get; set; }
        public DateTime DateofBooking { get; set; }
        public int TicketRateID { get; set; }
        public int NoofTickets { get; set; }
        public int SeatStart { get; set; }
        public int SeatEnd { get; set; }
        public DateTime DateofShow { get; set; }

    }
}

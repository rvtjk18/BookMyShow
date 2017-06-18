using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Models
{
    public class UserSelectedSeats
    {
        public int Id { get; set; }
        public string UId { get; set; }
        public int ShowId { get; set; }
        public int SeatStart { get; set; }
        public int SeatEnd { get; set; }
        public DateTime DateofShow { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

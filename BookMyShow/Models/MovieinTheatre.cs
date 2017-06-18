
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Models
{
    public class MovieinTheatre
    {
        public int Show_id { get; set; }
        public int Movie_id { get; set; }
        public int Theatre_id { get; set; }
        public int TotalSeats { get; set; }
        public int ShowTimeId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}

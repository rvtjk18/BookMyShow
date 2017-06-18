using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Models
{
    public class Movies
    {
        public int Movie_id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string MovieLength { get; set; }

    }
}

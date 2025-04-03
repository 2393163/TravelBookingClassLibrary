using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookingClassLibrary.Entity
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        public int PackageID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}

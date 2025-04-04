using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClass.Entity
{
     public class Booking
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int PackageID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

       
        public int PaymentID { get; set; }
        public int? InsuranceID { get; set; }
        public Insurance? Insurance{ get; set; }
    }
}

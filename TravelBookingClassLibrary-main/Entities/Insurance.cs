using System.ComponentModel.DataAnnotations;

namespace InsuranceClass.Entity
{
    public class Insurance
    {
        [Key]
        public int InsuranceID { get; set; }

       
        public int? BookingID { get; set; }


        public string CoverageDetails { get; set; }
        public string Provider { get; set; }
        public List<Booking>? Bookings { get; set; } // Navigation property to Booking

    }
}

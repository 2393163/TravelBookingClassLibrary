namespace TravelBookingClassLibrary
{    
        public class Booking
    {
        
            public int BookingID { get; set; }
            public int UserID { get; set; }
            public int PackageID { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            public string Status { get; set; } = "Active";
            public int PaymentID { get; set; }
            //public Payment Payment { get; set; } // Navigation property

    }
}


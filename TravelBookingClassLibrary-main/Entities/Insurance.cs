using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace TravelBookingClassLibrary.Entity
{
    public class Insurance
    {
        [Key]
        public int InsuranceID { get; set; }

        public int UserID { get; set; }
        public int BookingID { get; set; }
        public required string CoverageDetails { get; set; }
        public required string Provider { get; set; }
        public string Status { get; set; } = "Active";
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

    }
}


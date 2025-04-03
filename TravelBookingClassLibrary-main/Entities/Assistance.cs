using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TravelBookingClassLibrary.Entity
{
    public class Assistance
    {
        [Key]
        public int RequestID { get; set; }
        public int UserID { get; set; }
        public required string IssueDescription { get; set; }
        public string Status { get; set; } = "Active";
        public DateTime ResolutionTime { get; set; }

        // Navigation property to the User entity
        public required User User { get; set; }
    }

}

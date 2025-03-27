using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookingClassLibrary.Class
{
    public class Assistance
    {
        [Key]
        public int RequestID { get; set; }
        public int UserID { get; set; }
        public string IssueDescription { get; set; }
        public string Status { get; set; } = "Active";
        public DateTime ResolutionTime { get; set; }
    }
}

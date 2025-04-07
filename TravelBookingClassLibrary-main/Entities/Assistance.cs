using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAssistance.Entity
{
    public class Assistance
    {
        [Key]
        public int RequestID { get; set; } // Auto-increment primary key
        public int UserID { get; set; }
        public string IssueDescription { get; set; }
        public string? Status { get; set; } = "Active"; // Default: "Active"
        public int? ResolutionTime { get; set; }
    }
}

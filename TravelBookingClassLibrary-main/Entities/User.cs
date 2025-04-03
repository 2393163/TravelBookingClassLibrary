using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookingClassLibrary.Entity
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        

        // Navigation properties to link with related entities
        public required List<Insurance> Insurances { get; set; }
        public required List<Assistance> AssistanceRequests { get; set; }
    }
}

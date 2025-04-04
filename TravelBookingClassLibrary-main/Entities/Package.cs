using System.ComponentModel.DataAnnotations;

namespace TravelBookingClassLibrary
{
    public class Package
    {
        [Key]
        public int PackageID { get; set; }

        [Required(ErrorMessage = "Please enter the Title")]
        [MaxLength(5000, ErrorMessage = "The Title must not exceed 5000 characters")]
        public string Title { get; set; }

        [MaxLength(5000, ErrorMessage = "The Description must not exceed 5000 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the Duration")]
        [Range(1, 1000, ErrorMessage = "The Duration must be between 1 and 1000 days")] // Replace MaxLength
        public int Duration { get; set; }

        [Required(ErrorMessage = "Please enter the Price")]
        [Range(1, 1000000, ErrorMessage = "The Price must be between 1 and 1,000,000")] // Replace MaxLength
        public long Price { get; set; }

        [MaxLength(5000, ErrorMessage = "The Included Services must not exceed 5000 characters")]
        public string IncludedServices { get; set; }

        [Required(ErrorMessage = "Please enter the Category")]
        [MaxLength(5000, ErrorMessage = "The Category must not exceed 5000 characters")]
        public string Category { get; set; }
    }
}

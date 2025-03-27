using System.ComponentModel.DataAnnotations;


namespace travelpackage
{
    using System.ComponentModel.DataAnnotations;

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
        [MaxLength(5000, ErrorMessage = "The Duration must not exceed 5000 characters")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Please enter the Price")]
        [MaxLength(5000, ErrorMessage = "The Price must not exceed 5000 characters")]
        public long Price { get; set; }

        [MaxLength(5000, ErrorMessage = "The Included Services must not exceed 5000 characters")]
        public string IncludedServices { get; set; }


    }


}

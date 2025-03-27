
namespace TravelBookingSystem
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int UserID {  get; set; }
        public int PackageId {  get; set; }
        public int Rating {  get; set; }
        public string Comment {  get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

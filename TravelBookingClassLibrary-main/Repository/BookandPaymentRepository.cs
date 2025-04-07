using InsuranceClass.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceClass.Data;
namespace InsuranceClass.Repository
{
    public class BookingRepository
    {

        public void AddBooking(Booking booking)

        {

            using (var context = new InsuranceContext())

            {

                context.Bookings.Add(booking);

                context.SaveChanges();

            }

        }

        public List<Booking> GetAllBookings()

        {

            using (var context = new InsuranceContext())

            {

                var insurances = context.Bookings.ToList();

                return insurances;

            }
        }


        public void updateBooking(int BookingID, DateTime StartDate)
        {
            using (var context = new InsuranceContext())
            {
                var user = context.Bookings.Find(BookingID);
                if (user != null)
                {
                    user.StartDate = StartDate;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteBooking(int BookingID)
        {
            using (var dbContext = new InsuranceContext())
            {
                var user = dbContext.Bookings.Find(BookingID);
                if (user != null)
                {
                    dbContext.Bookings.Remove(user);
                    dbContext.SaveChanges();
                }
            }
        }
        //public Insurance GetInsuranceByUserID(int userID)
        //{
        //    using (var context = new InsuranceandAssistanceContext())
        //    {
        //        return context.Insurances.FirstOrDefault(i => i.UserID == userID);
        //    }
        //}

        public List<Insurance> GetInsuranceByProvider(string provider)
        {
            using (var context = new InsuranceContext())
            {
                return context.Insurances.Where(i => i.Provider.Contains(provider)).ToList();
            }
        }

        //public List<Insurance> GetInsurancesByDateRange(DateTime startDate, DateTime endDate)
        //{
        //    using (var context = new InsuranceandAssistanceContext())
        //    {
        //        return context.Insurances
        //            .Where(i => i.PurchaseDate >= startDate && i.PurchaseDate <= endDate)
        //            .ToList();
        //    }
        //}
        //public List<Insurance> GetInsuranceByPackage(string package)
        //{
        //    using (var context = new InsuranceandAssistanceContext())
        //    {
        //        return context.Insurances.Where(i => i.PackageID.Contains(package)).ToList();
        //    }
        //}
        public int GetTotalInsuranceCount()
        {
            using (var context = new InsuranceContext())
            {
                return context.Insurances.Count();
            }
        }


       
        
            public void AssignInsuranceAndUpdateInsuranceTable(Booking booking)
            {
                using (var context = new InsuranceContext())
                {
                    // Calculate the difference between StartDate and EndDate
                    var daysDifference = (booking.EndDate - booking.StartDate)?.Days;

                    if (daysDifference == null)
                        throw new ArgumentException("EndDate or StartDate cannot be null.");

                    // Select the appropriate insurance based on the difference
                    Insurance insurance = null;

                    if (daysDifference == 3)
                    {
                        insurance = context.Insurances.FirstOrDefault(i => i.InsuranceID == 1);
                    }
                    else if (daysDifference == 5)
                    {
                        insurance = context.Insurances.FirstOrDefault(i => i.InsuranceID == 2);
                    }
                    else if (daysDifference == 10)
                    {
                        insurance = context.Insurances.FirstOrDefault(i => i.InsuranceID == 3);
                    }

                    // Ensure the appropriate insurance exists
                    if (insurance == null)
                    {
                        throw new Exception($"No matching insurance found for {daysDifference} days.");
                    }

                    // Assign the insurance ID to the booking
                    booking.InsuranceID = insurance.InsuranceID;

                    // Add the booking to the insurance's list of bookings
                    if (insurance.Bookings == null)
                    {
                        insurance.Bookings = new List<Booking>();
                    }
                    insurance.Bookings.Add(booking);

                    // Save the changes to the database
                    context.Bookings.Add(booking); // Add the booking to the Bookings table
                    context.Insurances.Update(insurance); // Update the Insurance table with the booking list
                    context.SaveChanges();
                }
            }
        




    }
}


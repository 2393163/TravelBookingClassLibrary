using Microsoft.EntityFrameworkCore;
using TravelBookingClassLibrary;
using System;
public class BookandPaymentRepository
{
    public void AddBooking(Booking booking)
    {
        using(var context = new BookingPaymentContext())
        {
            context.Bookings.Add(booking);
            context.SaveChanges();
        }
    }
    public List<Booking> GetAllUsers()
    {
        using (var context = new BookingPaymentContext())
        {
            var bookings = context.Bookings.ToList<Booking>();
            return bookings;
        }
    }
    public List<Booking> GetBookingsByBookingID(int BookingID)
    {
        using (var context = new BookingPaymentContext())
        {
            var bookings = context.Bookings.Where(a => a.BookingID == BookingID).ToList();
            return bookings;
        }
    }

    public  void updateBooking(int BookingID, DateTime StartDate)
    {
        using (var context = new BookingPaymentContext())
        {
            var user = context.Bookings.Find(BookingID);
            if(user != null)
            {
                user.StartDate = StartDate;
                context.SaveChanges();
            }
        }
    }
    //public static void cancelBooking(int BookingID)
    //{
    //    using (var context = new BookingPaymentContext())
    //    {
    //        var booking = context.Bookings.Find(BookingID);
    //        if (booking != null)
    //        {
    //            booking.Status = "Cancelled";
    //            context.SaveChanges();
    //        }
    //    }
    //}
    public void DeleteBooking(int BookingID)
    {
        using(var dbContext = new BookingPaymentContext())
        {
            var user = dbContext.Bookings.Find(BookingID);
            if(user != null)
            {
                dbContext.Bookings.Remove(user);
                dbContext.SaveChanges();
            }
        }
    }

}


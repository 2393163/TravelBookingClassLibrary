using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace TravelBookingClassLibrary
{
    public class BookingPaymentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= localhost;Initial Catalog=TravelBookingDb; Integrated Security =true; TrustServerCertificate=true");
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }

        //        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //        {
        //            modelBuilder.Entity<Booking>()
        //                .HasKey(b => b.BookingID);
        //            modelBuilder.Entity<Payment>()
        //                .HasKey(p => p.PaymentID);
        //            modelBuilder.Entity<Booking>()
        //                .HasOne<Payment>()
        //                .WithMany()
        //                .HasForeignKey(b => b.PaymentID)
        //                .OnDelete(DeleteBehavior.Cascade);
        //            modelBuilder.Entity<Payment>()
        //                .HasOne<Booking>()
        //                .WithMany()
        //                .HasForeignKey(p => p.BookingID)
        //                .OnDelete(DeleteBehavior.Cascade);
        //        }
        //    
        //
    }
}

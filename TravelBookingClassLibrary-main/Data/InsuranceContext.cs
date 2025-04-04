using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceClass.Entity;
using Microsoft.EntityFrameworkCore;
//using TravelBookingClassLibrary.Entity;
namespace InsuranceClass.Data
{
    public class InsuranceContext : DbContext
    {
       

        //public DbSet<User> Users { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace connection string with your actual database details
            optionsBuilder.UseSqlServer("Data Source=LTIN593162;Initial Catalog=InsuranceDatabases;Integrated Security=True;TrustServerCertificate=true");
        }
    }

}
    


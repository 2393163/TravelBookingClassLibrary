using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelBookingClassLibrary.Class;
namespace TravelBookingClassLibrary.Data
{
    public class InsuranceandAssistanceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= LTIN593162;Initial Catalog=TravelBookingDb; Integrated Security =true; TrustServerCertificate=true");
        }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Assistance> Assistances { get; set; }
    }
}
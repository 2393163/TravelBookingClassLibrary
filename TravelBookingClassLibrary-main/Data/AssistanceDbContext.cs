using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TravelAssistance.Entity;
//using TravelBookingClassLibrary.Entity;
namespace TravelAssistance.Data
{
    public class AssistanceContext : DbContext
    {


        //public DbSet<User> Users { get; set; }
        public DbSet<Assistance> Assistances { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace connection string with your actual database details
            optionsBuilder.UseSqlServer("Data Source=LTIN593162;Initial Catalog=AssistanceDatabases;Integrated Security=True;TrustServerCertificate=true");
        }
    }

}



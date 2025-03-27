using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingClassLibrary.Entities;
using Microsoft.Extensions.Configuration;

namespace TravelBookingClassLibrary.Data
{
    public class AppDbContext : DbContext
    {
       // private readonly IConfiguration _configuration;
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;User=sa;Password=root;Initial Catalog=TravelBookingDB;Integrated Security=True;TrustServerCertificate=true");

            }
        }

        public DbSet<User> Users { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace TravelBookingSystem
{
    public class ReviewsDbContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = LTIN593805; Initial Catalog = TravelReviews; Integrated Security = true; TrustServerCertificate = true; ");
        }
       

    }
}


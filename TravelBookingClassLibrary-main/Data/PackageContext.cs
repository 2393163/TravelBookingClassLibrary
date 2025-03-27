using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace travelpackage
{

    public class AppDbContext : DbContext
    {
        public DbSet<Package> Packages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LTIN593446;Initial Catalog=travelpackage;Integrated Security=True;TrustServerCertificate=true");
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using travelpackage;

namespace TravelBooking.Models.Repository
{
    public class PackageRepository
    {
        private readonly AppDbContext _context;

        public PackageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddPackagesAsync(Package newpackage)
        {
            await _context.Packages.AddAsync(newpackage); // Asynchronous Add
            await _context.SaveChangesAsync(); // Asynchronous Save
        }

        public async Task<List<Package>> GetAllPackagesAsync()
        {
            return await _context.Packages.ToListAsync(); // Asynchronous ToList
        }

        public async Task<List<Package>> GetPackageBytitleAsync(string title)
        {
            var packages = await _context.Packages
                                         .Where(a => a.Title == title)
                                         .ToListAsync(); // Asynchronous Where and ToList
            foreach (var res in packages)
            {
                Console.WriteLine(res.ToString());
            }
            return packages;
        }

        public async Task<List<Package>> GetPackageByPackageIdAsync(int packageid)
        {
            var packages = await _context.Packages
                                         .Where(a => a.PackageID == packageid)
                                         .ToListAsync(); // Asynchronous Where and ToList
            foreach (var res in packages)
            {
                Console.WriteLine(res.ToString());
            }
            return packages;
        }
        public async Task<List<Package>> GetPackageByPriceRangeAsync(long minPrice, long maxPrice)
        {
            return await _context.Packages
                                 .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                                 .ToListAsync();

        }

        public async Task<List<Package>> GetPackageByDurationAsync(int duration)
        {
            var packages = await _context.Packages
                                         .Where(a => a.Duration == duration)
                                         .ToListAsync(); // Asynchronous Where and ToList
            foreach (var res in packages)
            {
                Console.WriteLine(res.ToString());
            }
            return packages;
        }

        public async Task<List<Package>> GetPackageByPriceAsync(long price)
        {
            var packages = await _context.Packages
                                         .Where(a => a.Price == price)
                                         .ToListAsync(); // Asynchronous Where and ToList
            foreach (var res in packages)
            {
                Console.WriteLine(res.ToString());
            }
            return packages;
        }

        public async Task<List<Package>> GetPackageBypricedurationtitleAsync(long price, int duration, string title)
        {
            var packages = await _context.Packages
                                         .Where(p => p.Price <= price && p.Duration == duration && p.Title.Contains(title))
                                         .ToListAsync();
            return packages;
        }

        public async Task<List<Package>> GetPackageBypricedurationAsync(long price, int duration)
        {
            var packages = await _context.Packages
                                         .Where(p => p.Price == price && p.Duration == duration)
                                         .ToListAsync();
            return packages;
        }

        public async Task<List<Package>> GetPackageByincludedservicesAsync(string includedservices)
        {
            var packages = await _context.Packages
                                         .Where(p => p.IncludedServices.Contains(includedservices))
                                         .ToListAsync();
            return packages;
        }

        public async Task<List<Package>> GetPackageBydescriptionAsync(string description)
        {
            var packages = await _context.Packages
                                         .Where(p => p.Description.Contains(description))
                                         .ToListAsync();
            foreach (var res in packages)
            {
                Console.WriteLine(res.ToString());
            }
            return packages;
        }

        public async Task UpdatePackageAsync(int PackageID, string Title, string Description, int Duration, long Price, string IncludedServices)
        {
            var package = await _context.Packages.FindAsync(PackageID); // Asynchronous Find
            if (package != null)
            {
                package.Title = Title;
                package.Duration = Duration;
                package.Description = Description;
                package.Price = Price;
                package.IncludedServices = IncludedServices;

                await _context.SaveChangesAsync(); // Asynchronous Save
            }
        }

        public async Task DeletePackageAsync(int PackageId)
        {
            var package = await _context.Packages.FindAsync(PackageId); // Asynchronous Find
            if (package != null)
            {
                _context.Packages.Remove(package);
                await _context.SaveChangesAsync(); // Asynchronous Save
            }
        }
    }
}

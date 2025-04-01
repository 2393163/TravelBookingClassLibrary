﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using travelpackage;

namespace TravelBooking.Models.Repository
{
    public class PackageRepository
    {

        public async Task AddPackagesAsync(Package newpackage)
        {
            using (var context = new AppDbContext())
            {
                await context.Packages.AddAsync(newpackage); // Asynchronous Add
                await context.SaveChangesAsync(); // Asynchronous Save
            }
        }

        public async Task<List<Package>> GetAllPackagesAsync()
        {
            using (var context = new AppDbContext())
            {
                var packages = await context.Packages.ToListAsync(); // Asynchronous ToList
                return packages;
            }
        }

        public async Task<List<Package>> GetPackageByNameAsync(string title)
        {
            using (var context = new AppDbContext())
            {
                var packages = await context.Packages
                                             .Where(a => a.Title == title)
                                             .ToListAsync(); // Asynchronous Where and ToList
                foreach (var res in packages)
                {
                    Console.WriteLine(res.ToString());
                }
                return packages;
            }
        }
        public async Task<List<Package>> GetPackageByPackageIdAsync(int packageid)
        {
            using (var context = new AppDbContext())
            {
                var packages = await context.Packages
                                             .Where(a => a.PackageID == packageid)
                                             .ToListAsync(); // Asynchronous Where and ToList
                foreach (var res in packages)
                {
                    Console.WriteLine(res.ToString());
                }
                return packages;
            }
        }
        public async Task<List<Package>> GetPackageByDurationAsync(int duration)
        {
            using (var context = new AppDbContext())
            {
                var packages = await context.Packages
                                             .Where(a => a.Duration == duration)
                                             .ToListAsync(); // Asynchronous Where and ToList
                foreach (var res in packages)
                {
                    Console.WriteLine(res.ToString());
                }
                return packages;
            }
        }
        public async Task<List<Package>> GetPackageByPriceAsync(int price)
        {
            using (var context = new AppDbContext())
            {
                var packages = await context.Packages
                                             .Where(a => a.Price == price)
                                             .ToListAsync(); // Asynchronous Where and ToList
                foreach (var res in packages)
                {
                    Console.WriteLine(res.ToString());
                }
                return packages;
            }
        }

        public static async Task UpdatePackageAsync(int PackageID, string Title, string Description, int Duration, long Price, string IncludedServices)
        {
            using (var dbContext = new AppDbContext())
            {
                var package = await dbContext.Packages.FindAsync(PackageID); // Asynchronous Find
                if (package != null)
                {
                    package.Title = Title;
                    package.Duration = Duration;
                    package.Description = Description;
                    package.Price = Price;
                    package.IncludedServices = IncludedServices;

                    await dbContext.SaveChangesAsync(); // Asynchronous Save
                }
            }
        }

        public async Task DeletePackageAsync(int PackageId)
        {
            using (var dbContext = new AppDbContext())
            {
                var package = await dbContext.Packages.FindAsync(PackageId); // Asynchronous Find
                if (package != null)
                {
                    dbContext.Packages.Remove(package);
                    await dbContext.SaveChangesAsync(); // Asynchronous Save
                }
            }
        }
    }
}

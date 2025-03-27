using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingClassLibrary.Data;
using TravelBookingClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace TravelBookingClassLibrary.Repository
{
    public class UserRepository
    {

        public async Task<User> ValidateUser(string email, string password)
        {
            using (var context = new AppDbContext())
            {
                return await context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            }
        }

        public async Task AddUsers(User newuser)
       {
            using (var context = new AppDbContext())
            {   
                await context.Users.AddAsync(newuser);
                 await context.SaveChangesAsync();
            }
       }

        public async Task<List<User>> GetAllUsers()
        {
            using (var context = new AppDbContext())
            {
                return await  context.Users.ToListAsync<User>();
                 
            }
        }


        public async Task<List<User>> GetUsersByName(string UserName)
        {
            using (var context = new AppDbContext())
            {

                return await context.Users.Where(a => a.Name.Contains(UserName)).ToListAsync<User>();
                 
            }
        }


        public  async Task UpdateUser(long UserId, string newName, string newEmail,string newContact)
        {
            using (var dbContext = new AppDbContext())
            {
                var user = await dbContext.Users.FindAsync(UserId);
                if (user != null)
                {
                    user.Name = newName;
                    user.Email = newEmail;
                    user.ContactNumber = newContact;
                    await dbContext.SaveChangesAsync();

                }
            }
        }



        public async Task DeleteUser(long userId)
        {
            using (var dbContext = new AppDbContext())
            {
                var user =await dbContext.Users.FindAsync(userId);
                if (user != null)
                {
                    dbContext.Users.Remove(user);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}

using System.Linq;
using Microsoft.EntityFrameworkCore;
using TravelBooking.Models.Data;
using TravelBooking.Models.Entities;
namespace TravelBooking.Models.Repository
{
    public class ReviewRepository
    {
        public async Task Addvalues(Review review)
        {
            using (var context = new ReviewsDbContext())
            {
               await  context.Reviews.AddAsync(review);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateReview(int id,string comment)
        {
            
            using (var context = new ReviewsDbContext())
            {
                var review = await context.Reviews.FindAsync(id);
                if (review != null)
                {
                    review.Comment = comment;
                    await context.SaveChangesAsync();

                }

            }
        }

        public async Task DeleteReview(int id)
        {
            using (var context = new ReviewsDbContext())
            {
                var review = await context.Reviews.FindAsync(id);
                if (review != null)
                {
                    context.Reviews.Remove(review);
                   await context.SaveChangesAsync();
                }
            }
        }

        

        public async Task<List<Review>> GetAllReviews()
        {
            using (var context = new ReviewsDbContext())
            {
                return await context.Reviews.ToListAsync<Review>();
            }
        }
    }
}
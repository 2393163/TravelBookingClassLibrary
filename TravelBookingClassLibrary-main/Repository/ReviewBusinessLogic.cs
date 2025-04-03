using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TravelBookingClassLibrary.Entity;

namespace TravelBookingClassLibrary.BusinessLogic
{
    public class ReviewBusinessLogic
    {
        private ReviewDbContext dalObject = new ReviewDbContext();

        public int SaveReview(Review review)
        {
            string InsertQuery = "INSERT INTO [dbo].ReviewVALUES(@UserID,@PackageID,@Rating,@Comment,@TimeStamp )";

            nameValuePairList nvpList = new nameValuePairList();

            nvpList.Add(new nameValuePair("@UserID", review.UserID));
            nvpList.Add(new nameValuePair("@PackageID", review.PackageID));
            nvpList.Add(new nameValuePair("@Rating", review.Rating));
            nvpList.Add(new nameValuePair("@Comment", review.Comment));
            nvpList.Add(new nameValuePair("@TimeStamp", review.TimeStamp));

            int Status = dalObject.InsertUpdateOrDelete(InsertQuery, nvpList, false);

            if (Status != 0)
            {
                return Status;
            }
            else
            {
                return 0;
            }
        }

        public int UpdateReview(Review review)
        {
            string UpdateQuery = "UPDATE [dbo].[Review] SET UserID = @UserID, PackageID = @PackageID, Rating = @Rating, Comment = @Comment, TimeStamp = @TimeStamp WHERE ReviewID = @ReviewID";

            nameValuePairList nvpList = new nameValuePairList();

            nvpList.Add(new nameValuePair("@ReviewID", review.ReviewID));
            nvpList.Add(new nameValuePair("@UserID", review.UserID));
            nvpList.Add(new nameValuePair("@PackageID", review.PackageID));
            nvpList.Add(new nameValuePair("@Rating", review.Rating));
            nvpList.Add(new nameValuePair("@Comment", review.Comment));
            nvpList.Add(new nameValuePair("@TimeStamp", review.TimeStamp));

            int Status = dalObject.InsertUpdateOrDelete(UpdateQuery, nvpList, false);

            if (Status != 0)
            {
                return Status;
            }
            else
            {
                return 0;
            }
        }

        public int DeleteReview(int reviewID)
        {
            string DeleteQuery = "DELETE FROM [dbo].[Review] WHERE ReviewID = @ReviewID";

            nameValuePairList nvpList = new nameValuePairList();
            nvpList.Add(new nameValuePair("@ReviewID", reviewID));

            int Status = dalObject.InsertUpdateOrDelete(DeleteQuery, nvpList, false);

            if (Status != 0)
            {
                return Status;
            }
            else
            {
                return 0;
            }
        }

        public DataTable FetchCustomerData()
        {
            string SelectQuery = "Select * from Review ";
            DataTable dt = dalObject.FillAndReturnDataTable(SelectQuery);
            return dt;
        }

        public int ReviewCount()
        {
            string ReviewCountQ = "Select Count(*) 'Total Review' from Review";
            object countVal = dalObject.FetchCount(ReviewCountQ);
            int count = (int)countVal;
            return count;
        }

        public DataTable FetchReviewsByPackageID(int PackageID)
        {
            string SelectQuery = "Select * from Review Where PackageID='" + PackageID + "'";
            DataTable dt = dalObject.FillAndReturnDataTable(SelectQuery);
            return dt;
        }

        public DataTable FetchReviewsByUser(string UserID)
        {
            string SelectQuery = "Select * from Review Where UserID='" + UserID + "'";
            DataTable dt = dalObject.FillAndReturnDataTable(SelectQuery);
            return dt;
        }

        public DataTable FetchReviewsByRating(int Rating)
        {
            string SelectQuery = "Select * from Review Where Rating='" + Rating + "'";
            DataTable dt = dalObject.FillAndReturnDataTable(SelectQuery);
            return dt;
        }

        public DataTable FetchRecentReviews(int count)
        {
            string SelectQuery = "Select Top " + count + " * from Review Order By TimeStamp Desc";
            DataTable dt = dalObject.FillAndReturnDataTable(SelectQuery);
            return dt;
        }

        public DataTable FetchTopRatedReviews(int topCount)
        {
            string SelectQuery = "Select Top " + topCount + " * from Review Order By Rating Desc";
            DataTable dt = dalObject.FillAndReturnDataTable(SelectQuery);
            return dt;
        }

        public double FetchAverageRating(int packageID)
        {
            string SelectQuery = "Select AVG(CAST(Rating AS FLOAT)) from Review Where PackageID = @PackageID";
            nameValuePairList nvpList = new nameValuePairList();
            nvpList.Add(new nameValuePair("@PackageID", packageID.ToString()));
            object avgRating = dalObject.FetchScalar(SelectQuery, nvpList);
            return avgRating != DBNull.Value ? Convert.ToDouble(avgRating) : 0.0;
        }

        public DataTable FetchReviewsByKeyword(string keyword)
        {
            string SelectQuery = "Select * from Review Where Comment LIKE '%' + @Keyword + '%'";
            nameValuePairList nvpList = new nameValuePairList();
            nvpList.Add(new nameValuePair("@Keyword", keyword));
            DataTable dt = dalObject.FillAndReturnDataTable(SelectQuery, nvpList);
            return dt;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingClassLibrary.Entity;
using TravelBookingClassLibrary.Data;

namespace TravelBookingClassLibrary.Repository
{
    public class InsuranceRepository
    {
        public void AddUsers(Insurance newInsurance)

        {

            using (var context = new InsuranceandAssistanceContext())

            {

                context.Insurances.Add(newInsurance);

                context.SaveChanges();

            }

        }

        public List<Insurance> GetAllInsurances()

        {

            using (var context = new InsuranceandAssistanceContext())

            {

                var insurances = context.Insurances.ToList();

                return insurances;

            }
        }
        public void UpdateInsurance(int InsuranceID, string CoverageDetails, DateTime PurchaseDate)
        {
            using (var dbContext = new InsuranceandAssistanceContext())
            {
                var insurance = dbContext.Insurances.Find(InsuranceID); // Find the insurance record by ID
                if (insurance != null)
                {

                    insurance.CoverageDetails = CoverageDetails;
                    insurance.PurchaseDate = PurchaseDate;
                    dbContext.SaveChanges();
                }
            }

        }
        public void DeleteInsurance(int InsuranceID)
        {
            using (var dbContext = new InsuranceandAssistanceContext())
            {
                var insurance = dbContext.Insurances.Find(InsuranceID); // Find the insurance record by ID
                if (insurance != null)
                {
                    dbContext.Insurances.Remove(insurance); // Remove the record
                    dbContext.SaveChanges(); // Save changes to the database
                }
            }
        }
    }
}

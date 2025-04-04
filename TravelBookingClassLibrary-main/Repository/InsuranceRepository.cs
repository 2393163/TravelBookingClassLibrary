using InsuranceClass.Data;
using InsuranceClass.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClass.Repository
{
    public class InsuranceRepository
    {

        public void AddInsurance(Insurance newInsurance)

        {

            using (var context = new InsuranceContext())

            {

                context.Insurances.Add(newInsurance);

                context.SaveChanges();

            }

        }

        public List<Insurance> GetAllInsurances()

        {

            using (var context = new InsuranceContext())

            {

                var insurances = context.Insurances.ToList();

                return insurances;

            }
        }
        

        public void UpdateInsurance(int InsuranceID, string CoverageDetails)
        {
            using (var dbContext = new InsuranceContext())
            {
                var insurance = dbContext.Insurances.Find(InsuranceID); // Find the insurance record by ID
                if (insurance != null)
                {

                    insurance.CoverageDetails = CoverageDetails;
                    
                    dbContext.SaveChanges();
                }
            }

        }

        //public Insurance GetInsuranceByUserID(int userID)
        //{
        //    using (var context = new InsuranceandAssistanceContext())
        //    {
        //        return context.Insurances.FirstOrDefault(i => i.UserID == userID);
        //    }
        //}

        public List<Insurance> GetInsuranceByProvider(string provider)
        {
            using (var context = new InsuranceContext())
            {
                return context.Insurances.Where(i => i.Provider.Contains(provider)).ToList();
            }
        }

        //public List<Insurance> GetInsurancesByDateRange(DateTime startDate, DateTime endDate)
        //{
        //    using (var context = new InsuranceandAssistanceContext())
        //    {
        //        return context.Insurances
        //            .Where(i => i.PurchaseDate >= startDate && i.PurchaseDate <= endDate)
        //            .ToList();
        //    }
        //}
        //public List<Insurance> GetInsuranceByPackage(string package)
        //{
        //    using (var context = new InsuranceandAssistanceContext())
        //    {
        //        return context.Insurances.Where(i => i.PackageID.Contains(package)).ToList();
        //    }
        //}
        public int GetTotalInsuranceCount()
        {
            using (var context = new InsuranceContext())
            {
                return context.Insurances.Count();
            }
        }



        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookingClassLibrary.Class;

namespace TravelBookingClassLibrary.Repository
{
    public class ARepository
    {
        public void AddUsers(Assistance newAsistanceRequest)
        {

            using (var context = new InsuranceandAssistanceContext())

            {
                context.Assistances.Add(newAsistanceRequest);

                context.SaveChanges();

            }

        }

        public List<Assistance> GetAllAssistanceRequest()

        {

            using (var context = new InsuranceandAssistanceContext())

            {
                var assistanceRequest = context.Assistances.ToList();
                return assistanceRequest;


            }
        }
        public void UpdateAssistanceRequest(int RequestID, string IssueDescription)
        {
            using (var dbContext = new InsuranceandAssistanceContext())
            {
                var AssistanceRequest = dbContext.Assistances.Find(RequestID); // Find the insurance record by ID
                if (AssistanceRequest != null)
                {
                    AssistanceRequest.RequestID = RequestID;

                    AssistanceRequest.IssueDescription = IssueDescription;

                    dbContext.SaveChanges();
                }
            }

        }
        public void DeleteAssistanceRequest(int RequestID)
        {
            using (var dbContext = new InsuranceandAssistanceContext())
            {
                var AssistanceRequest = dbContext.Assistances.Find(RequestID); // Find the insurance record by ID
                if (AssistanceRequest != null)
                {
                    dbContext.Assistances.Remove(AssistanceRequest); // Remove the record
                    dbContext.SaveChanges(); // Save changes to the database
                }
            }
        }
    }
}

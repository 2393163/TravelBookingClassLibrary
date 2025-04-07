using TravelAssistance.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TravelAssistance.Entity;
using System.Collections.Generic;
using System.Linq;

namespace TravelAssistance.Repository
{
    public class AssistanceRepository
    {
        private readonly AssistanceContext _context;

        public AssistanceRepository(AssistanceContext context)
        {
            _context = context;
        }

        public Assistance AddAssistanceRequest(Assistance request)
        {
            _context.Assistances.Add(request);
            _context.SaveChanges();
            return request;
        }

        public Assistance GetAssistanceByRequestId(int id)
        {
            return _context.Assistances.FirstOrDefault(r => r.RequestID == id);
        }

        public IEnumerable<Assistance> GetAllAssistanceRequests()
        {
            return _context.Assistances.ToList();
        }

        public void UpdateResolutionTime(int userId)
        {
            var userIdParam = new SqlParameter("@UserID", userId);
            _context.Database.ExecuteSqlRaw("EXEC UpdateResolutionTime @UserID", userIdParam);
        }

        public Assistance UpdateAssistanceRequest(Assistance updatedRequest)
        {
            var existingRequest = _context.Assistances.FirstOrDefault(r => r.RequestID == updatedRequest.RequestID);
            if (existingRequest != null)
            {
                existingRequest.Status = updatedRequest.Status;
                existingRequest.IssueDescription = updatedRequest.IssueDescription;
                _context.SaveChanges();
            }
            return existingRequest;
        }

        public bool DeleteAssistanceRequest(int id)
        {
            var request = _context.Assistances.FirstOrDefault(r => r.RequestID == id);
            if (request != null)
            {
                _context.Assistances.Remove(request);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

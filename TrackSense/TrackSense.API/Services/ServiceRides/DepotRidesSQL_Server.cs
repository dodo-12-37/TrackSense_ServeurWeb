using Microsoft.EntityFrameworkCore;
using TrackSense.API.Data;
using TrackSense.API.Entities;
using TrackSense.API.Entities.Interfaces;

namespace TrackSense.API.Services.ServiceRides
{
    public class DepotRidesSQL_Server : IDepotRides
    {
        private readonly TracksenseContext m_context;
        public DepotRidesSQL_Server(TracksenseContext tracksenseContext)
        {
            this.m_context = tracksenseContext;
        }
        public void AddCompletedRide(CompletedRide p_comletedRide)
        {
            throw new NotImplementedException();
        }

        public void AddPlannedRide(PlannedRide p_plannedRide)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompletedRideById(Guid p_completedRideId)
        {
            throw new NotImplementedException();
        }

        public void DeletePlannedRideById(Guid p_plannedRideId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompletedRide> GetAllCompletedRidesByUser(string p_userLogin)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlannedRide> GetAllPlannedRidesByUser(string p_userLogin)
        {
            throw new NotImplementedException();
        }

        public PlannedRideStatistics? GetAllPlannedRideStatistics(Guid p_plannedRideId)
        {
            throw new NotImplementedException();
        }

        public Entities.CompletedRide? GetCompletedRideById(Guid p_completedRideId)
        {
            List<DTOs.CompletedRidePoint> ? completedRidePoints = m_context.CompletedRidePoints.Where(p=>p.CompletedRideId==p_completedRideId).ToList();

            completedRidePoints.ForEach(p=>p.Location=m_context.Locations?.Find(p.LocationId));
            
            DTOs.CompletedRide? completedRide = m_context.CompletedRides.Find(p_completedRideId);
            
            if(completedRide != null)
            {

                completedRide.CompletedRidePoints = completedRidePoints;
                completedRide.CompletedRideStatistic = m_context.CompletedRideStatistics.Find(p_completedRideId);
                return completedRide.ToEntity();
            }

            return null;
        }

        public CompletedRideStatistics? GetCompletedRideStatistics(Guid p_completedRideId)
        {
            throw new NotImplementedException();
        }

        public PlannedRide? GetPlannedRideById(Guid p_completedRideId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCompletedRide(CompletedRide p_completedRide)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlannedRide(PlannedRide p_plannedRide)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TrackSense.API.Data;
using TrackSense.API.Entities;
using TrackSense.API.Entities.Interfaces;

namespace TrackSense.API.Services.ServiceRides
{
    public class DepotRides_MySQL : IDepotRides
    {
        private readonly TracksenseContext m_context;
        public DepotRides_MySQL(TracksenseContext tracksenseContext)
        {
            if(tracksenseContext == null)
            {
                throw new ArgumentNullException(nameof(m_context));
            }
            this.m_context = tracksenseContext;
        }
        public void AddCompletedRide(CompletedRide p_comletedRide)
        {
            if(p_comletedRide == null)
            {
                throw new ArgumentNullException(nameof(p_comletedRide));
            }
            m_context.CompletedRides.Add(new DTOs.CompletedRide(p_comletedRide));
            m_context.SaveChanges();
            m_context.ChangeTracker.Clear();
            
            if(p_comletedRide.PlannedRide != null)
            {
                this.AddPlannedRide(p_comletedRide.PlannedRide);
            }

            if(p_comletedRide.CompletedRidePoints == null)
            {
                throw new NullReferenceException(nameof(p_comletedRide.CompletedRidePoints));
            }

            p_comletedRide.CompletedRidePoints.ForEach(p => this.AddCompletedRidePoint(p));

            this.AddCompletedRideStatistics(new CompletedRideStatistics(p_comletedRide));
        }

        public void AddCompletedRidePoint(CompletedRidePoint p_comletedRidePoint)
        {
            m_context.CompletedRidePoints.Add(new DTOs.CompletedRidePoint(p_comletedRidePoint));
            m_context.SaveChanges();
            m_context.ChangeTracker.Clear();
        }

        public void AddCompletedRideStatistics(CompletedRideStatistics p_completedRideStatistic)
        {
            m_context.CompletedRideStatistics.Add(new DTOs.CompletedRideStatistic(p_completedRideStatistic));
            throw new NotImplementedException();
        }

        public void AddPlannedRide(PlannedRide p_plannedRide)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompletedRideById(string p_completedRideId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompletedRidePoint(string p_completedRidePointId)
        {
            throw new NotImplementedException();
        }

        public void DeletePlannedRideById(string p_plannedRideId)
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

        public PlannedRideStatistics? GetAllPlannedRideStatistics(string p_plannedRideId)
        {
            throw new NotImplementedException();
        }

        public Entities.CompletedRide? GetCompletedRideById(string p_completedRideId)
        {
            List<DTOs.CompletedRidePoint> ? completedRidePoints = m_context.CompletedRidePoints.Where(p=>p.CompletedRideId==p_completedRideId).ToList();

            completedRidePoints.ForEach(p=>p.Location = m_context.Locations?.Find(p.LocationId));
            
            DTOs.CompletedRide? completedRide = m_context.CompletedRides.Find(p_completedRideId);
            
            if(completedRide != null)
            {

                completedRide.CompletedRidePoints = completedRidePoints;
                completedRide.CompletedRideStatistic = m_context.CompletedRideStatistics.Find(p_completedRideId);
                return completedRide.ToEntity();
            }

            return null;
        }

        public CompletedRideStatistics? GetCompletedRideStatistics(string p_completedRideId)
        {
            return m_context.CompletedRideStatistics?.Find(p_completedRideId)?.ToEntity();
        }

        public PlannedRide? GetPlannedRideById(string p_completedRideId)
        {
            return m_context.PlannedRides?.Find(p_completedRideId)?.ToEntity();
        }

        public void UpdateCompletedRide(CompletedRide p_completedRide)
        {
            throw new NotImplementedException();
        }

        public void UpdateCompletedRidePoint(CompletedRidePoint p_completedRidePoint)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlannedRide(PlannedRide p_plannedRide)
        {
            throw new NotImplementedException();
        }
    }
}

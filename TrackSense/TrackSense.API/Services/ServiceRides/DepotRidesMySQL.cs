using TrackSense.API.Entities;
using TrackSense.API.Entities.Interfaces;

namespace TrackSense.API.Services.ServiceRides
{
    public class DepotRidesMySQL
        : IDepotRides
    {
        public void AddCompletedRide(string p_userLogin, CompletedRide p_comletedRide)
        {
            throw new NotImplementedException();
        }

        public void AddPlannedRide(string p_userLogin, PlannedRide p_plannedRide)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompletedRide(Guid p_completedRideId)
        {
            throw new NotImplementedException();
        }

        public void DeletePlannedRide(Guid p_plannedRideId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompletedRide> GetAllCompletedRides(string p_userLogin)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlannedRide> GetAllPlannedRides(string p_userLogin)
        {
            throw new NotImplementedException();
        }

        public PlannedRideStatistics? GetAllPlannedRideStatistics(Guid p_plannedRideId)
        {
            throw new NotImplementedException();
        }

        public CompletedRide? GetCompletedRideById(Guid p_completedRideId)
        {
            throw new NotImplementedException();
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

using System.Globalization;

namespace TrackSense.API.Entities.Interfaces
{
    public interface IDepotRides
    {
        // CompletedRide
        IEnumerable<CompletedRide> GetAllCompletedRidesByUser(string p_userLogin);
        CompletedRide? GetCompletedRideById(Guid p_completedRideId);
        void UpdateCompletedRide(CompletedRide p_completedRide);
        void DeleteCompletedRideById(Guid p_completedRideId);
        void AddCompletedRide(CompletedRide p_comletedRide);
        CompletedRideStatistics? GetCompletedRideStatistics(Guid p_completedRideId);
        
        // PlannedRide
        IEnumerable<PlannedRide> GetAllPlannedRidesByUser(string p_userLogin);
        PlannedRide? GetPlannedRideById(Guid p_completedRideId);
        void UpdatePlannedRide(PlannedRide p_plannedRide);
        void DeletePlannedRideById(Guid p_plannedRideId);
        void AddPlannedRide(PlannedRide p_plannedRide);
        PlannedRideStatistics? GetAllPlannedRideStatistics(Guid p_plannedRideId);
    }
}

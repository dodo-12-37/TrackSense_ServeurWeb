using System.Globalization;

namespace TrackSense.API.Entities.Interfaces
{
    public interface IDepotRides
    {
        IEnumerable<CompletedRide> GetAllCompletedRides(string p_userLogin);
        CompletedRide? GetCompletedRideById(Guid p_completedRideId);
        void UpdateCompletedRide(CompletedRide p_completedRide);
        void DeleteCompletedRide(Guid p_completedRideId);
        void AddCompletedRide(string p_userLogin, CompletedRide p_comletedRide);
        CompletedRideStatistics? GetCompletedRideStatistics(Guid p_completedRideId);
        IEnumerable<PlannedRide> GetAllPlannedRides(string p_userLogin);
        PlannedRide? GetPlannedRideById(Guid p_completedRideId);
        void UpdatePlannedRide(PlannedRide p_plannedRide);
        void DeletePlannedRide(Guid p_plannedRideId);
        void AddPlannedRide(string p_userLogin, PlannedRide p_plannedRide);
        PlannedRideStatistics? GetAllPlannedRideStatistics(Guid p_plannedRideId);
    }
}

namespace TrackSense.API.Entities
{
    public interface IDepotRides
    {
        IEnumerable<CompletedRide> GetAllCompletedRides();
        CompletedRide GetCompletedRideById(Guid p_completedRideId);
        void UpdateCompletedRide(CompletedRide p_completedRide);
        void DeleteCompletedRide(Guid p_completedRideId);
        void AddCompletedRide(string p_userLogin, CompletedRide p_comletedRide);
        CompletedRideStatistics GetCompletedRideStatistics(Guid p_completedRideId);
    }
}

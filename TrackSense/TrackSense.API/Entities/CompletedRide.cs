namespace TrackSense.API.Entities
{
    public class CompletedRide
    {
        public Guid CompletedRideId { get; set; }
        public Guid? PlannedRideId { get; set; }
        public List<CompletedRidePoint>? CompletedRidePoints { get;  set; }
        public CompletedRideStatistics Statistics { get; set; }
    }
}

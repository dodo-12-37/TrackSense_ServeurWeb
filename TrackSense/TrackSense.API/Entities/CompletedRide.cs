namespace TrackSense.API.Entities
{
    public class CompletedRide
    {
        public Guid CompletedRideId { get; set; } = Guid.NewGuid();
        public string UserLogin { get; set; } = string.Empty;
        public PlannedRide? PlannedRide { get; set; }
        public List<CompletedRidePoint>? CompletedRidePoints { get;  set; }
        public CompletedRideStatistics ?Statistics { get; set; }
    }
}

namespace TrackSense.API.Entities
{
    public class CompletedRide
    {
        public string CompletedRideId { get; set; } = null!;
        public string UserLogin { get; set; } = string.Empty;
        public PlannedRide? PlannedRide { get; set; }
        public List<CompletedRidePoint>? CompletedRidePoints { get;  set; }
        public CompletedRideStatistics ?Statistics { get; set; }
    }
}

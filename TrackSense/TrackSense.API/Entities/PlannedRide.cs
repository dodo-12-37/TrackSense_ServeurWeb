namespace TrackSense.API.Entities
{
    public class PlannedRide
    {
        public Guid PlannedRideId { get; set; }
        public string Name { get; set; }
        public bool IsFavorite { get; set; }
        public PlannedRideStatistics Statistics { get; set; }
        public List<PlannedRidePoint>? RidePoints { get; set; }
    }
}

namespace TrackSense.API.Entities
{
    public class UserCompletedRide
    {
        public Guid CompletedRideId { get; set; }
        public string? PlannedRideName { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime Duration { get; set; }
        public double Distance { get; set; }
    }
}

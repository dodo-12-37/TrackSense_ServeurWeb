using Microsoft.AspNetCore.Identity;

namespace TrackSense.API.Entities
{
    public class UserCompletedRide
    {
        public string UserLogin { get; set; } = string.Empty!;
        public string CompletedRideId { get; set; } = string.Empty!;
        public string? PlannedRideName { get; set; }
        public DateTime StartedAt { get; set; }
        public TimeSpan Duration { get; set; }
        public double Distance { get; set; }
    }
}

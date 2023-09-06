using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class UserCompletedRideModel
    {
        public Guid CompletedRideId { get; set; }
        public string? PlannedRideName { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime Duration { get; set; }
        public double Distance { get; set; }

        public UserCompletedRideModel()
        {
            ;
        }

        public UserCompletedRideModel(UserCompletedRide p_userCompletedRides)
        {
            this.CompletedRideId = p_userCompletedRides.CompletedRideId;
            this.PlannedRideName = p_userCompletedRides.PlannedRideName;
            this.StartedAt = p_userCompletedRides.StartedAt;
            this.Duration = p_userCompletedRides.Duration;
            this.Distance = p_userCompletedRides.Distance;
        }

        public UserCompletedRide ToEntity()
        {
            return new UserCompletedRide()
            {
                CompletedRideId = this.CompletedRideId,
                PlannedRideName = this.PlannedRideName,
                StartedAt = this.StartedAt,
                Duration = this.Duration,
                Distance = this.Distance
            };
        }
    }
}

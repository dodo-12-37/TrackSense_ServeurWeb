using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackSense.API.Services.DTOs
{
    [Keyless]
    [Table("UserCompletedRide")]
    public class UserCompletedRide
    {
        public string UserLogin { get; set; }
        public string CompletedRideId { get; set; }
        public string? PlannedRideName { get; set; }
        public DateTime StartedAt { get; set; }
        public TimeSpan Duration { get; set; }
        public double Distance { get; set; }
        public UserCompletedRide()
        {
            
        }
        public Entities.UserCompletedRide ToEntity()
        {
            return new Entities.UserCompletedRide()
            {
                UserLogin = this.UserLogin,
                CompletedRideId = this.CompletedRideId,
                PlannedRideName = this.PlannedRideName,
                StartedAt = this.StartedAt,
                Duration = this.Duration,
                Distance = this.Distance
            };
        }
    }
    
}

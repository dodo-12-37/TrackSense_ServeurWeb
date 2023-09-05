using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    public class PlannedRideDTO
    {
        [Key]
        public Guid PlannedRideId { get; set; } = Guid.Empty;

        [ForeignKey(nameof(UserLogin))]
        public string UserLogin { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsFavorite { get; set; } = false;
        public virtual PlannedRideStatisticsDTO? Statistics { get; set; }
        public virtual List<PlannedRidePointDTO>? RidePoints { get; set; }

        public PlannedRideDTO()
        {
            
        }
        public PlannedRideDTO(PlannedRide p_plannedRide)
        {
            this.PlannedRideId = p_plannedRide.PlannedRideId;
            this.UserLogin = p_plannedRide.UserLogin;
            this.Name = p_plannedRide.Name;
            this.IsFavorite = p_plannedRide.IsFavorite;
            this.Statistics = p_plannedRide.Statistics == null 
                ? new PlannedRideStatisticsDTO() 
                : new PlannedRideStatisticsDTO(p_plannedRide.Statistics);
            this.RidePoints = p_plannedRide.RidePoints == null
                ? new List<PlannedRidePointDTO>()
                : new List<PlannedRidePointDTO>(p_plannedRide.RidePoints.Select(p=>new PlannedRidePointDTO(p)));
        }

        public PlannedRide ToEntity()
        {
            return new PlannedRide()
            {
                PlannedRideId = this.PlannedRideId,
                UserLogin = this.UserLogin,
                Name = this.Name,
                IsFavorite = this.IsFavorite,
                Statistics = this.Statistics.ToEntity();
            }
        }
    }
}

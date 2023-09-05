using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    public class PlannedRidePointDTO
    {
        [Key]
        [ForeignKey("PlannedRideId")]
        public Guid PlannedRideId { get; set; } = Guid.Empty;
        [Key]
        [ForeignKey("LocationId")]
        public int LocationId { get; set; } = 0;
        public int RideStep { get; set; } = 0;
        public double Temperature { get; set; } = 0.0;

        public virtual LocationDTO LocationDTO { get; set; }

        public PlannedRidePointDTO()
        {
            
        }
        public PlannedRidePointDTO(PlannedRidePoint p_plannedRidePoint)
        {
            this.PlannedRideId = p_plannedRidePoint.PlannedRideId;
            this.LocationId = p_plannedRidePoint.Location.LocationId;
            this.RideStep = p_plannedRidePoint.RideStep;
            this.Temperature = p_plannedRidePoint.Temperature;
            this.LocationDTO = p_plannedRidePoint.Location == null
                ? new LocationDTO()
                : new LocationDTO(p_plannedRidePoint.Location);

        }

        public PlannedRidePoint ToEntity()
        {
            return new PlannedRidePoint()
            {
                PlannedRideId = this.PlannedRideId,
                Location = this.LocationDTO.ToEntity(),
                RideStep = this.RideStep,
                Temperature = this.Temperature
            };
        }
    }
}

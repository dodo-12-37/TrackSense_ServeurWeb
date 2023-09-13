using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    [Table("PlannedRidePoint")]
    [PrimaryKey(nameof(PlannedRideId),nameof(LocationId))]
    public class PlannedRidePointDTO
    {
        public Guid PlannedRideId { get; set; }

        public Guid LocationId { get; set; }
        public int? RideStep { get; set; }
        public double? Temperature { get; set; }

        [ForeignKey("LocationId")]
        public virtual LocationDTO Location { get; set; }

        [ForeignKey("PlannedRideId")]
        public virtual PlannedRideDTO PlannedRide { get; set; }
        public PlannedRidePointDTO()
        {
            
        }
        public PlannedRidePointDTO(PlannedRidePoint p_plannedRidePoint)
        {
            if(p_plannedRidePoint.Location == null)
            {
                throw new NullReferenceException(nameof(p_plannedRidePoint.Location));
            }
            this.PlannedRideId = new Guid();
            this.Location = new LocationDTO(p_plannedRidePoint.Location);
            this.LocationId = this.Location.LocationId;
            this.RideStep = p_plannedRidePoint.RideStep;

        }

        public PlannedRidePoint ToEntity()
        {
            return new PlannedRidePoint()
            {
                PlannedRideId = this.PlannedRideId,
                Location = this.Location.ToEntity(),
                RideStep = this.RideStep,
            };
        }
    }
}

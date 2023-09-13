using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    [Table("CompletedRidePoint")]
    [PrimaryKey(nameof(CompletedRideId),nameof(LocationId))]
    public class CompletedRidePointDTO {

        public Guid CompletedRideId { get; set; }
        public int LocationId { get; set; }

        public int ? RideStep { get; set; }
        public double? Temperature { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("CompletedRideId")]
        public virtual CompletedRideDTO CompletedRide { get; set; }

        [ForeignKey("LocationId")]
        public virtual LocationDTO Location { get; set; }

        public CompletedRidePointDTO()
        {
            
        }
        public CompletedRidePointDTO(CompletedRidePoint p_completedRidePoint) 
        
        {
            this.Location = new LocationDTO(p_completedRidePoint.Location);
            this.RideStep = p_completedRidePoint?.RideStep;
            this.Temperature = p_completedRidePoint?.Temperature;
            this.Date = p_completedRidePoint.DateTime;
        }

        public CompletedRidePoint ToEntity()
        {
            return new CompletedRidePoint()
            {
                Location = this.Location.ToEntity(),
                RideStep = this.RideStep,
                Temperature = this.Temperature,
                DateTime = this.Date
            };
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    public class CompletedRidePointDTO
    {
        [Key]
        [ForeignKey(nameof(CompletedRideId))]
        public Guid CompletedRideId { get; set; } = Guid.Empty;

        [Key]
        [ForeignKey(nameof(LocationId))]
        public int LocationId { get;set; } = 0;

        [Required]
        public virtual LocationDTO Location { get; set; }
        public int  RideStep { get; set; }
        public double  Temperature { get; set; }
        public DateTime  DateTime { get; set; }

        public CompletedRidePointDTO()
        {
            
        }
        public CompletedRidePointDTO(CompletedRidePoint p_completedRidePoint) 
        
        {
            this.Location = new LocationDTO(p_completedRidePoint.Location);
            this.RideStep = p_completedRidePoint.RideStep;
            this.Temperature = p_completedRidePoint.Temperature;
            this.DateTime = p_completedRidePoint.DateTime;
        }

        public CompletedRidePoint ToEntity()
        {
            return new CompletedRidePoint()
            {
                Location = this.Location.ToEntity(),
                RideStep = this.RideStep,
                Temperature = this.Temperature,
                DateTime = this.DateTime
            };
        }
    }
}

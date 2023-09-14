using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;
namespace TrackSense.API.Services.DTO
{
        [Table("CompletedRideStatistics")]
    public class CompletedRideStatisticsDTO
    {
        [Key]
        public Guid CompletedRideId { get; set; }

        public double? AverageSpeed { get; set; }
        public double? MaximumSpeed { get; set; }
        public int? Falls { get; set; }
        public int? Calories { get; set; }
        public double? Distance { get; set; }
        
        public TimeSpan? Duration { get; set; }

        [ForeignKey("CompletedRideId")]
        public virtual CompletedRide CompletedRide { get; set; }

        public CompletedRideStatisticsDTO()
        {
            
        }

   /*     public CompletedRideStatisticsDTO(CompletedRideStatistics p_statistics)
        {
            this.CompletedRideId = Guid.NewGuid();
            this.AverageSpeed = p_statistics?.AverageSpeed;
            this.MaximumSpeed = p_statistics?.MaximumSpeed;
            this.Distance = p_statistics?.Distance;
            this.Duration = p_statistics?.Duration;
            this.Calories = p_statistics?.Calories;
            this.Falls = p_statistics?.Falls;
        }*/

        public CompletedRideStatistics ToEntity(){
            return new CompletedRideStatistics{
                AverageSpeed = this.AverageSpeed,
                MaximumSpeed = this.MaximumSpeed,
                Distance = this.Distance,
                Duration = this.Duration,
                Calories = this.Calories,
                Falls = this.Falls
            };
        }
    }
}

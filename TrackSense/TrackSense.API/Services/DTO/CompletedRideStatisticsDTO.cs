using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;
namespace TrackSense.API.Services.DTO
{
    public class CompletedRideStatisticsDTO
    {
        [Required]
        [Key]
        [ForeignKey(nameof(CompletedRideId))]
        public Guid CompletedRideId { get; set; } = Guid.Empty;
        public double? AverageSpeed { get; set; } = 0;
        public double? MaximumSpeed { get; set; } = 0;
        public double? Distance { get; set; } = 0;
        public DateTime? Duration { get; set; }
        public int? Calories { get; set; }
        public int? Falls { get; set; }

        public CompletedRideStatisticsDTO()
        {
            
        }

        public CompletedRideStatisticsDTO(CompletedRideStatistics p_statistics)
        {
            this.AverageSpeed = p_statistics?.AverageSpeed;
            this.MaximumSpeed = p_statistics?.MaximumSpeed;
            this.Distance = p_statistics?.Distance;
            this.Duration = p_statistics?.Duration;
            this.Calories = p_statistics?.Calories;
            this.Falls = p_statistics?.Falls;
        }

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

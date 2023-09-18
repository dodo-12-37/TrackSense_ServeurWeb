using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class CompletedRideStatisticsModel 
    {
        [DefaultValue("b0f07b65-3055-4f99-bc09-91829ca16fd")]
        public string CompletedRideId { get; set; } = Guid.NewGuid().ToString();
        public double? AverageSpeed { get; set; } = 0;
        public double? MaximumSpeed { get; set; } = 0;
        public double? Distance { get; set; } = 0;
        public int? Calories { get; set; } = 0;
        public int? Falls { get; set; } = 0;
        [JsonIgnore]
        public TimeSpan Duration { get; set; }

        public CompletedRideStatisticsModel()
        {
            
        }

        public CompletedRideStatisticsModel(CompletedRideStatistics p_statistics)
        {
            this.CompletedRideId = p_statistics.CompletedRideId;
            this.AverageSpeed = p_statistics.AverageSpeed;
            this.MaximumSpeed = p_statistics.MaximumSpeed;
            this.Distance = p_statistics.Distance;
            this.Calories = p_statistics.Calories;
            this.Duration = p_statistics.Duration;
            this.Falls = p_statistics.Falls;
        }

        public CompletedRideStatistics ToEntity()
        {
            return new CompletedRideStatistics
            {
                CompletedRideId = this.CompletedRideId,
                AverageSpeed = this.AverageSpeed,
                MaximumSpeed = this.MaximumSpeed,
                Distance = this.Distance,
                Calories = this.Calories,
                Duration = this.Duration,
                Falls = this.Falls
            };
        }
    }

}

using System.Text.Json.Serialization;
using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class CompletedRideStatisticsModel 
    {
        [JsonIgnore]
        public string? CompletedRideId { get;  } = null;
        public double? AverageSpeed { get; } = 0;
        public double? MaximumSpeed { get;  } = 0;
        public double? Distance { get;  } = 0;
        public int? Calories { get;  } = 0;
        public int? Falls { get; } = 0;

        public string? Duration { get ; } 

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
            this.Duration = p_statistics.Duration.ToString();
            this.Falls = p_statistics.Falls;
        }

      /*  public CompletedRideStatistics ToEntity()
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
        }*/
    }

}

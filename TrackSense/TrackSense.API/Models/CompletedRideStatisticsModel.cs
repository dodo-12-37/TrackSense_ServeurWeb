using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class CompletedRideStatisticsModel
    {
        public double? AverageSpeed { get; set; }
        public double ? MaximumSpeed { get; set; }
        public double? Distance { get; set; }
        public int? Calories { get; set; }
        public DateTime? Duration { get; set; }
        public int? Falls { get; set; }

        public CompletedRideStatisticsModel()
        {
            ;
        }

        public CompletedRideStatisticsModel(CompletedRideStatistics p_statistics)
        {
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

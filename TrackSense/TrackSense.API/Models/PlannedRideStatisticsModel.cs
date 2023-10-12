using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class PlannedRideStatisticsModel
    {
        public double ?AverageSpeed { get;  }
        public double ?MaximumSpeed { get;  }
        public double ?AverageDuration { get; }

        public PlannedRideStatisticsModel()
        {
            ;
        }

        public PlannedRideStatisticsModel(PlannedRideStatistics statistics)
        {
            this.AverageSpeed = statistics.AverageSpeed;
            this.MaximumSpeed = statistics.MaximumSpeed;
            this.AverageDuration = statistics.AverageDuration;
        }

        public PlannedRideStatistics ToEntity()
        {
            return new PlannedRideStatistics
            {
                AverageSpeed = this.AverageSpeed,
                MaximumSpeed = this.MaximumSpeed,
                AverageDuration = this.AverageDuration
            };
        }
    }

}

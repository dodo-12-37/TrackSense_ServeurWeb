using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class PlannedRideStatisticsModel
    {
        public double ?AverageSpeed { get; set; }
        public double ?MaximumSpeed { get; set; }
        public double ?AverageDuration { get; set; }

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

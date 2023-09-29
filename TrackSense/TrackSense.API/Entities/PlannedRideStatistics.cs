namespace TrackSense.API.Entities
{
    public class PlannedRideStatistics
    {
        public string PlannedRideId { get; set; } = null!;

        public double? AverageSpeed { get; set; }

        public double? AverageDuration { get; set; }

        public double? MaximumSpeed { get; set; }

        public int? Falls { get; set; }

        public int? Calories { get; set; }

        public double? Distance { get; set; }

        public TimeSpan? Duration { get; set; }
    }
}

namespace TrackSense.API.Entities
{
    public class CompletedRideStatistics
    {
        public string UserLogin { get; set; } = string.Empty!;
        public string CompletedRideId { get; set; } = string.Empty!;
        public double? AverageSpeed { get; set; }
        public double? MaximumSpeed { get; set; }
        public double? Distance { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? Calories { get; set; }
        public int? Falls { get; set; }
         
        public CompletedRideStatistics()
        {

        }
    
    }
}

namespace TrackSense.API.Entities
{
    public class UserStatistics
    {
        public double AverageSpeed { get; set; }
        public double MaximumSpeed { get; set; }
        public double Distance { get; set; }
        public DateTime Duration { get; set; }
        public int Calories { get; set; }
        public int Falls { get; set; }
    }
}

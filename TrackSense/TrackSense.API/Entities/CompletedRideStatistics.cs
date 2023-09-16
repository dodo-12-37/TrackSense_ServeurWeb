using System.ComponentModel.DataAnnotations;

namespace TrackSense.API.Entities
{
    public class CompletedRideStatistics
    {
        [Key]
        public string CompletedRideId { get; set; }
        public double? AverageSpeed { get; set; }
        public double? MaximumSpeed { get; set; }
        public double? Distance { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? Calories { get; set; }
        public int ?Falls { get; set; }

        public CompletedRideStatistics()
        {
            
        }
        public CompletedRideStatistics(List<CompletedRidePoint> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }
            
            this.CompletedRideId = points[0].CompletedRideId;
            this.AverageSpeed = points.Average(p => p.Location.Speed);
            this.MaximumSpeed = points.Max(p => p.Location.Speed);
            this.Duration = points.Max(p => p.Date) - points.Min(p => p.Date);
        }
    }
}

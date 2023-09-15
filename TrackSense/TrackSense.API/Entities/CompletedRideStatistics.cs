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
        public CompletedRideStatistics(CompletedRide p_completedRide)
        {
            if (p_completedRide == null)
            {
                throw new ArgumentNullException(nameof(p_completedRide));
            }
            if (p_completedRide.CompletedRidePoints == null)
            {
                throw new ArgumentNullException(nameof(p_completedRide));
            }
            this.CompletedRideId = p_completedRide.CompletedRideId;
            this.AverageSpeed =p_completedRide.CompletedRidePoints.Average(p => p.Location.Speed);

            this.MaximumSpeed = p_completedRide.CompletedRidePoints.Max(p => p.Location.Speed);

            this.Duration = p_completedRide.CompletedRidePoints.Max(p => p.Date) - p_completedRide.CompletedRidePoints.Min(p => p.Date);
        }
    }
}

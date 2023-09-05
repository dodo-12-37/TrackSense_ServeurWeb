using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    public class PlannedRideStatisticsDTO
    {
        [Key]
        [ForeignKey(nameof(PlannedRideId))]
        public Guid PlannedRideId { get; set; }
        public double AverageSpeed { get; set; } = 0.0;
        public double MaximumSpeed { get; set; } = 0.0;
        public double AverageDuration { get; set; } = 0.0;

        public PlannedRideStatisticsDTO()
        {
            
        }
        public PlannedRideStatisticsDTO(PlannedRideStatistics p_plannedRideStatistics)
        {
            this.AverageSpeed = p_plannedRideStatistics?.AverageSpeed ?? 0.0;
            this.AverageDuration = p_plannedRideStatistics?.AverageDuration ?? 0.0;
            this.MaximumSpeed = p_plannedRideStatistics?.MaximumSpeed ?? 0.0;
        }
        public PlannedRideStatistics ToEntity()
        {
            return new PlannedRideStatistics()
            {
                AverageSpeed = this.AverageSpeed,
                AverageDuration = this.AverageDuration,
                MaximumSpeed = this.MaximumSpeed,
            };
        }
    }
}

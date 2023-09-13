using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    [Table("PlannedRideStatistics")]
    public class PlannedRideStatisticsDTO
    {
        [Key]
        public Guid PlannedRideId { get; set; }

        public double? AverageSpeed { get; set; }
        public double? AverageDuration { get; set; }
        public double? MaximumSpeed { get; set; }
        public int? Falls { get; set; }
        public int? Calories { get; set; }
        public double? Distance { get; set; }
        public DateTime? Duration { get; set; }

        [ForeignKey("PlannedRideId")]
        public virtual PlannedRide PlannedRide { get; set; }

        public PlannedRideStatisticsDTO()
        {
            
        }
    /*    public PlannedRideStatisticsDTO(PlannedRideStatistics p_plannedRideStatistics)
        {
            this.AverageSpeed = p_plannedRideStatistics?.AverageSpeed ?? 0.0;
            this.AverageDuration = p_plannedRideStatistics?.AverageDuration ?? 0.0;
            this.MaximumSpeed = p_plannedRideStatistics?.MaximumSpeed ?? 0.0;
        }*/
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

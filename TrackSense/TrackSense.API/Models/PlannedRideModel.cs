using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class PlannedRideModel
    {
        public Guid PlannedRideId { get; set; }
        public string? Name { get; set; }
        public bool ?IsFavorite { get; set; }
        public PlannedRideStatisticsModel? Statistics { get; set; }
        public List<PlannedRidePointModel>? RidePoints { get; set; }

        public PlannedRideModel()
        {
            this.Statistics = new PlannedRideStatisticsModel();
        }

        public PlannedRideModel(PlannedRide p_plannedRide)
        {
            this.PlannedRideId = p_plannedRide.PlannedRideId;
            this.Name = p_plannedRide?.Name;
            this.IsFavorite = p_plannedRide?.IsFavorite;
            if (p_plannedRide.Statistics != null)
            {
                this.Statistics = new PlannedRideStatisticsModel(p_plannedRide.Statistics);
            }

            if (p_plannedRide.RidePoints != null)
            {
                this.RidePoints = p_plannedRide.RidePoints
                    .Select(point => new PlannedRidePointModel(point))
                    .ToList();
            }
        }

        public PlannedRide ToEntity()
        {
            return new PlannedRide
            {
                PlannedRideId = this.PlannedRideId,
                Name = this.Name,
                IsFavorite = this.IsFavorite,
                Statistics = this.Statistics?.ToEntity(),
                RidePoints = this.RidePoints?
                    .Select(point => point.ToEntity())
                    .ToList()
            };
        }
    }

}

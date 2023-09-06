using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class CompletedRideModel
    {
        public string UserLogin { get; set; }
        public Guid CompletedRideId { get; set; }
        public Guid? PlannedRideId { get; set; }
        public List<CompletedRidePointModel>? CompletedRidePoints { get; set; }
        public CompletedRideStatisticsModel Statistics { get; set; }

        public CompletedRideModel()
        {
            ;
        }

        public CompletedRideModel(CompletedRide p_completedRide)
        {
            this.CompletedRideId = p_completedRide.CompletedRideId;

            if (p_completedRide.PlannedRideId != null)
            {
                this.PlannedRideId = p_completedRide.PlannedRideId;
            }
            else
            {
                this.PlannedRideId = null;
            }

            if (p_completedRide.CompletedRidePoints != null)
            {
                this.CompletedRidePoints = p_completedRide.CompletedRidePoints
                    .Select(point => new CompletedRidePointModel(point))
                    .ToList();
            }

            this.Statistics = new CompletedRideStatisticsModel(p_completedRide.Statistics);
        }

        public CompletedRide ToEntity()
        {
            return new CompletedRide
            {
                CompletedRideId = this.CompletedRideId,
                PlannedRideId = this.PlannedRideId,
                CompletedRidePoints = this.CompletedRidePoints?
                    .Select(point => point.ToEntity())
                    .ToList(),
                Statistics = this.Statistics.ToEntity()
            };
        }
    }

}

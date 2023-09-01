using TrackSense.API.Entities;

namespace TrackSense.API.ViewModels
{
    public class CompletedRideViewModel
    {
        public Guid CompletedRideId { get; set; }
        public PlannedRideViewModel? PlannedRide { get; set; }
        public List<CompletedRidePointModel>? CompletedRidePoints { get; set; }
        public CompletedRideStatisticsModel Statistics { get; set; }

        public CompletedRideViewModel()
        {
            this.Statistics = new CompletedRideStatisticsModel();
        }

        public CompletedRideViewModel(CompletedRide p_completedRide)
        {
            this.CompletedRideId = p_completedRide.CompletedRideId;

            if (p_completedRide.PlannedRide != null)
            {
                this.PlannedRide = new PlannedRideViewModel(p_completedRide.PlannedRide);
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
                CompletedRideId = CompletedRideId,
                PlannedRide = PlannedRide?.ToEntity(),
                CompletedRidePoints = CompletedRidePoints?
                    .Select(point => point.ToEntity())
                    .ToList(),
                Statistics = Statistics.ToEntity()
            };
        }
    }

}

using TrackSense.API.Entities;

namespace TrackSense.API.ViewModels
{
    public class CompletedRideViewModel
    {
        public Guid CompletedRideId { get; set; }
        public PlannedRideViewModel? PlannedRide { get; set; }
        public List<CompletedRidePointViewModel>? CompletedRidePoints { get; set; }
        public CompletedRideStatisticsViewModel Statistics { get; set; }

        public CompletedRideViewModel()
        {
            this.Statistics = new CompletedRideStatisticsViewModel();
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
                    .Select(point => new CompletedRidePointViewModel(point))
                    .ToList();
            }

            this.Statistics = new CompletedRideStatisticsViewModel(p_completedRide.Statistics);
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

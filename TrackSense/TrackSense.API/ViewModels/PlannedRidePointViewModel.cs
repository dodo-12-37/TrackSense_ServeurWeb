using TrackSense.API.Entities;

namespace TrackSense.API.ViewModels
{
    public class PlannedRidePointViewModel
    {
        public LocationViewModel Location { get; set; }
        public int RideStep { get; set; }
        public double Temperature { get; set; }

        public PlannedRidePointViewModel()
        {
            ;
        }

        public PlannedRidePointViewModel(PlannedRidePoint point)
        {
            this.Location = new LocationViewModel(point.Location);
            this.RideStep = point.RideStep;
            this.Temperature = point.Temperature;
        }

        public PlannedRidePoint ToEntity()
        {
            return new PlannedRidePoint
            {
                Location = this.Location.ToEntity(),
                RideStep = this.RideStep,
                Temperature = this.Temperature
            };
        }
    }
}

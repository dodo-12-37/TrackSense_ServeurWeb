using TrackSense.API.Entities;

namespace TrackSense.API.ViewModels
{
    public class CompletedRidePointViewModel
    {
        public LocationViewModel Location { get; set; }
        public int RideStep { get; set; }
        public double Temperature { get; set; }
        public DateTime DateTime { get; set; }

        public CompletedRidePointViewModel()
        {
            ;
        }

        public CompletedRidePointViewModel(CompletedRidePoint p_point)
        {
            this.Location = new LocationViewModel(p_point.Location);
            this.RideStep = p_point.RideStep;
            this.Temperature = p_point.Temperature;
            this.DateTime = p_point.DateTime;
        }

        public CompletedRidePoint ToEntity()
        {
            return new CompletedRidePoint
            {
                Location = this.Location.ToEntity(),
                RideStep = this.RideStep,
                Temperature = this.Temperature,
                DateTime = this.DateTime
            };
        }
    }

}

using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class CompletedRidePointModel
    {
        public LocationModel Location { get; set; }
        public int RideStep { get; set; }
        public double Temperature { get; set; }
        public DateTime DateTime { get; set; }

        public CompletedRidePointModel()
        {
            ;
        }

        public CompletedRidePointModel(CompletedRidePoint p_point)
        {
            this.Location = new LocationModel(p_point.Location);
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

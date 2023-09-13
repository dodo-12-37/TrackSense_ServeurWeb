using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class PlannedRidePointModel
    {
        public LocationModel Location { get; set; }
        public int ?RideStep { get; set; }
        public double ?Temperature { get; set; }

        public PlannedRidePointModel()
        {
            ;
        }

        public PlannedRidePointModel(PlannedRidePoint point)
        {
            this.Location = new LocationModel(point.Location);
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

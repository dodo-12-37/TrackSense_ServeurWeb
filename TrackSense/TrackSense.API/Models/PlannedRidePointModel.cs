using System.ComponentModel;
using System.Text.Json.Serialization;
using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class PlannedRidePointModel
    {
        [JsonIgnore]
        public string? PlannedRideId { get; set; } = null;
        public LocationModel Location { get; set; } = new LocationModel();
        public int ?RideStep { get; set; }
        public double? Temperature { get; set; } 

        public PlannedRidePointModel()
        {
            ;
        }

        public PlannedRidePointModel(PlannedRidePoint point)
        {
            this.PlannedRideId = point.PlannedRideId;
            this.Location = new LocationModel(point.Location);
            this.RideStep = point.RideStep;
            this.Temperature = point.Temperature;
        }

        public PlannedRidePoint ToEntity()
        {
            return new PlannedRidePoint
            {
                PlannedRideId = this.PlannedRideId,
                Location = this.Location.ToEntity(),
                RideStep = this.RideStep,
                Temperature = this.Temperature
            };
        }
    }
}

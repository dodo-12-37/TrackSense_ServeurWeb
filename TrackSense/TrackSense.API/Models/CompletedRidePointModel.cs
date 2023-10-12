using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class CompletedRidePointModel
    {
        [JsonIgnore]
        public string? CompletedRideId { get; set; }
        public LocationModel Location { get; set; } = new LocationModel();
        public int ? RideStep { get; set; }
        public double ? Temperature { get; set; }
        public DateTime DateTime { get; set; }

        public CompletedRidePointModel()
        {
            ;
        }

        public CompletedRidePointModel(CompletedRidePoint p_point)

        {
            this.CompletedRideId = p_point.CompletedRideId;
            this.Location = new LocationModel(p_point.Location);
            this.RideStep = p_point.RideStep;
            this.Temperature = p_point.Temperature;
            this.DateTime = p_point.Date;
        }

        public CompletedRidePoint ToEntity()
        {
            Entities.Location location= this.Location.ToEntity();

            return new CompletedRidePoint
            {
                CompletedRideId = this.CompletedRideId,
                Location = location,
                LocationId = location.LocationId,
                RideStep = this.RideStep,
                Temperature = this.Temperature,
                Date = this.DateTime
            };
        }
    }

}

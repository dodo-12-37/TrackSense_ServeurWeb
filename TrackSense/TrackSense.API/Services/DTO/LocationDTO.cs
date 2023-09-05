using System.ComponentModel.DataAnnotations;
using TrackSense.API.Entities;

namespace TrackSense.API.Services.DTO
{
    public class LocationDTO
    {
        [Key]
        public int LocationId { get; set; } = 0;
        public double Latitude { get; set; } = 0.0;
        public double Longitude { get; set; } = 0.0;
        public double Altitude { get; set; } = 0.0;
        public double Speed { get; set; } = 0.0;
        public LocationDTO() { }
        public LocationDTO(Location p_location)
        {
            this.LocationId = p_location.LocationId;
            this.Latitude = p_location.Latitude;
            this.Longitude = p_location.Longitude;
            this.Altitude = p_location.Altitude;
            this.Speed = p_location.Speed;
        }
        public Location ToEntity()
        {
            return new Location()
            {
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                Altitude = this.Altitude,
                Speed = this.Speed
            };
        }
    }
}

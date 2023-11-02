using System.ComponentModel;
using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class LocationModel
    {
        [DefaultValue(0)]
        
        public int LocationId { get; set; } = 0;

        [DefaultValue(46.778180)]
        public double Latitude { get; set; } = 0;

        [DefaultValue(-71.313940)]
        public double Longitude { get; set; } = 0;
        public double ?Altitude { get; set; }
        public double? Speed { get; set; } = 0;


        public LocationModel()
        {
            ;
        }

        public LocationModel(Location p_location)
        {
            this.LocationId = p_location.LocationId;
            this.Latitude = p_location.Latitude;
            this.Longitude = p_location.Longitude;
            this.Altitude = p_location.Altitude;
            this.Speed = p_location.Speed;
        }

        public Location ToEntity()
        {
            return new Location
            {
                //LocationId = this.LocationId,
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                Altitude = this.Altitude,
                Speed = this.Speed
            };
        }
    }

}

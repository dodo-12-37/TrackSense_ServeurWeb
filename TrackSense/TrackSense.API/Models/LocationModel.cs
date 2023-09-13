using TrackSense.API.Entities;

namespace TrackSense.API.Models
{
    public class LocationModel
    {
        public Guid LocationId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double ?Altitude { get; set; }
        public double ?Speed { get; set; }


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
                LocationId = this.LocationId,
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                Altitude = this.Altitude,
                Speed = this.Speed
            };
        }
    }

}

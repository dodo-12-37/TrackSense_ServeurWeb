namespace TrackSense.API.Entities
{
    public class Location
    {
        public int LocationId { get; set; } = 0;
        public double Latitude { get; set; } = 0;
        public double Longitude { get; set; }= 0;
        public double? Altitude { get; set; }
        public double? Speed { get; set; } = 0;


    }
}

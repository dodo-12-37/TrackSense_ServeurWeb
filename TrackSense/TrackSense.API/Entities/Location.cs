namespace TrackSense.API.Entities
{
    public class Location
    {
        public Guid LocationId { get; set; } = Guid.NewGuid();
        public double Latitude { get; set; } = 0;
        public double Longitude { get; set; }= 0;
        public double? Altitude { get; set; }
        public double? Speed { get; set; } = 0;
    }
}

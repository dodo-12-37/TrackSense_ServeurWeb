namespace TrackSense.API.Entities
{
    public class CompletedRidePoint
    {
        public Location Location { get; set; }
        public int RideStep { get; set; }
        public double Temperature { get; set; }
        public DateTime DateTime { get; set; }
    }
}

namespace TrackSense.API.Entities
{
    public class PlannedRidePoint
    {
        public Location Location { get; set; }
        public int RideStep { get; set; }
        public double Temperature { get; set; }
    }
}

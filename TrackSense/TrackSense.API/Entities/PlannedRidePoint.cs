namespace TrackSense.API.Entities
{
    public class PlannedRidePoint
    {
        public Guid PlannedRideId { get; set; } = new Guid();
        public Location Location { get; set; } = new Location();
        public int? RideStep { get; set; } = 0;
        public double? Temperature { get; set; } = 0;
        public PlannedRidePoint()
        {
            
        }
        public PlannedRidePoint(Location p_location)
        {
            this.Location = p_location;
        }
    }
}

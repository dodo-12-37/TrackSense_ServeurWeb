namespace TrackSense.API.Entities
{
    public class PlannedRidePoint
    {
        public Guid PlannedRideId { get; set; } = Guid.NewGuid();
        public Location Location { get; set; } = new Location();
        public int? RideStep { get; set; } = 0;
        public double? Temperature { get; set; } = 0;
        public PlannedRidePoint()
        {
            
        }
    
    }
}
